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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class saleManUpdeteSale : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();
        private bool isLoaded = false; // כדי לדעת מתי המוצרים כבר נטענו
        public Sale sale { get; set; }

        public event Action? SomethingHappenedOnClose;
        public saleManUpdeteSale()
        {
            InitializeComponent();
            LoadSales();
        }
        private void LoadSales()
        {
            comboBox1.DataSource = _bl.Sale.ReadAll().ToList();
            comboBox1.DisplayMember = "Id"; // מה שמוצג למשתמש
            comboBox1.ValueMember = "Id";          // המזהה הפנימי

            isLoaded = true; // מעכשיו אפשר להאזין לבחירה
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded || comboBox1.SelectedValue == null)
                return;

            try
            {
                int id = int.Parse(comboBox1.SelectedValue.ToString());
                sale = _bl.Sale.Read(id);

                checkBox1.Checked = sale.IsClub;
                textBox2.Text = sale.cost.ToString();
                textBox3.Text = sale.Count.ToString();
                monthCalendar2.SetDate(sale.DateBeginSale);
                monthCalendar1.SetDate(sale.DateEndSale);



            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת פרטי המוצר: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sale == null)
            {
                MessageBox.Show("לא נטען מוצר לעדכון.");
                return;
            }


            Sale s = new Sale
            {
                Id = sale.Id,
                ProductID = sale.ProductID,
                cost = double.Parse(textBox2.Text),
                Count = int.Parse(textBox3.Text),
                DateBeginSale = monthCalendar2.SelectionStart,
                DateEndSale = monthCalendar1.SelectionStart

            };

            _bl.Sale.Update(s);
            MessageBox.Show("המבצע עודכן בהצלחה!");
            SomethingHappenedOnClose?.Invoke();
            this.Close();


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
