

namespace Dal;
using DO;
using DalApi;
using System.Reflection;
using Tools;

internal class saleImplememetation: ISale
{


    //create new entity object in Dal
    public int Create(Sale item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Create sale started");

        Sale s = item with { Id = DataSource.Config.SailNumber };
        DataSource.Sales.Add(s);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Create sale");
        return s.Id;

    }
    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Delete sale started");

        Sale? s = DataSource.Sales.FirstOrDefault(sale => sale.Id == id);
        if (s != null)
        {
            DataSource.Sales.Remove(s);
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Delete sale");
    }
    //create new entity object in Dal
    public Sale? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read sale started");

        Sale? s = DataSource.Sales.FirstOrDefault(sale => sale.Id == id);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Read sale");
        return s ?? throw new CodeNotValid();
    }
    public Sale? Read(Func<Sale, bool> filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Read sale started ");

        Sale? c = DataSource.Sales.FirstOrDefault(c => filter(c));
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish read sale");
        return c ?? throw new CodeNotValid();
    }
    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "read all");

        if (filter != null)
        {
            var q = from s in DataSource.Sales

                    where filter(s)
                    select s;
            return q.ToList();
        }
        else
        {
            return DataSource.Sales.ToList();
        }
        // if (filter != null)
        // {
        //    return DataSource.Customers.Where(c => filter(c)).ToList();
        // }
        // else
        // {
        //  return DataSource.Customers.ToList();
        //}
    }



    public void Update(Sale item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Update sale STARTED");

        Delete(item.Id);
        DataSource.Sales.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Update sale");
    }

}
