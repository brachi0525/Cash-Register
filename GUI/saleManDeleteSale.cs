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
    public partial class saleManDeleteSale : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();

        public event Action? SomethingHappenedOnClose;

        public saleManDeleteSale()
        {
            InitializeComponent();
        }

        private void saleManDeleteSale_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            _bl.Sale.Delete(id);
            MessageBox.Show("המוצר נמחק בהצלחה");
            SomethingHappenedOnClose?.Invoke();
            this.Close();
        }
    }
}
