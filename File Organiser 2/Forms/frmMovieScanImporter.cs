using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Organiser_2.Forms
{
    public partial class frmMovieScanImporter : Form
    {
        public frmMovieScanImporter(List<String> newMovies)
        {
            InitializeComponent();
            
            foreach(String movie in newMovies)
            {
                lstMovies.Items.Add(movie);
            }
        }

        public static List<String> getFilesToImport(List<String> newMovies, out bool importData)
        {
            frmMovieScanImporter importer = new frmMovieScanImporter(newMovies);
            importer.ShowDialog();

            List<String> returnList = new List<String>();
            int i = 0;
            foreach(String listItem in importer.lstMovies.Items)
            {
                if (importer.lstMovies.GetItemChecked(i))
                {
                    returnList.Add(listItem);
                }
                else
                {
                    frmMain.files.ignoredFiles.Add(listItem);
                }
                i++;
            }
            importData = importer.chkImportData.Checked;
            return returnList;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblCheckAll_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ((Label)sender).ForeColor = Color.Black;
        }

        private void lblCheckAll_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            ((Label)sender).ForeColor = Color.White;
        }

        private void lblCheckAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < lstMovies.Items.Count; i++)
            {
                lstMovies.SetItemChecked(i, true);
            }
        }

        private void lblCheckNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstMovies.Items.Count; i++)
            {
                lstMovies.SetItemChecked(i, false);
            }
        }
    }
}
