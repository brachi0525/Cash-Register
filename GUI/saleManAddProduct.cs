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
    public partial class saleManAddProduct : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();
        public event Action? SomethingHappenedOnClose;

        public saleManAddProduct()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // בדיקת שם מוצר
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("אנא הזן שם מוצר.", "שדה חסר", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // בדיקת קטגוריה
                if (string.IsNullOrWhiteSpace(categoryComboBox.Text) ||
                    !Enum.TryParse(typeof(Category), categoryComboBox.Text, out object? parsedCategory))
                {
                    MessageBox.Show("אנא בחר קטגוריה תקפה למוצר.", "קטגוריה לא תקינה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Product p = new Product
                {
                    ProductName = textBox1.Text,
                    Cost = (double)numericUpDown2.Value,
                    Count = (int)numericUpDown1.Value,
                    Category = (Category)parsedCategory
                };

                _bl.Product.Create(p);
                MessageBox.Show("המוצר נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SomethingHappenedOnClose?.Invoke(); // להפעיל את האירוע

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בהוספת מוצר:\n" + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void saleManAddProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
