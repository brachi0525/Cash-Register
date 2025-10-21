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
    public partial class SaleManDeleteCustomer : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();
        public event Action? SomethingHappenedOnClose;

        public SaleManDeleteCustomer()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                _bl.client.Delete(id);
                MessageBox.Show("המוצר נמחק בהצלחה");
                SomethingHappenedOnClose?.Invoke();
                this.Close();
            }
            catch (BO.BlInvalidCodeException ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("יש להזין מספר תקין במזהה המוצר", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה לא צפויה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaleManDeleteCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
