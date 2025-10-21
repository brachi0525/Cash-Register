using BlApi;
using BO;
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
    public partial class saleManAddSale : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();

        public event Action? SomethingHappenedOnClose;

        public saleManAddSale()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Sale s = new Sale
                {
                    ProductID = int.Parse(textBox1.Text),
                    Count = (int)numericUpDown2.Value,
                    cost = (int)numericUpDown1.Value,
                    DateBeginSale = monthCalendar2.SelectionStart,
                    DateEndSale = monthCalendar1.SelectionStart
                };

                _bl.Sale.Create(s);
                MessageBox.Show("המבצע נוסף בהצלחה!");

                SomethingHappenedOnClose?.Invoke(); // לעדכן את המסך הקודם
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("אנא ודא שכל השדות הוזנו כראוי (מזהה מוצר כמספר).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה: " + ex.Message);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saleManAddSale_Load(object sender, EventArgs e)
        {

        }
    }
}
