using File_Organiser_2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Organiser_2
{
    public partial class FrmManageMovie : Form
    {
        public MovieBean movie;

        public FrmManageMovie()
        {
            InitializeComponent();
        }

        public FrmManageMovie(MovieBean newMovie)
        {
            InitializeComponent();

            movie = newMovie;
            setupScreen();
        }

        private void setupScreen()
        {
            //poster
            Bitmap poster = ImageHandler.getPoster(movie);
            if(poster != null)
            {
                pictureBox1.Image = poster;
            }

            //backdrop
            Bitmap backdrop = ImageHandler.getBackdrop(movie);
            if(backdrop != null)
            {
                //resizeImage
                Image img2 = new Bitmap(backdrop, new Size(pnlBackdrop.Width, pnlBackdrop.Height));

                //darken it
                Graphics g = Graphics.FromImage(img2);
                dynamic brush = new SolidBrush(Color.FromArgb(220, 0, 0, 0));
                g.FillRectangle(brush, new Rectangle(0, 0, pnlBackdrop.Width, pnlBackdrop.Height));

                //set the background
                pnlBackdrop.BackgroundImage = img2;
            }

            //title
            lblTitle.Text = movie.getTitle();

            //watched
            if (movie.watched)
                lblTitle.Text = "✓ " + lblTitle.Text;

            //adult
            if (movie.adult)
            {
                lblTitle.ForeColor = Color.Fuchsia;
                lblCollection.ForeColor = Color.Fuchsia;
            }
            else
            {
                lblTitle.ForeColor = Color.White;
                lblCollection.ForeColor = Color.White;
            }

            //collection
            if (movie.belongsToCollection != null)
            {
                pnlContent1.Location = new Point(7, 56);
                lblCollection.Text = movie.belongsToCollection;
                lblCollection.Location = new Point((lblTitle.Location.X + lblTitle.Width) - lblCollection.Width, lblCollection.Location.Y);
                if (lblCollection.Location.X < lblTitle.Location.X)
                    lblCollection.Location = new Point(lblTitle.Location.X, lblCollection.Location.Y);

                if (lblCollection.Location.X + lblCollection.Width > Width)
                    lblCollection.Location = new Point(this.Width - (lblCollection.Width + 15), lblCollection.Location.Y);
            }
            else
            {
                //if the movie doesnt belong to a collection, move the genres label up
                lblCollection.Text = "";
                pnlContent1.Location = new Point(pnlContent1.Location.X, lblTitle.Location.Y + lblTitle.Height);
            }

            //Genres
            lblGenres.Text = "";
            foreach (String genre in movie.genres) 
                lblGenres.Text += genre.ToUpper() + " | ";

            if(lblGenres.Text.Length > " | ".Length)
                lblGenres.Text = lblGenres.Text.Substring(0, lblGenres.Text.Length - " | ".Length);

            //release date
            lblDateAndRunningTime.Text = movie.releaseDate.Year.ToString();

            //running time
            lblDateAndRunningTime.Text += "    " + movie.runtime + " minutes";

            //rating
            lblVote.Text = movie.voteAverage.ToString();

            //actors
            lblActors.Text = "";
            for (int i = 0; i < ((movie.cast.Count < 5)? movie.cast.Count: 5); i++)
            {
                lblActors.Text += movie.cast[i].id + " (" + movie.cast[i].name + "), ";
            }
            if(lblActors.Text.Length > 0)
            {
                lblActors.Text = lblActors.Text.Substring(0, lblActors.Text.Length - 2);
            }            

            //overview
            lblOverview.Text = movie.overview;

        }

        public static MovieBean open(MovieBean newMovie)
        {
            FrmManageMovie dialog = new FrmManageMovie(newMovie);
            dialog.Text = newMovie.fileName;
            dialog.ShowDialog();

            return dialog.movie;
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            MovieBean importedMovie = TheMovieDB.getMovieBean(movie);
            
            importedMovie.dateAdded = movie.dateAdded;
            importedMovie.fileName = movie.fileName;
            importedMovie.fullPath = movie.fullPath;
            importedMovie.uniqueID = movie.uniqueID;
            importedMovie.watched = movie.watched;
            importedMovie.watchedDates = movie.watchedDates;
                        
            movie = importedMovie;
            setupScreen();
            Cursor = Cursors.Default;
        }

        private void openInTheMovieDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(movie.id != null && movie.id.Length > 0)
                Process.Start("https://www.themoviedb.org/movie/" + movie.id);
        }

        private void generateBackdropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap b = movie.generateBackdrop();
            frmImageTester.open(b);
        }

        private void generateOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap b = movie.generateOverviewImages();
            frmImageTester.open(b);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            frmEditMovieData editForm = new frmEditMovieData(movie);
            movie = editForm.getData();
            setupScreen();
            Cursor = Cursors.Default;
        }
        
    }
}
