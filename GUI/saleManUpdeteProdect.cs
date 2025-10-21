
using BO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class saleManUpdeteProdect : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();
        private bool isLoaded = false; // כדי לדעת מתי המוצרים כבר נטענו

        public event Action? SomethingHappenedOnClose;
        public Product Product { get; set; }

        public saleManUpdeteProdect()
        {
            InitializeComponent();
            LoadProducts(); // נטעין את המוצרים בזמן אתחול
        }

        private void LoadProducts()
        {
            comboBox1.DataSource = _bl.Product.ReadAll().ToList();
            comboBox1.DisplayMember = "ProductName"; // מה שמוצג למשתמש
            comboBox1.ValueMember = "Code";          // המזהה הפנימי

            isLoaded = true; // מעכשיו אפשר להאזין לבחירה
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded || comboBox1.SelectedValue == null)
                return;

            try
            {
                int id = int.Parse(comboBox1.SelectedValue.ToString());
                Product = _bl.Product.Read(id);

                textBox1.Text = Product.ProductName;
                textBox2.Text = Product.Cost.ToString();
                textBox3.Text = Product.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת פרטי המוצר: " + ex.Message);
            }
        }

        private void saleManUpdeteProdect_Load(object sender, EventArgs e)
        {
            // לא חובה להשתמש בזה כרגע, הכל ב־LoadProducts
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Product == null)
                {
                    MessageBox.Show("לא נטען מוצר לעדכון.");
                    return;
                }


                Product p = new Product
                {
                    Code = Product.Code,
                    ProductName = textBox1.Text,
                    Cost = double.Parse(textBox2.Text),
                    Count = int.Parse(textBox3.Text),
                    Category = Product.Category
                };

                _bl.Product.Update(p);
                MessageBox.Show("המוצר עודכן בהצלחה!");
                SomethingHappenedOnClose?.Invoke();
                this.Close();
            }catch (Exception ex)
            {
                MessageBox.Show("שגיאה בעדכון פרטי המוצר: " + ex.Message);

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
