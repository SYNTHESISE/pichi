using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Organiser_2.Forms
{
    public partial class frmEditMovieData : Form
    {

        private MovieBean movie;

        private Size formSize = new Size(690, 664);
        private int yPos = 5;

        private Dictionary<ComboBox, TextBox> actorList = new Dictionary<ComboBox, TextBox>();

        public frmEditMovieData(MovieBean movieToEdit)
        {
            InitializeComponent();
            this.Size = formSize;

            //only way to get the panel to accept mousewheel scrolling events is to do it in code, so may as well do all scrolling events in code
            this.pnlScrollable.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
            this.pnlScrollable.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);

            movie = movieToEdit;
            
            setup();
            loadData();
        }

        //adding controls to the scrolling panel, and genres/actors/directors etc to the check list boxes and whatnot
        private void setup()
        {
            addPanel(pnlAdult);
            addPanel(pnlBackdropPath);
            addPanel(pnlCollection);
            addPanel(pnlBudget);
            addPanel(pnlGenres);
            addPanel(pnlIMDB_ID);
            addPanel(pnlOriginalLanguage);
            addPanel(pnlOriginalTitle);
            addPanel(pnlOverview);
            addPanel(pnlPopularity);
            addPanel(pnlPosterpath);
            addPanel(pnlProductionCompanies);
            addPanel(pnlReleaseDate);
            addPanel(pnlRevenue);
            addPanel(pnlRuntime);
            addPanel(pnlSpokenLanguages);
            addPanel(pnlStatus);
            addPanel(pnlTagline);
            addPanel(pnlTitle);
            addPanel(pnlVote);
            addPanel(pnlActors);
            addPanel(pnlDirectors);
            addPanel(pnlWatched);

            //add collections autocomplete combobox
            cmbCollection.Items.Clear();
            cmbCollection.AutoCompleteMode = AutoCompleteMode.Append;
            cmbCollection.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection cmbCollectionAutoComplete = new AutoCompleteStringCollection();
            foreach (String collection in frmMain.files.collections)
            {
                cmbCollection.Items.Add(collection);
                cmbCollectionAutoComplete.Add(collection);
            }
            cmbCollection.AutoCompleteCustomSource = cmbCollectionAutoComplete;

            //add genres to checkedlistbox
            clbGenres.Items.Clear();
            foreach (String genre in frmMain.files.genres)
            {
                clbGenres.Items.Add(genre);
            }

            //add production companies to checkedlistbox
            clbProductionCompanies.Items.Clear();
            foreach (String prodCompany in frmMain.files.productionCompanies)
            {
                clbProductionCompanies.Items.Add(prodCompany);
            }

            //add language options and autocomplete to combobox
            cmbOriginalLanguage.Items.Clear();
            cmbOriginalLanguage.AutoCompleteMode = AutoCompleteMode.Append;
            cmbOriginalLanguage.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection cmbLanguages = new AutoCompleteStringCollection();
            foreach (String language in frmMain.files.languages)
            {
                cmbOriginalLanguage.Items.Add(language);
                cmbLanguages.Add(language);
            }
            cmbOriginalLanguage.AutoCompleteCustomSource = cmbLanguages;

            //add languages to spoken languages checkbox
            clbSpokenLanguages.Items.Clear();
            foreach (String language in frmMain.files.languages)
            {
                clbSpokenLanguages.Items.Add(language);
            }

            //actors
            tableLayoutPanel1.RowCount = 0;

            //add diretors to the checked list box
            clbDirectors.Items.Clear();
            foreach (String director in frmMain.files.directors)
            {
                clbDirectors.Items.Add(director);
            }
        }

        //used in setup to add all the panels to the scrolling panel
        private void addPanel(Panel p)
        {
            pnlScrollable.Controls.Add(p);
            p.Location = new Point(0, yPos);
            yPos += p.Height + 10;
        }

        //populate controls with movie data
        private void loadData()
        {
            //adult
            chkAdultFilm.Checked = movie.adult;

            //backdrop path
            txtBackdropPath.Text = movie.backdropPath;

            //collection
            cmbCollection.SelectedItem = movie.belongsToCollection;

            //budget
            txtBudget.Text = String.Format("${0:n0}", movie.budget);

            //genres
            foreach (String genre in movie.genres)
            {
                clbGenres.SetItemChecked(clbGenres.Items.IndexOf(genre), true);
            }

            //imdb id
            txtIMDB_ID.Text = movie.imdbID;

            //original language
            cmbOriginalLanguage.SelectedItem = movie.originallanguage;

            //original title
            txtOriginalTitle.Text = movie.originalTitle;

            //overview
            txtOverview.Text = movie.overview;

            //popularity
            nudPopularity.Value = (int)movie.popularity;

            //posterPath
            txtPosterPath.Text = movie.posterPath;

            //production companies
            foreach (String prod in movie.productionCompanies)
            {
                clbProductionCompanies.SetItemChecked(clbProductionCompanies.Items.IndexOf(prod), true);
            }

            //release date
            dtpReleaseDate.Value = movie.releaseDate;

            //revenue
            txtRevenue.Text = String.Format("${0:n0}", movie.revenue);

            //runtime
            nudRuntime.Value = movie.runtime;

            //spoken languages
            foreach (String lang in movie.spokenLanguages)
            {
                clbSpokenLanguages.SetItemChecked(clbSpokenLanguages.Items.IndexOf(lang), true);
            }

            //status
            txtStatus.Text = movie.status;

            //tagline
            txtTagline.Text = movie.tagline;

            //title
            txtTitle.Text = movie.title;

            //vote
            nudVote.Value = movie.voteAverage;

            //actors
            foreach (MovieBean.Movie_DB_ID_Name actor in movie.cast)
            {
                addActorCharacterPair(actor.id, actor.name, false);
            }
            addActorCharacterPair("", "", false);

            //directors
            foreach (MovieBean.Movie_DB_ID_Name director in movie.crew)
            {
                if (director.name.ToUpper().Equals("DIRECTOR"))
                {
                    clbDirectors.SetItemChecked(clbDirectors.Items.IndexOf(director.id), true);
                }
            }

            //watched
            chkWatched.Checked = movie.watched;
        }

        //return a movie object populated from the controls
        public MovieBean getData()
        {
            Cursor = Cursors.Default;
            ShowDialog();
            return createMovieFromData();
        }

        private void addActorCharacterPair(String actor, String character, Boolean focus)
        {
            tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height + 50);
            tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            ComboBox actorBox = createDropDownActorList(actor);
            tableLayoutPanel1.Controls.Add(actorBox, 0, tableLayoutPanel1.RowCount - 1);
            
            TextBox characterBox = createCharacterTextBox(character);
            characterBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.characterKeyUp);
            tableLayoutPanel1.Controls.Add(characterBox, 1, tableLayoutPanel1.RowCount - 1);

            actorList.Add(actorBox, characterBox);

            if (focus)
            {
                actorBox.Focus();
            }
        }

        private ComboBox createDropDownActorList(String value)
        {
            ComboBox returnVal = new ComboBox();
            returnVal.AutoCompleteMode = AutoCompleteMode.Append;
            returnVal.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection x = new AutoCompleteStringCollection();
            foreach (String a in frmMain.files.actors)
            {
                returnVal.Items.Add(a);
                x.Add(a);
            }
            returnVal.AutoCompleteCustomSource = x;
            returnVal.Size = new Size(159, 38);
            returnVal.Text = value;
            return returnVal;
        }

        private TextBox createCharacterTextBox(String value)
        {
            TextBox returnVal = new TextBox();
            returnVal.Size = new Size(159, 38);
            returnVal.Text = value;
            return returnVal;
        }

        private MovieBean createMovieFromData()
        {
            MovieBean returnMovie = movie;

            //adult
            returnMovie.adult = chkAdultFilm.Checked;

            //backdrop path
            if (File.Exists(txtBackdropPath.Text) && !txtBackdropPath.Text.Equals(returnMovie.backdropPath))
            {
                returnMovie.backdropPath = ImageHandler.saveCustomBackdrop(returnMovie, txtBackdropPath.Text);
            }

            //collection
            returnMovie.belongsToCollection = cmbCollection.Text;
            if (!frmMain.files.collections.Contains(cmbCollection.Text) && cmbCollection.Text != "")
            {
                frmMain.files.collections.Add(cmbCollection.Text);
            }

            //budget
            int.TryParse(txtBudget.Text.Replace("$", "").Replace(",", "").Replace(".", ""), out returnMovie.budget);

            //genres
            returnMovie.genres = clbGenres.CheckedItems.Cast<String>().ToList();

            //imdb id
            returnMovie.imdbID = txtIMDB_ID.Text;

            //original language
            returnMovie.originallanguage = cmbOriginalLanguage.Text;
            if (!frmMain.files.languages.Contains(cmbOriginalLanguage.Text) && cmbOriginalLanguage.Text != "")
            {
                frmMain.files.languages.Add(cmbOriginalLanguage.Text);
            }

            //original title
            returnMovie.originalTitle = txtOriginalTitle.Text;

            //overview
            returnMovie.overview = txtOverview.Text;

            //popularity
            returnMovie.popularity = nudPopularity.Value;

            //poster path
            if (File.Exists(txtPosterPath.Text) && !txtPosterPath.Text.Equals(returnMovie.posterPath))
            {
                returnMovie.posterPath = ImageHandler.saveCustomPoster(returnMovie, txtPosterPath.Text);
            }
            
            //production companies
            returnMovie.productionCompanies = clbProductionCompanies.CheckedItems.Cast<String>().ToList();

            //release date
            returnMovie.releaseDate = dtpReleaseDate.Value;

            //revenue
            int.TryParse(txtRevenue.Text.Replace("$", "").Replace(",", "").Replace(".", ""), out returnMovie.revenue);

            //runtime
            returnMovie.runtime = (int)nudRuntime.Value;

            //spoken languages
            returnMovie.spokenLanguages = clbSpokenLanguages.CheckedItems.Cast<String>().ToList();

            //status
            returnMovie.status = txtStatus.Text;

            //tagline
            returnMovie.tagline = txtTagline.Text;

            //title
            returnMovie.title = txtTitle.Text;

            //vote
            returnMovie.voteAverage = nudVote.Value;

            //actors
            returnMovie.cast.Clear();
            foreach (KeyValuePair<ComboBox, TextBox> entry in actorList)
            {
                if(entry.Key.Text != "")
                {
                    returnMovie.cast.Add(new MovieBean.Movie_DB_ID_Name(entry.Key.Text, entry.Value.Text));
                    if (!frmMain.files.actors.Contains(entry.Key.Text))
                    {
                        frmMain.files.actors.Add(entry.Key.Text);
                    }
                }
            }

            //directors
            List<MovieBean.Movie_DB_ID_Name> removeList = new List<MovieBean.Movie_DB_ID_Name>();
            foreach(MovieBean.Movie_DB_ID_Name crewMember in returnMovie.crew)
            {
                if (crewMember.name.ToUpper().Equals("DIRECTOR"))
                {
                    removeList.Add(crewMember);
                }
            }
            foreach(MovieBean.Movie_DB_ID_Name crewMember in removeList)
            {
                returnMovie.crew.Remove(crewMember);
            }
            foreach(String director in clbDirectors.CheckedItems)
            {
                returnMovie.crew.Add(new MovieBean.Movie_DB_ID_Name(director, "Director"));
            }

            //watched
            returnMovie.watched = chkWatched.Checked;

            return returnMovie;
        }

        #region "Event Handlers"
        private void lblStatus_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ((Label)sender).ForeColor = Color.Black;
        }

        private void lblStatus_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.White;
            Cursor = Cursors.Default;
            scroll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region "Junk"
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void frmEditMovieData_Load(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion


        private void lblAdult_MouseDown(object sender, MouseEventArgs e)
        {
            pnlScrollable.AutoScrollPosition = new Point(0, 0);
            Control c = Controls.Find(((Label)sender).Name.Replace("lbl", "pnl"), true)[0];
            pnlScrollable.AutoScrollPosition = new Point(0, c.Location.Y -1);
            scroll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addActorCharacterPair("", "", true);
        }

        



        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            scroll();
        }

        private void panel1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            scroll();
        }

        private void scroll()
        {
            Control userControl = new Label();
            foreach (Control c in pnlScrollable.Controls)
            {
                if (c.Location.Y > 0 && c.Name.StartsWith("pnl"))
                {
                    userControl = c;
                    break;
                }
            }
            
            foreach(Control c in pnlSidebar.Controls)
            {
                c.ForeColor = Color.White;
                if(c.Name.ToUpper().Equals(userControl.Name.Replace("pnl", "lbl").ToUpper()))
                {
                    c.ForeColor = Color.Black;
                }
            }
        }

        private void frmEditMovieData_Shown(object sender, EventArgs e)
        {
            scroll();
        }

        private void btnBrowseBackdropPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            txtBackdropPath.Text = ofd.FileName;
        }

        
        private void characterKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                addActorCharacterPair("", "", true);
            }
        }

        private void btnPosterPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            txtPosterPath.Text = ofd.FileName;
        }

        private void txtGenreSearch_TextChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < clbGenres.Items.Count; i++)
            {
                if (clbGenres.Items[i].ToString().ToUpper().StartsWith(txtGenreSearch.Text.ToUpper()))
                {
                    clbGenres.SelectedIndex = i;
                    break;
                }
            }
        }

        private void txtProductionCompaniesSearch_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbProductionCompanies.Items.Count; i++)
            {
                if (clbProductionCompanies.Items[i].ToString().ToUpper().StartsWith(txtProductionCompaniesSearch.Text.ToUpper()))
                {
                    clbProductionCompanies.SelectedIndex = i;
                    break;
                }
            }
        }
        
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbSpokenLanguages.Items.Count; i++)
            {
                if (clbSpokenLanguages.Items[i].ToString().ToUpper().StartsWith(txtLanguagesSearch.Text.ToUpper()))
                {
                    clbSpokenLanguages.SelectedIndex = i;
                    break;
                }
            }
        }

        private void txtDirectorsSearch_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbDirectors.Items.Count; i++)
            {
                if (clbDirectors.Items[i].ToString().ToUpper().StartsWith(txtDirectorsSearch.Text.ToUpper()))
                {
                    clbDirectors.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
