using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// רשומה למבצע של מוצר
    /// </summary>
    /// <param name="Code">מס' מזהה של המבצע</param>
    /// <param name="Count">כמות למבצע</param>
    /// <param name="Cost">מחיר</param>
    /// <param name="IsAllClient">מיועד לכל הלקוחות?</param>
    public class SaleInProduct
    {
       

        public int Code { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }
        public bool IsAllClient { get; set; }
        public SaleInProduct(int Code, int Count, double Cost, bool IsAllClient)
        {
            this.Code = Code;
            this.Count = Count;
            this.Cost = Cost;
            this.IsAllClient =IsAllClient; 
        }
        public override string ToString() => this.ToStringProperty();

    }
}
