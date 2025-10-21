using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;

namespace BlImplementation;

internal class OrderImplementation : IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public BO.Order createOrder()
    {
        return new BO.Order();
    }
    public List<BO.SaleInProduct> AddProductToOrder(BO.Order ord, int id, int count)
    {
        try
        {
            if (count <= 0)
            {
                throw new BlException("כמות המוצר חייבת להיות גדולה מאפס.");
            }
            DO.Product p = _dal.Product.Read(id);
            if (p == null)
            {
                throw new BlProductDoesNotExistException();
            }
            List<BO.SaleInProduct> useSales = new List<BO.SaleInProduct>();
            BO.ProductInOrder existingProduct = ord.ProductInOrderList.FirstOrDefault(po => po.Code == id);

            if (existingProduct != null)
            {
                if (p.Count >= existingProduct.Count + count)//בדיקה אם יש כמות מספיקה במלאי
                {
                    existingProduct.Count += count;
                }
                else
                {
                    throw new BlOutOfStockException("BlOutOfStockException");//אין מספיק במלאי
                }

            }
            else
            {
                if (p.Count >= count)
                {//הוספת מוצר חדש להזמנה
                    existingProduct = new BO.ProductInOrder();

                    existingProduct.Code = p.Code;
                    existingProduct.ProductName = p.ProductNane;
                    existingProduct.Cost = p.Cost;
                    existingProduct.Count = count;
                    existingProduct.SaleList = new List<BO.SaleInProduct>();

                    ord.ProductInOrderList.Add(existingProduct);
                }
                else
                {
                    throw new BlOutOfStockException("BlOutOfStockException");//אין מספיק במלאי
                }
            }
            SearchSaleForProduct(existingProduct, ord.IsClient);
            CalcTotalPriceForProduct(existingProduct);
            useSales = existingProduct.SaleList;
            CalcTotalPrice(ord);

            return useSales;

        }

        catch (Exception ex)
        {
            throw new Exception($"Error in AddProductToOrder: {ex.Message}", ex);
            ;
        }

    }


    public void CalcTotalPrice(BO.Order order)
    {
        try
        {

            order.FinallCost = order.ProductInOrderList.Sum(p => p.FinallCost);
        }
        catch (Exception ex)
        {
            throw new BlException($"שגיאה בחישוב מחיר כולל: {ex.Message}");
        }
    }



    /// <summary>
    /// מחשבת את המחיר הסופי של מוצר בהזמנה בהתבסס על רשימת המבצעים הזמינים.
    /// אם קיימים מבצעים, תחושב עלות מופחתת בהתאם למבצעי כמות.
    /// אם אין מבצעים, המחיר יחושב כמחיר רגיל ללא הנחה.
    /// </summary>
    /// <param name="product">המוצר בהזמנה שעליו מבוצע החישוב.</param>


    public void CalcTotalPriceForProduct(BO.ProductInOrder product)
{
        try
        {
            List<BO.SaleInProduct> useSales = new List<BO.SaleInProduct>();

            if (product.SaleList == null || product.SaleList.Count == 0)
            {
                product.FinallCost = product.Cost * product.Count;
            }
            else
            {
                product.Cost = _dal.Product.Read(product.Code).Cost;
                int count = product.Count;
                double price = 0;

                foreach (BO.SaleInProduct sale in product.SaleList)
                {
                    if (count == 0)
                        break;

                    if (sale.Count <= count)
                    {
                        int applicableTimes = count / sale.Count;
                        price += applicableTimes * sale.Cost;
                        count -= applicableTimes * sale.Count;
                        useSales.Add(sale);
                    }
                }

                if (count > 0)
                {
                    price += count * product.Cost;
                }

                product.FinallCost = price;
                product.SaleList = useSales;
            }
        }catch (Exception ex)
        {
            throw new BlException($"Error in CalcTotalPriceForProduct {ex.Message}", ex);
        }
}


    public void DoOrder(BO.Order order)
    {
        try
        {
            if (order.ProductInOrderList == null || !order.ProductInOrderList.Any())
            {
                throw new BlException(" אין מוצרים בהזמנה.");
            }
            order.ProductInOrderList.ForEach(productInOrder =>
            {
                DO.Product? product = _dal.Product.Read(productInOrder.Code);

                if (product == null)
                    throw new BO.BlProductDoesNotExistException($"המוצר עם קוד {productInOrder.Code} לא נמצא!");

                if (product.Count < productInOrder.Count)
                    throw new BO.BlOutOfStockException($"אין מספיק מלאי למוצר {productInOrder.Code}");

                DO.Product updatedProduct = product with { Count = product.Count - productInOrder.Count };

                _dal.Product.Update(updatedProduct);
            });
        }
        catch (Exception ex)
        {
            throw new BlException($"שגיאה בביצוע הזמנה: {ex.Message}");
            throw;
        }
    }






    public void SearchSaleForProduct(BO.ProductInOrder product, bool existingClient)
    {
        try
        {
            if (product != null)
            {
                List<DO.Sale> sales = _dal.Sale.ReadAll(p => p.ProductID == product.Code);

                product.SaleList = sales
                    .Where(s => s.DateBeginSale <= DateTime.Now
                             && s.DateEndSale >= DateTime.Now
                             && (!s.IsClub || existingClient))
                    .OrderBy(s => s.cost / s.Count)
                    .Select(s => new BO.SaleInProduct(s.Id, s.Count, s.cost, s.IsClub))
                    .ToList();
            }
            else
            {
                throw new BlException("שגיאה: מוצר לא סופק לחיפוש מבצע.");
            }
        }
        catch (Exception ex)
        {
            throw new BlException($"שגיאה בחיפוש מבצעים למוצר {product?.Code}: {ex.Message}");
            // ניתן גם לרשום ללוג או לזרוק שוב
            throw;
        }
    }



}