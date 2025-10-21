using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class ProductImplementation:IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Product item)
    {
        try
        {
            return _dal.Product.Create(item.convertToDOProduct());
            
        }

        catch (DO.ProductAlreadyExistsException ex)
        {
            throw new BO.BlException($"מוצר כבר קיים: {item.ProductName}", ex);
        }
        catch (Exception ex)
        {
            throw new BO.BlException("שגיאה ביצירת מוצר", ex);
        }
    }
    public void Delete(int id)
    {
        try
        {

            _dal.Product.Delete(id);
        }
        catch (DO.ProductNotFoundException ex)
        {
            throw new BO.BlProductNotFoundException($"המוצר לא נמצא במערכת הנתונים {ex.Message}.");
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

   

    public BO.Product? Read(int id)
    {
        try
        {
            return _dal.Product.Read(id).convertToBOProduct();
        }
        catch(Exception ex) 
        {
            throw new BO.BlException("שגיאה בקריאת מוצר", ex);
        }
    }
    public BO.Product? Read(Func<BO.Product, bool> filter = null)
    {
        try
        {
            return _dal.Product.Read(p => filter(p.convertToBOProduct())).convertToBOProduct();
        }
        catch(Exception ex)
        {
            throw new BO.BlException("שגיאה בסינון מוצר", ex);
        }
    }

    public List<BO.Product> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        try
        {
            return _dal.Product.ReadAll()
                .Select(c => BO.Tools.convertToBOProduct(c))
                .Where(p => filter == null || filter(p))
                .ToList();
        }
        catch (Exception ex)
        {
            throw new BO.BlException("שגיאה בקריאת כלל המוצרים", ex);
        }
    }

    public void Update(BO.Product item)
    {
        try
        {
            _dal.Product.Update(item.convertToDOProduct());

        }
        catch (DO.ProductNotFoundException ex)
        {
            throw new BO.BlProductNotFoundException($"מוצר לעדכון לא נמצא: {item.ProductName}");
        }
        catch (Exception ex)
        {
            throw new BO.BlException("שגיאה בעדכון מוצר", ex);
        }
    }
    public List<SaleInProduct> GetListSale(int code, bool isClient)
    {
        try
        {
            return _dal.Sale.ReadAll(s => s.ProductID == code
            && s.IsClub == isClient && s.DateBeginSale > DateTime.Now)
                .Select(s => new BO.SaleInProduct(s.Id, s.Count, s.cost, s.IsClub)).ToList();
        }
        catch( Exception ex) 
        {
            throw new BO.BlException("שגיאה בשליפת מבצעים למוצר", ex);
        }
    }
}
