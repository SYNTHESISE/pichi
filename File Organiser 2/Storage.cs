using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace File_Organiser_2
{
    public class Storage
    {
        public List<MovieBean> movies;
        public List<String> collections = new List<String>();
        public List<String> genres = new List<string>();
        public List<String> productionCompanies = new List<string>();
        public List<String> languages = new List<string>();
        public List<String> actors = new List<string>();
        public List<String> directors = new List<string>();

        public MovieComparer.COMPARE comparer;
        public int getUniqueID;
        
        
        public void insertMovie(MovieBean oldMovie, MovieBean newMovie)
        {
            newMovie.dateAdded = oldMovie.dateAdded;
            newMovie.fileName = oldMovie.fileName;
            newMovie.fullPath = oldMovie.fullPath;
            newMovie.uniqueID = oldMovie.uniqueID;
            newMovie.watched = oldMovie.watched;
            newMovie.watchedDates = oldMovie.watchedDates;

            movies.Remove(oldMovie);
            movies.Add(newMovie);

        }

    #region "Serialization"

    public bool readFile()
    {
        try
        {
            String applicationFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Application.ProductName;
            StreamReader objectStreamReader = new StreamReader(applicationFolder + "\\Data.xml");
            Storage newObject = new Storage();
            XmlSerializer x = new XmlSerializer(this.GetType());
            newObject = (Storage)x.Deserialize(objectStreamReader);

            movies = newObject.movies;
            collections = newObject.collections;
            genres = newObject.genres;
            productionCompanies = newObject.productionCompanies;
            languages = newObject.languages;
            actors = newObject.actors;
            directors = newObject.directors;

            comparer = newObject.comparer;
            getUniqueID = newObject.getUniqueID;

            objectStreamReader.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    //Serialize Data
    public void writeFile()
    {
        try
        {
            //serialize 'Data.xml' to appdata
            String applicationFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Application.ProductName;
            Directory.CreateDirectory(applicationFolder);
            StreamWriter objectStreamWriter = new StreamWriter(applicationFolder + "\\Data.xml");
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(objectStreamWriter, this);
            objectStreamWriter.Close();

            //TODO: Backup system maybe?
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
#endregion

    }
}
