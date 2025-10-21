using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace BO
{
    internal static class Tools
    {
        public static BO.Client convertToBOClient(this DO.Customer c)
        {
            if (c == null)
                throw new BlClientDoesNotExistException();
            try
            {
                return new BO.Client()
                {
                    Id = c.Id,
                    CustomerName = c.CustomerName,
                    Address = c.Address,
                    PhoneNumber = c.PhoneNumber,
                };
            }
            catch (Exception e)
            {
                throw new Exception("Failed to convert DO.Customer to BO.Client", e);
            }
        }

        public static DO.Customer convertToDoCustomer(this BO.Client c)
        {
            if (c == null)
                throw new BlClientDoesNotExistException();
            try
            {
                return new DO.Customer()
                {
                    Id = c.Id,
                    CustomerName = c.CustomerName,
                    Address = c.Address,
                    PhoneNumber = c.PhoneNumber,
                };
            }
            catch (Exception e)
            {
                throw new Exception("Failed to convert BO.Client to DO.Customer", e);
            }
        }

        public static BO.Product convertToBOProduct(this DO.Product P)
        {
            if (P == null)
                throw new BlProductDoesNotExistException("Product is null");
            try
            {
                return new BO.Product()
                {
                    Code = P.Code,
                    ProductName = P.ProductNane,
                    Category = (BO.Category)P.Category,
                    Cost = P.Cost,
                    Count = P.Count
                };
            }
            catch (Exception e)
            {
                throw new BlProductDoesNotExistException("Failed to convert DO.Product to BO.Product", e);
            }
        }

        public static DO.Product convertToDOProduct(this BO.Product P)
        {
            if (P == null)
                throw new BlProductDoesNotExistException("Product is null");
            try
            {
                return new DO.Product()
                {
                    Code = P.Code,
                    ProductNane = P.ProductName,
                    Category = (DO.Category)P.Category,
                    Cost = P.Cost,
                    Count = P.Count
                };
            }
            catch (Exception e)
            {
                throw new Exception("Failed to convert BO.Product to DO.Product", e);
            }
        }

        public static DO.Sale convertToDOSale(this BO.Sale s)
        {
            if (s == null)
                throw new Exception("sale is null");
            try
            {
                return new DO.Sale()
                {
                    Id = s.Id,
                    ProductID = s.ProductID,
                    Count = s.Count,
                    cost = s.cost,
                    IsClub = s.IsClub,
                    DateBeginSale = s.DateBeginSale,
                    DateEndSale = s.DateEndSale
                };
            }
            catch (Exception e)
            {
                throw new Exception("Failed to convert BO.Sale to DO.Sale", e);
            }
        }

        public static BO.Sale convertToBOSale(this DO.Sale s)
        {
            if (s == null)
                throw new Exception("sale is null");
            try
            {
                return new BO.Sale()
                {
                    Id = s.Id,
                    ProductID = s.ProductID,
                    Count = s.Count,
                    cost = s.cost,
                    IsClub = s.IsClub,
                    DateBeginSale = s.DateBeginSale,
                    DateEndSale = s.DateEndSale
                };
            }
            catch (Exception e)
            {
                throw new Exception("Failed to convert DO.Sale to BO.Sale", e);
            }
        }

        public static string ToStringProperty<T>(this T obj)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                foreach (PropertyInfo item in obj.GetType().GetProperties())
                {
                    str.AppendLine($"{item.Name} :{item.GetValue(obj)}");
                }
                return str.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("Failed to generate string from object properties", e);
            }
        }
    }
}
