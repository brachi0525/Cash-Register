using BlApi;
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
    public partial class saleManCustomerMenu : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();

        public saleManCustomerMenu()
        {
            InitializeComponent();
            foreach (var client in _bl.client.ReadAll())
            {
                listBox1.Items.Add(client);
            }
        }
        public void refreshClient()
        {
            listBox1.Items.Clear();

            foreach (var client in _bl.client.ReadAll())
            {
                listBox1.Items.Add(client);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            saleManAddCustomer saleManAddCustomer = new saleManAddCustomer();
            saleManAddCustomer.SomethingHappenedOnClose += () =>
            {
                refreshClient();
            };
            saleManAddCustomer.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaleManDeleteCustomer saleManDeleteCustomer = new SaleManDeleteCustomer();
            saleManDeleteCustomer.SomethingHappenedOnClose += () =>
            {
                refreshClient();
            };
            saleManDeleteCustomer.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaleManUpdateCustomer saleManUpdateCustomer = new SaleManUpdateCustomer();
            saleManUpdateCustomer.SomethingHappenedOnClose += () =>
            {
                refreshClient();
            };
            saleManUpdateCustomer.ShowDialog();
        }

        private void saleManCustomerMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
