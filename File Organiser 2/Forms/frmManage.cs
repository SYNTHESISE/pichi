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
    public partial class frmManage : Form
    {
        //keep track of selected label
        private Label selectedLabel = null;

        public frmManage()
        {
            InitializeComponent();

            //add data to all the lists
            refreshCollections();
            refreshGenres();
            refreshProductionCompanies();
            refreshLanguages();
            refreshActors();
            refreshDirectors();

            //put them in the right place
            resetPositions();
            
            this.Size = new Size(601, 502);

            //set the initial category
            setCategory(lblCollections.Name);
            this.selectedLabel = lblCollections;
        }

        private void resetPositions(){
            Point panelLocation = new Point(234, 0);
            pnlCollections.Location = panelLocation;
            pnlGenres.Location = panelLocation;
            pnlProductionCompanies.Location = panelLocation;
            pnlLanguages.Location = panelLocation;
            pnlActors.Location = panelLocation;
            pnlDirectors.Location = panelLocation;
        }

        private void setCategory(String field)
        {
            List<String> items = new List<string>();
            switch (field)
            {
                case "lblCollections":
                    pnlCollections.BringToFront();
                    break;
                case "lblGenres":
                    pnlGenres.BringToFront();
                    break;
                case "lblProductionCompanies":
                    pnlProductionCompanies.BringToFront();
                    break;
                case "lblLanguages":
                    pnlLanguages.BringToFront();
                    break;
                case "lblActors":
                    pnlActors.BringToFront();
                    break;
                case "lblDirectors":
                    pnlDirectors.BringToFront();
                    break;
            }
        }

        private void refreshCollections()
        {
            lstCollections.Items.Clear();
            foreach(String item in frmMain.files.collections)
            {
                lstCollections.Items.Add(item);
            }
        }

        private void refreshGenres()
        {
            lstGenres.Items.Clear();
            foreach(String item in frmMain.files.genres)
            {
                lstGenres.Items.Add(item);
            }
        }

        private void refreshProductionCompanies()
        {
            lstProductionCompanies.Items.Clear();
            foreach(String item in frmMain.files.productionCompanies)
            {
                lstProductionCompanies.Items.Add(item);
            }
        }

        private void refreshLanguages()
        {
            lstLanguages.Items.Clear();
            foreach(String item in frmMain.files.languages)
            {
                lstLanguages.Items.Add(item);
            }
        }

        private void refreshActors()
        {
            lstActors.Items.Clear();
            foreach(String item in frmMain.files.actors)
            {
                lstActors.Items.Add(item);
            }
        }

        private void refreshDirectors()
        {
            lstDirectors.Items.Clear();
            foreach(String item in frmMain.files.directors)
            {
                lstDirectors.Items.Add(item);
            }
        }

        private void searchListBox(ListBox list, String search)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].ToString().ToUpper().StartsWith(search.ToUpper()))
                {
                    list.SelectedIndex = i;
                    break;
                }
            }
        }

        #region "Event Handlers"
        #region "Labels"
        private void lblDirectors_Click(object sender, EventArgs e)
        {
            selectedLabel.ForeColor = Color.White;
            selectedLabel = (Label)sender;
            setCategory(((Label)sender).Name);
        }

        private void lblDirectors_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ((Label)sender).ForeColor = Color.Black;
        }

        private void lblDirectors_MouseLeave(object sender, EventArgs e)
        {   
            ((Label)sender).ForeColor = Color.White;
            selectedLabel.ForeColor = Color.Black;
            Cursor = Cursors.Default;
        }
        #endregion

