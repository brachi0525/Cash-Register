using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using DalApi;
using DO;
using Tools;

namespace Dal;

internal class ProductImplementation : IProduct
{
    public const string FilePath = "../xml/products.xml";

    public int Create(Product item)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Create product started");

            XElement root = File.Exists(FilePath) ? XElement.Load(FilePath) : new XElement("Products");

            bool productExists = root.Elements("Product")
                .Any(p => (string)p.Element("Name") == item.ProductNane);

            if (productExists)
                throw new ProductAlreadyExistsException($"מוצר עם שם {item.ProductNane} כבר קיים.");

            XElement productElement = new XElement("Product",
                new XElement("Code", Config.productId),
                new XElement("Name", item.ProductNane),
                new XElement("cost", item.Cost),
                new XElement("count", item.Count),
                new XElement("category", item.Category)
            );

            root.Add(productElement);
            root.Save(FilePath);

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Create product finished");

            return item.Code;
        }
        catch (ProductAlreadyExistsException)
        {
            throw;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            throw new Exception("שגיאה ביצירת מוצר", ex);
        }
    }


    public void Delete(int code)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete product started");

            if (!File.Exists(FilePath))
                throw new FileNotFoundException("קובץ נתונים לא נמצא.");

            XElement root = XElement.Load(FilePath);

            XElement productElement = root.Elements("Product")
                .FirstOrDefault(p => p.Element("Code")?.Value == code.ToString());

            if (productElement == null)
                throw new ProductNotFoundException($"מוצר עם קוד {code} לא נמצא.");

            productElement.Remove();
            root.Save(FilePath);

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete product finished");
        }
        catch (ProductNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            throw new Exception("שגיאה במחיקת מוצר", ex);
        }
    }

    public Product Read(int id)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read product by ID started");

            if (!File.Exists(FilePath))
                throw new FileNotFoundException("קובץ נתונים לא נמצא.");

            XElement root = XElement.Load(FilePath);

            XElement productElement = root.Elements("Product")
                .FirstOrDefault(p => p.Element("Code")?.Value == id.ToString());

            if (productElement == null)
                throw new ProductNotFoundException($"מוצר עם קוד {id} לא נמצא.");

            return new Product
            {
                Code = int.Parse(productElement.Element("Code")?.Value ?? "0"),
                ProductNane = productElement.Element("Name")?.Value,
                Category = Enum.Parse<Category>(productElement.Element("category")?.Value ?? "0"),
                Cost = double.Parse(productElement.Element("cost")?.Value ?? "0"),
                Count = int.Parse(productElement.Element("count")?.Value ?? "0")
            };
        }
        catch (ProductNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            throw new ErrorInReed($"שגיאה בקריאת מוצר לפי קוד {ex.Message}");
        }
    }


    public Product Read(Func<Product, bool> filter)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read product with filter started");

            var result = ReadAll(filter).FirstOrDefault();

            if (result == null)
                throw new ProductNotFoundException("לא נמצא מוצר התואם לסינון.");

            return result;
        }
        catch (ProductNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            throw new Exception("שגיאה בסינון מוצר", ex);
        }
    }


    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read all products started");

            if (!File.Exists(FilePath))
                return new List<Product?>();

            XElement root = XElement.Load(FilePath);

            List<Product> products = root.Elements("Product")
                .Select(p => new Product
                {
                    Code = int.Parse(p.Element("Code").Value),
                    ProductNane = p.Element("Name").Value,
                    Category = Enum.Parse<Category>(p.Element("category").Value),
                    Cost = double.Parse(p.Element("cost").Value),
                    Count = int.Parse(p.Element("count").Value)
                })
                .ToList();

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read all products finished");

            return filter != null ? products.Where(filter).ToList() : products;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
throw new ErrorInReed($"שגיאה בקריאת כלל המוצרים: {ex.Message}");
        }
    }

    public void Update(Product item)
    {
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Update product started");

            if (!File.Exists(FilePath))
                throw new FileNotFoundException("קובץ נתונים לא נמצא.");

            XElement root = XElement.Load(FilePath);

            XElement? productElement = root.Elements("Product")
                .FirstOrDefault(p => (int?)p.Element("Code") == item.Code);

            if (productElement == null)
                throw new ProductNotFoundException($"מוצר עם קוד {item.Code} לא נמצא.");

            productElement.SetElementValue("Name", item.ProductNane);
            productElement.SetElementValue("category", item.Category);
            productElement.SetElementValue("cost", item.Cost);
            productElement.SetElementValue("count", item.Count);

            root.Save(FilePath);

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Update product finished");
        }
        catch (ProductNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            throw new Exception("שגיאה בעדכון מוצר", ex);
        }
    }

}
