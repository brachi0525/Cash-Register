using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DO;
using DalApi;
using Tools;
using System.Reflection;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
        private const string FilePath = "../xml/sales.xml";

        public int Create(Sale item)
        {
            try
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Create sale started");

                XElement root = File.Exists(FilePath) ? XElement.Load(FilePath) : new XElement("Sales");

                XElement newSale = new XElement("Sale",
                   new XElement("Id", Config.saleId),
                   new XElement("ProductID", item.ProductID),
                   new XElement("Count", item.Count),
                   new XElement("Cost", item.cost),
                   new XElement("IsClub", item.IsClub),
                   new XElement("DateBeginSale", item.DateBeginSale),
                   new XElement("DateEndSale", item.DateEndSale)
               );

                root.Add(newSale);
                root.Save(FilePath);

                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Create sale finished");
                return item.Id;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
                throw new Exception("שגיאה ביצירת מבצע", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete sale started");

                if (!File.Exists(FilePath))
                    throw new FileNotFoundException("Database file not found.");

                XElement root = XElement.Load(FilePath);

                XElement saleElement = root.Elements("Sale")
                    .FirstOrDefault(s => (int)s.Element("Id") == id);

                if (saleElement == null)
                    throw new KeyNotFoundException($"Sale with id {id} not found.");

                saleElement.Remove();
                root.Save(FilePath);

                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete sale finished");
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
                throw new Exception("שגיאה במחיקת מבצע", ex);
            }
        }

        public Sale Read(int id)
        {
            try
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read sale by ID started");

                if (!File.Exists(FilePath))
                    throw new FileNotFoundException("קובץ בסיס הנתונים לא נמצא.");

                XElement root = XElement.Load(FilePath);

                XElement? saleElement = root.Elements("Sale")
                    .FirstOrDefault(s => (int?)s.Element("Id") == id);

                if (saleElement == null)
                    throw new SaleNotFoundException($"לא נמצא מבצע עם מזהה {id}");

                Sale s = new Sale
                {
                    Id = int.Parse(saleElement.Element("Id").Value),
                    ProductID = int.Parse(saleElement.Element("ProductID").Value),
                    Count = int.Parse(saleElement.Element("Count").Value),
                    cost = double.Parse(saleElement.Element("Cost").Value),
                    IsClub = bool.Parse(saleElement.Element("IsClub").Value),
                    DateBeginSale = DateTime.Parse(saleElement.Element("DateBeginSale").Value),
                    DateEndSale = DateTime.Parse(saleElement.Element("DateEndSale").Value)
                };

                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read sale by ID finished");
                return s;
            }
            catch (SaleNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
                throw new Exception("שגיאה בקריאת מבצע", ex);
            }
        }

        public Sale Read(Func<Sale, bool> filter)
        {
            try
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read sale with filter started");

                var sale = ReadAll(filter).FirstOrDefault();

                if (sale == null)
                    throw new SaleNotFoundException("לא נמצא מבצע התואם לסינון.");

                return sale;
            }
            catch (SaleNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
                throw new Exception("שגיאה בסינון מבצע", ex);
            }
        }


        public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            try
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read all sales started");

                if (!File.Exists(FilePath))
                    return new List<Sale?>();

                XElement root = XElement.Load(FilePath);

                List<Sale> sales = root.Elements("Sale")
                    .Select(s => new Sale
                    {
                        Id = int.Parse(s.Element("Id").Value),
                        ProductID = int.Parse(s.Element("ProductID").Value),
                        Count = int.Parse(s.Element("Count").Value),
                        cost = double.Parse(s.Element("Cost").Value),
                        IsClub = bool.Parse(s.Element("IsClub").Value),
                        DateBeginSale = DateTime.Parse(s.Element("DateBeginSale").Value),
                        DateEndSale = DateTime.Parse(s.Element("DateEndSale").Value)
                    })
                    .ToList();

                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read all sales finished");

                return filter != null ? sales.Where(filter).ToList() : sales;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
                throw new Exception("שגיאה בקריאת כלל המבצעים", ex);
            }
        }

        public void Update(Sale item)
        {
            try
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Update sale started");

                if (!File.Exists(FilePath))
                    throw new FileNotFoundException("Database file not found.");

                XElement root = XElement.Load(FilePath);

                XElement saleElement = root.Elements("Sale")
                    .FirstOrDefault(s => (int?)s.Element("Id") == item.Id);

                if (saleElement == null)
                    throw new KeyNotFoundException("Sale not found");

                saleElement.SetElementValue("ProductID", item.ProductID);
                saleElement.SetElementValue("Count", item.Count);
                saleElement.SetElementValue("Cost", item.cost);
                saleElement.SetElementValue("IsClub", item.IsClub);
                saleElement.SetElementValue("DateBeginSale", item.DateBeginSale);
                saleElement.SetElementValue("DateEndSale", item.DateEndSale);

                root.Save(FilePath);

                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Update sale finished");
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
                throw new Exception("שגיאה בעדכון מבצע", ex);
            }
        }
    }
}
