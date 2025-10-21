using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class salesManProductMenu : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();

        public salesManProductMenu()
        {
            InitializeComponent();

            foreach (var product in _bl.Product.ReadAll())
            {
                productList.Items.Add(product);
            }
        }
        public void refreshProducts()
        {
            productList.Items.Clear();

            foreach (var product in _bl.Product.ReadAll())
            {
                productList.Items.Add(product);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saleManAddProduct saleManAddProduct = new saleManAddProduct();
            saleManAddProduct.SomethingHappenedOnClose += () =>
            {
                refreshProducts();
            };

            saleManAddProduct.ShowDialog();
        }

        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            saleManDeleteProduct saleManDeleteProduct = new saleManDeleteProduct();
            saleManDeleteProduct.SomethingHappenedOnClose += () =>
            {
                refreshProducts();
            };
            saleManDeleteProduct.ShowDialog();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            saleManUpdeteProdect saleManUpdeteProdect = new saleManUpdeteProdect();
            saleManUpdeteProdect.SomethingHappenedOnClose += () =>
            {
                refreshProducts();
            };
            saleManUpdeteProdect.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            try
            {
                int id;
                if (int.TryParse(textBox1.Text, out id))
                {
                    var product = _bl.Product.Read(s => s.Code == id);
                    productList.Items.Clear();
                    if (product != null)
                        productList.Items.Add(product);
                    else
                        MessageBox.Show("לא נמצאה מוצר עם מזהה זה.");
                }
                else
                {
                    MessageBox.Show("אנא הזן מזהה תקין לסינון.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בסינון: " + ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void salesManProductMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
