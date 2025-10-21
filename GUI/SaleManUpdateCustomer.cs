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
    public partial class SaleManUpdateCustomer : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();
        private bool isLoaded = false;
        public Client customer { get; set; }

        public event Action? SomethingHappenedOnClose;
        public SaleManUpdateCustomer()
        {
            InitializeComponent();
            LoadCustomers();

        }

        private void SaleManUpdateCustomer_Load(object sender, EventArgs e)
        {

        }
        private void LoadCustomers()
        {
            comboBox1.DataSource = _bl.client.ReadAll().ToList();
            comboBox1.DisplayMember = "CustomerName";
            comboBox1.ValueMember = "Id";
            isLoaded = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded || comboBox1.SelectedValue == null)
                return;

            try
            {
                int id = (int)comboBox1.SelectedValue;
                customer = _bl.client.Read(id);

                textBoxName.Text = customer.CustomerName;
                textBoxPhone.Text = customer.PhoneNumber;
                textBox3.Text = customer.Address.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת פרטי הלקוח: " + ex.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (customer == null)
            {
                MessageBox.Show("לא נבחר לקוח לעדכון.");
                return;
            }

            try
            {
                Client updated = new Client
                {
                    Id = customer.Id,
                    CustomerName = textBoxName.Text,
                    Address = textBox3.Text,
                    PhoneNumber = textBoxPhone.Text,

                };

                _bl.client.Update(updated);
                MessageBox.Show("הלקוח עודכן בהצלחה!");
                SomethingHappenedOnClose?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בעדכון הלקוח: " + ex.Message);
            }
        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }

        private void SaleManUpdateCustomer_Load_1(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
