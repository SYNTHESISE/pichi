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
    public partial class BatchMovieImporter : Form
    {
        public Dictionary<MovieBean, MovieBean> dictionary = new Dictionary<MovieBean, MovieBean>();
        public BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        public int progress;
        public String currentMovie;

        public BatchMovieImporter()
        {
            InitializeComponent();
        }

        public static Dictionary<MovieBean, MovieBean> getImportedMovies(List<MovieBean> oldMovies)
        {
            BatchMovieImporter importer = new BatchMovieImporter();
            
            foreach(MovieBean bean in oldMovies)
            {
                importer.dictionary.Add(bean, bean);
            }

            importer.ShowDialog();
            return importer.dictionary;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label2.Text = currentMovie;
            progressBar2.Maximum = dictionary.Count;
            progressBar2.Value = progress;
        }
        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < dictionary.Count; i++)
            {
                currentMovie = dictionary.ElementAt(i).Key.fileName;
                backgroundWorker1.ReportProgress(i);
                dictionary[dictionary.ElementAt(i).Key] = TheMovieDB.getMovieBean(dictionary.ElementAt(i).Key);
                progress++;
            }
        }

        private void BatchMovieImporter_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.WorkerReportsProgress = true;

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.Dispose();
            Close();
        }

        private void BatchMovieImporter_Load(object sender, EventArgs e)
        {

        }

        private void BatchMovieImporter_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
    }
}
