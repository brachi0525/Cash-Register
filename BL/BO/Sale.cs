using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// רשומה לפרטי מבצע
    /// </summary>
    /// <param name="Id">מספר מזהה של המבצע</param>
    /// <param name="ProductID">מספר מזהה של מוצר</param>
    /// <param name="Count">כמות נדרשת לקבלת המבצע</param>
    /// <param name="cost">מחיר כולל מבצע</param>
    /// <param name="IsClub">האם רק ללקוחות מועדון?</param>
    /// <param name="DateBeginSale">תאריך תחילת המבצע</param>
    /// <param name="DateEndSale">תאריך סיום המבצע</param>
    public class Sale
    {



        public int Id { get; init; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public double cost { get; set; }
        public bool IsClub { get; set; }
        public DateTime DateBeginSale { get; set; }
        public DateTime DateEndSale { get; set; }
        public override string ToString() => this.ToStringProperty();

    }
}
