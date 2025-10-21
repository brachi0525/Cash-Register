using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// רשומה לפרטי מוצר
    /// </summary>
    /// <param name="Code">מס' מזהה</param>
    /// <param name="ProductName">שם מוצר</param>
    /// <param name="Category">קטגוריה</param>
    /// <param name="Cost">מחיר</param>
    /// <param name="Count">כמות במלאי</param>
    /// <param name="ListSales">רשימת מבצעים למוצר</param>

    public class Product
    {
        
  
        
        public int Code { get; init; }
        public string? ProductName { get; set; }
        public Category? Category { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public List<BO.SaleInProduct> ListSales { get; set; }
        public override string ToString() => this.ToStringProperty();

    }
}
