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
    public partial class saleManMenu : Form
    {
        public saleManMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saleManSalesMenu saleManSalesMenu = new saleManSalesMenu();
            saleManSalesMenu.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            salesManProductMenu salesManProductMenu = new salesManProductMenu();
            salesManProductMenu.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saleManCustomerMenu saleManCustomerMenu = new saleManCustomerMenu();
            saleManCustomerMenu.ShowDialog();
        }

        private void saleManMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
