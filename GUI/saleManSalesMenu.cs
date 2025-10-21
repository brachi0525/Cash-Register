using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class saleManSalesMenu : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();

        public saleManSalesMenu()
        {
            InitializeComponent();
            foreach (var sale in _bl.Sale.ReadAll())
            {
                saleList.Items.Add(sale);
            }
        }
        public void refreshSales()
        {
            saleList.Items.Clear();

            foreach (var sale in _bl.Sale.ReadAll())
            {
                saleList.Items.Add(sale);
            }
        }

        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            saleManDeleteSale saleManDeleteSale = new saleManDeleteSale();
            saleManDeleteSale.SomethingHappenedOnClose += () =>
            {
                refreshSales();
            };
            saleManDeleteSale.ShowDialog();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            saleManUpdeteSale saleManUpdeteSale = new saleManUpdeteSale();
            saleManUpdeteSale.SomethingHappenedOnClose += () =>
            {
                refreshSales();
            };
            saleManUpdeteSale.ShowDialog();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            saleManAddSale saleManAddSale = new saleManAddSale();
            saleManAddSale.SomethingHappenedOnClose += () =>
            {
                refreshSales();
            };
            saleManAddSale.ShowDialog();

        }
        public void refreshCustomers()
        {
            try
            {
                var customers = _bl.client.ReadAll().ToList();
                saleList.DataSource = null; // מאפס קודם
                saleList.DataSource = customers;
                saleList.DisplayMember = "CustomerName";
                saleList.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הלקוחות: " + ex.Message);
            }
        }

        private void saleManSalesMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
