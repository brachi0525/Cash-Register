using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class customerMenu : Form
    {
        //static readonly Bl._bl = Bl.Factory.Get();

        public customerMenu()
        {
            InitializeComponent();
        }

        private void addproduct(object sender, EventArgs e)
        {
         Form form = new Form();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
