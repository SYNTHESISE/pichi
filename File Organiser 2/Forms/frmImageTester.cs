using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Organiser_2
{
    public partial class frmImageTester : Form
    {
        public frmImageTester()
        {
            InitializeComponent();
        }

        private void frmImageTester_Load(object sender, EventArgs e)
        {

        }

        public static void open(Image i)
        {
            frmImageTester tester = new frmImageTester();
            tester.pictureBox1.Image = i;
            tester.ShowDialog();

        }
    }
}
