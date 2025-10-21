using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class clientMenu : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();
        private BO.Order order;

        public clientMenu()
        {
            InitializeComponent();
            listBox1.Visible = false;
            label3.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }
        private void refreshSal()
        {
            listBox1.Items.Clear();
            _bl.Order.CalcTotalPrice(order);
            listBox1.Items.Add("סכום ביניים" + order.FinallCost);
            foreach (var item in order.ProductInOrderList)
            {
                string line = $"{item.ProductName} - כמות: {item.Count} - מחיר ליחידה: {item.Cost}₪";
                listBox1.Items.Add(line);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            order = _bl.Order.createOrder();
            order.IsClient = _bl.client.CheckIfClientExist(int.Parse(textBox1.Text));
            label2.Text = order.IsClient ? "לקוח קיים" : "לקוח מזדמן";

            textBox1.Visible = false;
            label1.Visible = false;
            button1.Visible = false;
            listBox1.Visible = true;
            label3.Visible = true;
            button2.Visible = true;
            button3.Visible = true;

            listBox1.Items.Clear();
            listBox1.Items.Add("מוכנים להוסיף מוצרים!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var addProducttoorder = new AddProducttoorder(order, listBox1);
            addProducttoorder.SomethingHappenedOnClose += () =>
            {
                refreshSal();
            };
            addProducttoorder.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _bl.Order.CalcTotalPrice(order);

                _bl.Order.DoOrder(order);
                double price = order.FinallCost;

                MessageBox.Show($"ההזמנה בוצעה בהצלחה! המחיר הסופי הוא {price} ₪"); ;
                finish finish = new finish();
                finish.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void clientMenu_Load(object sender, EventArgs e) { }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
