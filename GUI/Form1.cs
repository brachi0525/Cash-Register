namespace GUI
{
    public partial class Form1 : Form
    {
        private BlApi.IBl _bl = BlApi.Factory.Get();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientMenu clientMenu = new clientMenu();
            clientMenu.ShowDialog();
        }

        //private void InitializeComponent()
        //{

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            saleManMenu saleMan = new saleManMenu();
            saleMan.ShowDialog();
        }
    }
}
