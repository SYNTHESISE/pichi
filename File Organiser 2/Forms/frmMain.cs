﻿using File_Organiser_2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO:
//TV Shows
namespace File_Organiser_2
{
    public partial class frmMain : Form
    {
        public static Storage files = new Storage();
        List<FilterItem> filters = new List<FilterItem>();

        public frmMain()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            files.movies = new List<MovieBean>();
            loadData();
            scanForNewMoview();
        }

        private bool loadData()
        {
            if (!files.readFile())
            {
                return false;
            }
            refreshMovies(null);
            return true;
        }


        private void refreshMovies(MovieBean selectedMovie)
        {
            lstAllMovies.Items.Clear();

            //files.movies.Sort(new MovieComparer.LexicographicalComparator());
            switch (files.comparer)
            {
                case MovieComparer.COMPARE.RATING:
                    files.movies.Sort(new MovieComparer.RatingComparer());
                    lblSortMode.Text = "sort mode: rating";
                    break;
                case MovieComparer.COMPARE.RECENTLY_ADDED:
                    files.movies.Sort(new MovieComparer.RecentlyAddedComparer());
                    lblSortMode.Text = "sort mode: recently added";
                    break;
                case MovieComparer.COMPARE.RECENTLY_WATCHED:
                    files.movies.Sort(new MovieComparer.RecentlyAddedComparer());
                    lblSortMode.Text = "sort mode: recently watched";
                    break;
                case MovieComparer.COMPARE.RUNNING_TIME:
                    files.movies.Sort(new MovieComparer.RunningTimeComparer());
                    lblSortMode.Text = "sort mode: running time";
                    break;
                case MovieComparer.COMPARE.TITLE:
                    files.movies.Sort(new MovieComparer.LexicographicalComparator());
                    lblSortMode.Text = "sort mode: title";
                    break;
                case MovieComparer.COMPARE.YEAR:
                    files.movies.Sort(new MovieComparer.YearComparer());
                    lblSortMode.Text = "sort mode: year";
                    break;
                default:
                    files.movies.Sort(new MovieComparer.LexicographicalComparator());
                    lblSortMode.Text = "sort mode: title";
                    break;
            }

            foreach (MovieBean movie in files.movies)
            {
                //if the file matches search string (if there is a search string)
                if ((txtSearch.Text != "" && (listContains(movie, movie.fileName, txtSearch.Text, StringComparison.OrdinalIgnoreCase) || (movie.title != null && listContains(movie, movie.title, txtSearch.Text, StringComparison.OrdinalIgnoreCase)))) || txtSearch.Text == "")
                {

                    lblFilterApplied.Text = "no filter";
                    //now check the filtering
                    bool passedFilterChecks = true;
                    foreach(FilterItem filter in filters)
                    {
                        lblFilterApplied.Text = "filter applied";
                        if (!filter.check(movie))
                        {
                            passedFilterChecks = false;
                            break;
                        }
                    }

                    if (passedFilterChecks)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Tag = movie;

                        string text = movie.title;
                        if (string.IsNullOrEmpty(text))
                            text = movie.fileName;
                        lvi.Text = text;

                        if (selectedMovie != null && movie.fullPath.Equals(selectedMovie.fullPath))
                        {
                            lvi.Selected = true;
                        }
                        lstAllMovies.Items.Add(lvi);
                    }
                }
            }
            refreshMoveiCount();
        }

        private void refreshMoveiCount()
        {
            String s = (lstAllMovies.Items.Count == 1) ? "" : "s";
            lblMovieCount.Text = lstAllMovies.Items.Count + " Movie" + s;
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                String[] myFiles;
                myFiles = (String[])e.Data.GetData(DataFormats.FileDrop);

                bool importData = false;
                if(myFiles.Length > 0)
                {
                    importData = (DialogResult.Yes == MessageBox.Show("Would you like to import data for these items?", "Import data?", MessageBoxButtons.YesNo));
                }

                Cursor = Cursors.WaitCursor;
                foreach (String file in myFiles)
                {
                    importMovie(file, importData);
                }
                Cursor = Cursors.Default;
            }
            refreshMovies(null);
        }

        private bool importMovie(string filePath, bool getData)
        {
            //don't add the file if it has already been added
            bool addFile = true;
            foreach (MovieBean movie in files.movies)
            {
                if (movie.fullPath.Equals(filePath))
                {
                    addFile = false;
                }
            }

            if (!File.Exists(filePath))
            {
                addFile = false;
            }


            if (Directory.Exists(filePath))
            {
                addFile = false;
                foreach (String file in Directory.GetFiles(filePath).Union(Directory.GetDirectories(filePath))){
                    importMovie(file, getData);
                }
            }

            if (addFile && GlobalFunctions.isVideoFile(filePath))
            {
                //create and add a MovieBean to Storage.movies
                MovieBean movie = new MovieBean();
                movie.setup(filePath, getUniqueID());
                if (getData)
                {
                    movie = movie.merge(TheMovieDB.getMovieBean(movie));
                }
                files.movies.Add(movie);
                files.addMovieScan(Path.GetDirectoryName(filePath));
                return true;
            }
            return false;
        }

        private String getUniqueID()
        {
            return files.getUniqueID++.ToString().PadLeft(8, '0');
        }

        private void lstAllMovies_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lstAllMovies.ContextMenuStrip = null;
                if (lstAllMovies.SelectedItems.Count == 1)
                {
                    contextMenuStrip1.Show(MousePosition);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            files.writeFile();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(lstAllMovies.SelectedItems.Count > 0)
            {
                refreshMovies((MovieBean)lstAllMovies.SelectedItems[0].Tag);
            }
            else
            {
                refreshMovies(null);
            }
            
            refreshMoveiCount();
        }

        public bool listContains(MovieBean movie, string target, string value, StringComparison comparison)
        {
            try
            {
                return target.IndexOf(value, comparison) >= 0;
            }
            catch
            {
                return false;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void playMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieBean movie = (MovieBean)lstAllMovies.SelectedItems[0].Tag;
            if (File.Exists(movie.fullPath))
            {
                Process.Start(movie.fullPath);
                movie.watched = true;
                movie.watchedDates.Add(new DateTime());
            }
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieBean movie = (MovieBean)lstAllMovies.SelectedItems[0].Tag;
            MovieBean newMovie = FrmManageMovie.open(movie);

            //i think there's a method in storage that i should be using instead of these 2 lines
            files.movies.Remove(movie);
            files.movies.Add(newMovie);
            refreshMovies(newMovie);
            
        }

        private void moviesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //thinking a form with a progress bar
            //send through a copieed list of movies
            //retirn a dictioanary<old movie, newMovie>
            //then here, go through the dictionary and files.insert(old, new)
            //yeah, let's try that.

            Dictionary<MovieBean, MovieBean> d = BatchMovieImporter.getImportedMovies(files.movies);
            foreach (KeyValuePair<MovieBean, MovieBean> entry in d)
            {
                frmMain.files.insertMovie(entry.Key, entry.Value);
            }
            refreshMovies(null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }
        

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFilter filterForm = new frmFilter();
            filters = filterForm.getFilters(filters);
            
            refreshMovies(null);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManage manage = new frmManage();
            manage.ShowDialog();
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieBean selectedMovie = null;
            if (lstAllMovies.SelectedItems.Count > 0)
            {
                selectedMovie = (MovieBean)lstAllMovies.SelectedItems[0].Tag;
            }
            files.comparer = MovieComparer.COMPARE.TITLE;
            refreshMovies(selectedMovie);
        }

        private void ratingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieBean selectedMovie = null;
            if (lstAllMovies.SelectedItems.Count > 0)
            {
                selectedMovie = (MovieBean)lstAllMovies.SelectedItems[0].Tag;
            }
            files.comparer = MovieComparer.COMPARE.RATING;
            refreshMovies(selectedMovie);
        }

        private void yearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieBean selectedMovie = null;
            if (lstAllMovies.SelectedItems.Count > 0)
            {
                selectedMovie = (MovieBean)lstAllMovies.SelectedItems[0].Tag;
            }
            files.comparer = MovieComparer.COMPARE.YEAR;
            refreshMovies(selectedMovie);
        }

        private void runningTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieBean selectedMovie = null;
            if (lstAllMovies.SelectedItems.Count > 0)
            {
                selectedMovie = (MovieBean)lstAllMovies.SelectedItems[0].Tag;
            }
            files.comparer = MovieComparer.COMPARE.RUNNING_TIME;
            refreshMovies(selectedMovie);
        }

        private void recentlyWatchedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieBean selectedMovie = null;
            if (lstAllMovies.SelectedItems.Count > 0)
            {
                selectedMovie = (MovieBean)lstAllMovies.SelectedItems[0].Tag;
            }
            files.comparer = MovieComparer.COMPARE.RECENTLY_WATCHED;
            refreshMovies(selectedMovie);
        }

        private void recentlyAddedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieBean selectedMovie = null;
            if (lstAllMovies.SelectedItems.Count > 0)
            {
                selectedMovie = (MovieBean)lstAllMovies.SelectedItems[0].Tag;
            }
            files.comparer = MovieComparer.COMPARE.RECENTLY_ADDED;
            refreshMovies(selectedMovie);
        }


        private void scanForNewMoview()
        {
            BackgroundWorker bgwMovieScans = new BackgroundWorker();
            bgwMovieScans.DoWork += BgwMovieScans_DoWork;
            bgwMovieScans.RunWorkerCompleted += BgwMovieScans_RunWorkerCompleted;
            bgwMovieScans.RunWorkerAsync();
        }

        private void BgwMovieScans_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            List<String> newFiles = new List<string>();
            foreach(String directory in files.movieScans)
            {
                foreach(String file in Directory.GetFiles(directory))
                {
                    if (GlobalFunctions.isVideoFile(file))
                    {
                        Boolean isNewMovie = true;
                        foreach(MovieBean movie in files.movies)
                        {
                            if(movie.fullPath == file)
                            {
                                isNewMovie = false;
                                break;
                            }
                        }

                        if (isNewMovie && !files.ignoredFiles.Contains(file))
                        {
                            newFiles.Add(file);
                        }
                    }
                }
            }
            if(newFiles.Count > 0)
            {
                bool importData = false;
                foreach(String movie in frmMovieScanImporter.getFilesToImport(newFiles, out importData))
                {
                    importMovie(movie, importData);
                }
            }
        }
        
        private void BgwMovieScans_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            refreshMovies(null);
        }
    }
}
