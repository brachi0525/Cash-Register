using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// רשומה לפרטי הזמנה
    /// </summary>
    /// <param name="IsClient">האם לקוח מועדף? </param>
    /// <param name="ProductInOrderList">רשימת המוצרים בהזמנה </param>
    /// <param name="FinallCost">המחיר הסופי לתשלום</param>
    public class Order
    {
        
        public bool IsClient { get; set; }
        public List<BO.ProductInOrder> ProductInOrderList { get; set; }
        public double FinallCost { get; set; }

        public Order()
        {
            ProductInOrderList = new List<BO.ProductInOrder>();
        }
        public override string ToString() => this.ToStringProperty();


    }
}
