using BlApi;
using System;
using System.Linq;
using System.Windows.Forms;
using BO;

namespace GUI
{
    public partial class saleManAddCustomer : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();
        public event Action? SomethingHappenedOnClose;

        public saleManAddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
                    {
                        MessageBox.Show("אנא מלא את כל השדות לפני הוספת הלקוח.", "שדות חסרים", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                // יצירת לקוח חדש
                Client c = new Client
                {
                    Id = int.Parse(textBox1.Text),
                    CustomerName = textBox2.Text,
                    Address = textBox3.Text,
                    PhoneNumber = textBox4.Text
                };

                _bl.client.Create(c);

                MessageBox.Show("הלקוח נוסף בהצלחה!");
                SomethingHappenedOnClose?.Invoke(); // מודיע לטופס הראשי לעדכן

                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("אנא ודא שכל השדות הוזנו כראוי .");
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בהוספת לקוח: " + ex.Message);
            }
        }

        private void saleManAddCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
