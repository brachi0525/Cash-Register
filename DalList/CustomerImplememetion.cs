
namespace Dal;
using DO;
using DalApi;
using Tools;
using System.Reflection;

internal class CustomerImplememetion : ICustomer
{
    public int Create(Customer item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Create customer started");

        foreach (var c1 in DataSource.Customers)
        {
            if (item.Id == c1.Id)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "The customer already exists in the system");

                throw new UserAlreadyExistsException();
            }
        }
        Customer c = item;
        DataSource.Customers.Add(c);

        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finsh Create customer");
        return c.Id;

    }
    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete customer started");

        // שימוש ב-LINQ כדי למצוא את הפריט הנכון
        Customer? c = DataSource.Customers.FirstOrDefault(c => c.Id == id);
        if (c != null)
        {
            DataSource.Customers.Remove(c);
        }
        // LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Delete customer{c.ToString()}");
    }
    //create new entity object in Dal
    public Customer? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read customer started");

        Customer? c = DataSource.Customers.FirstOrDefault(c => c.Id == id);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Read customer");
        return c ?? throw new CodeNotValid();
    }

    public Customer? Read(Func<Customer, bool> filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read customer started");

        Customer? c = DataSource.Customers.FirstOrDefault(c => filter(c));
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Read customer");
        return c ?? throw new CodeNotValid();
    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "read all");
        if (filter != null)
        {
            var q = from customer in DataSource.Customers

                    where filter(customer)
                    select customer;
            return q.ToList();
        }
        else
        {
            return DataSource.Customers.ToList();
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


    public void Update(Customer item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Update customer started");

        Delete(item.Id);
        DataSource.Customers.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"finish Update customer");
    }


}
