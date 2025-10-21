using DalApi;
using DO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using Tools;

internal class CustomerImplementation : ICustomer
{
    XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
    public const string filePath = "../xml/customers.xml";

    private void CreateFile()
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Started creating file");

            List<Customer> customers = new List<Customer>();

            using (FileStream XmlWrite = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(XmlWrite, customers);
            }

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Finished creating file");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {e.Message}");
            throw new Exception(e.Message);
        }
    }

    public int Create(Customer item)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Started creating new customer");

            List<Customer> customers = ReadAll() ?? new List<Customer>();

            if (customers.Any(c => c.Id == item.Id))
            {
                throw new UserAlreadyExistsException($"Customer with ID {item.Id} already exists.");
            }

            customers.Add(item);

            using (FileStream XmlWrite = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(XmlWrite, customers);
            }

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Finished creating new customer");
            return item.Id;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }


    public void Delete(int id)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Started deleting customer");

            List<Customer> customers = ReadAll() ?? new List<Customer>();
            Customer? customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                throw new ItemNotFoundException($"Customer with code {id} not found.");

            customers.Remove(customer);

            using (FileStream XmlWrite = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(XmlWrite, customers);
            }

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Finished deleting customer");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {e.Message}");
            throw new Exception(e.Message);
        }
    }

    public Customer? Read(int id)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Started reading customer by ID");
            var result = ReadAll(c => c.Id == id).FirstOrDefault();
            if (result == null)
                throw new ItemNotFoundException($"Customer with ID {id} not found.");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Finished reading customer by ID");
            return result;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }

    public Customer? Read(Func<Customer, bool> filter = null)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Started reading customer with filter");
            var result = ReadAll(filter).FirstOrDefault();
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Finished reading customer with filter");
            return result;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            throw new ErrorInReed(ex.Message);
        }
    }

    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Started reading all customers");

            if (!File.Exists(filePath)) return new List<Customer>();

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                List<Customer> customers = (List<Customer>)serializer.Deserialize(fs);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Finished reading all customers");
                return filter == null ? customers : customers.Where(filter).ToList();
            }
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {e.Message}");
            throw new ErrorInReed(e.Message);
        }
    }

    public void Update(Customer item)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Started updating customer");

            Delete(item.Id);
            Create(item);

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Finished updating customer");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {e.Message}");
            throw new UpdateFailedException(e.Message);
        }
    }
}
