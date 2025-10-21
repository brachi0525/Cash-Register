using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    /// מתודות לניהול הזמנה תוך כדי ביצועה וכן ביצוע ההזמנה הסופי
    /// </summary>
    /// <param name="AddProductToOrder">הוספת מוצר להזמנה</param>
    /// <param name="CalcTotalPriceForProduct">חישוב המחיר הסופי למוצר</param>
    /// <param name="CalcTotalPrice">חישוב המחיר הסופי להזמנה</param>
    /// <param name="DoOrder">ביצוע הזמנה</param>
    /// <param name="SearchSaleForProduct">עדכון המבצעים המתאימים למוצר בהזמנה</param>
    public interface IOrder
    {
        BO.Order createOrder();
        List<BO.SaleInProduct>AddProductToOrder(BO.Order ord,int id,int count);
        void CalcTotalPriceForProduct(BO.ProductInOrder product);
        void CalcTotalPrice(BO.Order order);
        void DoOrder(BO.Order order);
        void SearchSaleForProduct(BO.ProductInOrder product, bool existingClient);
    }
}