#region "Collections"
        private void txtColleactionsSearch_TextChanged(object sender, EventArgs e)
        {
            searchListBox(lstCollections, txtColleactionsSearch.Text);
        }

        private void btnCollectionsAdd_Click(object sender, EventArgs e)
        {
            if (!frmMain.files.collections.Contains(txtCollectionssAdd.Text, StringComparer.OrdinalIgnoreCase))
            {
                frmMain.files.collections.Add(txtCollectionssAdd.Text);
                refreshCollections();
            }
            txtCollectionssAdd.Text = "";
        }

        private void btnCollectionsDelete_Click(object sender, EventArgs e)
        {
            if(lstCollections.SelectedItems.Count == 1 && MessageBox.Show("Are you sure you want to delete " + lstCollections.SelectedItem, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmMain.files.collections.Remove(lstCollections.SelectedItem.ToString());
            }
            refreshCollections();
        }
        #endregion

#region "Genres"
        private void txtGenresSearch_TextChanged(object sender, EventArgs e)
        {
            searchListBox(lstGenres, txtGenresSearch.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lstGenres.SelectedItems.Count == 1 && MessageBox.Show("Are you sure you want to delete " + lstGenres.SelectedItem, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmMain.files.genres.Remove(lstGenres.SelectedItem.ToString());
            }
            refreshGenres();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!frmMain.files.genres.Contains(txtAddGenre.Text, StringComparer.OrdinalIgnoreCase))
            {
                frmMain.files.genres.Add(txtAddGenre.Text);
                refreshGenres();
            }
            txtAddGenre.Text = "";
        }
        #endregion

#region "Production Companies"
        private void txtProductionCompanySearch_TextChanged(object sender, EventArgs e)
        {
            searchListBox(lstProductionCompanies, txtProductionCompanySearch.Text);
        }

        private void btnDeleteProductionCompany_Click(object sender, EventArgs e)
        {
            if (lstProductionCompanies.SelectedItems.Count == 1 && MessageBox.Show("Are you sure you want to delete " + lstProductionCompanies.SelectedItem, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmMain.files.productionCompanies.Remove(lstProductionCompanies.SelectedItem.ToString());
            }
            refreshProductionCompanies();
        }

        private void btnAddProductionCompany_Click(object sender, EventArgs e)
        {
            if (!frmMain.files.productionCompanies.Contains(txtAddProductionCompany.Text, StringComparer.OrdinalIgnoreCase))
            {
                frmMain.files.productionCompanies.Add(txtProductionCompanySearch.Text);
                refreshProductionCompanies();
            }
            txtAddProductionCompany.Text = "";
        }
        #endregion

#region "languages"
        private void txtLanguagesSearch_TextChanged(object sender, EventArgs e)
        {
            searchListBox(lstLanguages, txtLanguagesSearch.Text);
        }

        private void btnLanguagesDelete_Click(object sender, EventArgs e)
        {
            if (lstLanguages.SelectedItems.Count == 1 && MessageBox.Show("Are you sure you want to delete " + lstLanguages.SelectedItem, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmMain.files.languages.Remove(lstLanguages.SelectedItem.ToString());
            }
            refreshLanguages();
        }

        private void btnLanguagesAdd_Click(object sender, EventArgs e)
        {
            if (!frmMain.files.languages.Contains(txtLanguagesAdd.Text, StringComparer.OrdinalIgnoreCase))
            {
                frmMain.files.languages.Add(txtLanguagesAdd.Text);
            refreshLanguages();
            }
            txtLanguagesAdd.Text = "";
        }
        #endregion

#region "Actors"
        private void txtActorSearch_TextChanged(object sender, EventArgs e)
        {
            searchListBox(lstActors, txtActorSearch.Text);
        }

        private void btnActorDelete_Click(object sender, EventArgs e)
        {
            if (lstActors.SelectedItems.Count == 1 && MessageBox.Show("Are you sure you want to delete " + lstActors.SelectedItem, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmMain.files.actors.Remove(lstActors.SelectedItem.ToString());
            }
            refreshActors();
        }
        
        private void btnActorAdd_Click(object sender, EventArgs e)
        {
            if (!frmMain.files.actors.Contains(txtActorAdd.Text, StringComparer.OrdinalIgnoreCase))
            {
                frmMain.files.actors.Add(txtActorAdd.Text);
                refreshActors();
            }
            txtActorAdd.Text = "";
        }
        #endregion

#region "Directors"
        private void txtDirectorSearch_TextChanged(object sender, EventArgs e)
        {
            searchListBox(lstDirectors, txtDirectorSearch.Text);
        }

        private void btnDirectorDelete_Click(object sender, EventArgs e)
        {
            if (lstDirectors.SelectedItems.Count == 1 && MessageBox.Show("Are you sure you want to delete " + lstDirectors.SelectedItem, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmMain.files.directors.Remove(lstDirectors.SelectedItem.ToString());
            }
            refreshDirectors();
        }

        private void btnDirectorAdd_Click(object sender, EventArgs e)
        {
            if (!frmMain.files.directors.Contains(txtDirectorAdd.Text, StringComparer.OrdinalIgnoreCase))
            {
                frmMain.files.directors.Add(txtDirectorAdd.Text);
                refreshDirectors();
            }
            txtDirectorAdd.Text = "";

        }
#endregion
        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
#endregion
}
