using BO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddProducttoorder : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();
        private BO.Order currentOrder;
        public event Action? SomethingHappenedOnClose;
        private bool isLoaded = false;
        private ListBox clientListBox;
        private ProductInOrder Product;

        public BO.Product AddedProduct { get; private set; }

        public AddProducttoorder(BO.Order order, ListBox listBoxFromClient)
        {
            InitializeComponent();
            currentOrder = order;
            clientListBox = listBoxFromClient;
            LoadProducts();
            isLoaded = true;
        }

        private void LoadProducts()
        {
            comboBox1.DataSource = _bl.Product.ReadAll().ToList();
            comboBox1.DisplayMember = "ProductName";
            comboBox1.ValueMember = "Code";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded || comboBox1.SelectedValue == null)
                return;

            int selectedProduct = int.Parse(comboBox1.SelectedValue.ToString());
            ShowSalesForProduct(selectedProduct);
        }

        private void ShowSalesForProduct(int productCode)
        {
            try
            {
                listBox1.Items.Clear();

                Product = new ProductInOrder
                {
                    Code = productCode,
                    Cost = _bl.Product.Read(productCode).Cost,
                };
                listBox1.Items.Add("מחיר ליחידה :" + Product.Cost);

                _bl.Order.SearchSaleForProduct(Product, currentOrder.IsClient);

                if (Product.SaleList != null)
                {
                    foreach (var sale in Product.SaleList)
                    {
                        string line = $"מבצע: {sale.Count} ב-{sale.Cost} {(sale.IsAllClient ? "(מועדון)" : "")}";
                        listBox1.Items.Add(line);
                    }
                }
                else
                {
                    listBox1.Items.Add("אין מבצעים פעילים למוצר זה.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בקבלת מבצעים: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox1.Text, out int quantity))
                {
                    MessageBox.Show("אנא הכנס כמות חוקית");
                    return;
                }

                var selectedProduct = comboBox1.SelectedItem as BO.Product;
                if (selectedProduct == null)
                {
                    MessageBox.Show("אנא בחר מוצר מהרשימה.");
                    return;
                }

                int selectedProductId = selectedProduct.Code;
                _bl.Order.AddProductToOrder(currentOrder, selectedProductId, quantity);

                string line = $"{selectedProduct.ProductName} - כמות: {quantity} - מחיר ליחידה: {selectedProduct.Cost}₪";
                clientListBox.Items.Add(line);

                MessageBox.Show("המוצר נוסף להזמנה!");
                SomethingHappenedOnClose?.Invoke();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת הוספת המוצר להזמנה:\n" + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) { }

        private void AddProducttoorder_Load(object sender, EventArgs e) { }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Product.Count = int.Parse(textBox1.Text);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
