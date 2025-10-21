using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// רשומה להכנסת מוצר להזמנה
    /// </summary>
    /// <param name="Code">מס' מזהה של המוצר</param>
    /// <param name="ProductName">שם מוצר</param>
    /// <param name="Cost">מחיר בסיסי של מוצר</param>
    /// <param name="Count">כמות מוצרים להזמנה</param>
    /// <param name="SaleList">רשימת מבצעים למוצר זה</param>
    /// <param name="FinallCost">מחיר סופי</param>
    public class ProductInOrder
    {

        public int Code { get; set; }
        public string ProductName { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public List<BO.SaleInProduct> SaleList{ get; set; }
        public double FinallCost { get; set; }
        public override string ToString() => this.ToStringProperty();

    }
}
