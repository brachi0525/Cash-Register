
namespace Dal;
using DO;
using DalApi;
using System.Reflection;
using Tools;

internal class ProductImplememetation : IProduct
{

    public int Create(Product item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name,"Create product started");

        Product p = item with { Code = DataSource.Config.ProductNumber };
        DataSource.Products.Add(p);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Create product");
        return p.Code;

    }
    public void Delete(int code)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Delete product started");

        Product? p = DataSource.Products.FirstOrDefault(p => p.Code == code);
        if (p != null)
        {
            DataSource.Products.Remove(p);
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Delete product");
    }
    //create new entity object in Dal
    public Product? Read(int code)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read product started");

        Product? p = DataSource.Products.FirstOrDefault(p => p.Code==code);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Read product");
        return p ?? throw new CodeNotValid("the product is not exsist");
    }
    public Product? Read(Func<Product, bool> filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read product started");

        Product? c = DataSource.Products.FirstOrDefault(c => filter(c));
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Read product");
        return c ?? throw new Exception("code not found");
    }
    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read all");
        if (filter != null)
        {
            var q = from p in DataSource.Products

                    where filter(p)
                    select p;
            return q.ToList();
        }
        else
        {
            return DataSource.Products.ToList();
        }

        // if (filter != null)
        // {
        //    return DataSource.Product.Where(p => filter(p)).ToList();
        // }
        // else
        // {
        //  return DataSource.Product.ToList();
        //}
    }



    public void Update(Product item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Delete product started");

        Delete(item.Code);
        DataSource.Products.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Delete product");
    }


}
