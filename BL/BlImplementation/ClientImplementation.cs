using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using DalApi;




namespace BlImplementation;


internal class ClientImplementation : IClient
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public bool CheckIfClientExist(int id)
    {
        try
        {
            _dal.Customer.Read(id);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public int Create(BO.Client item)
    {
        try
        {
            return _dal.Customer.Create(item.convertToDoCustomer());

        }
        catch (DO.UserAlreadyExistsException ex)
        {
            throw new BlInvalidCodeException("Customer already exists.", ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }


    }

    public void Delete(int id)
    {
        try
        {
            _dal.Customer.Delete(id);
        }
        catch (DO.ItemNotFoundException ex)
        {
            throw new BlInvalidCodeException("Customer does not exist.", ex);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public BO.Client? Read(int id)
    {
        try
        {
            return _dal.Customer.Read(id).convertToBOClient();

        }
        catch (DO.ItemNotFoundException ex)
        {
            throw new BlInvalidCodeException(ex.Message);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public BO.Client? Read(Func<BO.Client, bool> filter = null)
    {
        try
        {
            return _dal.Customer.Read(c => filter(c.convertToBOClient())).convertToBOClient();
        }
        catch (DO.ErrorInReed ex)
        {
            throw new BlErrorInReed( ex.Message);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<BO.Client?> ReadAll(Func<BO.Client, bool>? filter = null)
    {
        try
        { 
             var clientsFromDal = _dal.Customer.ReadAll(c => true); // קורא את כל הלקוחות
        var clients = clientsFromDal
            .Select(c => c.convertToBOClient())  // המרה ל-BO.Client
            .Where(c => filter == null || filter(c))  // אם יש filter, נבצע סינון
            .ToList();

        return clients;
        }
        catch (DO.ErrorInReed ex)
        {
            throw new BlErrorInReed(ex.Message);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Update(BO.Client item)
    {
        try
        {
            _dal.Customer.Update(item.convertToDoCustomer());

        }
        catch(DO.UpdateFailedException ex) 
        {
            throw new BlException(ex.Message);
        }
    }
}

