using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Organiser_2
{
    class ImageHandler
    {
       private static String applicationFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Application.ProductName;

        public static String savePoster(MovieBean movie, string url)
        {
            if(url != "")
            {
                url = "https://image.tmdb.org/t/p/w640" + url;
                dynamic tempImage = new Bitmap(new System.IO.MemoryStream(new System.Net.WebClient().DownloadData(url)));
                string filename = applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\" + "Poster.jpg";
                System.IO.Directory.CreateDirectory(applicationFolder + "\\MOVIES\\" + movie.uniqueID);

                if (!File.Exists(applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\" + "Poster.jpg"))
                {
                    tempImage.Save(filename);
                }
                return filename;
            }
            return "";
        }

        public static Bitmap getPoster(MovieBean movie)
        {
            try
            {
                if (File.Exists(applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\" + "Custom_Poster.jpg"))
                {
                    return new Bitmap(applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\Custom_Poster.jpg");
                }
                else
                {
                    return new Bitmap(applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\Poster.jpg");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static String saveBackdrop(MovieBean movie, string url)
        {
            if (url != "")
            {
                url = "https://image.tmdb.org/t/p/w640" + url;
                dynamic tempImage = new Bitmap(new System.IO.MemoryStream(new System.Net.WebClient().DownloadData(url)));
                string filename = applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\" + "Backdrop.jpg";
                System.IO.Directory.CreateDirectory(applicationFolder + "\\MOVIES\\" + movie.uniqueID);

                if (!File.Exists(applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\" + "Backdrop.jpg"))
                {
                    tempImage.Save(filename);
                }
                return filename;
            }
            return "";
        }

        public static Bitmap getBackdrop(MovieBean movie)
        {
            try
            {
                if (File.Exists(applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\" + "Custom_Backdrop.jpg"))
                {
                    return new Bitmap(applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\Custom_Backdrop.jpg");
                }
                else
                {
                    return new Bitmap(applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\Backdrop.jpg");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static String saveCustomBackdrop(MovieBean movie, String path)
        {
            try
            {
                if (GlobalFunctions.isImageFile(path))
                {
                    Bitmap image = new Bitmap(path);
                    string filename = applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\" + "Custom_Backdrop.jpg";
                    System.IO.Directory.CreateDirectory(applicationFolder + "\\MOVIES\\" + movie.uniqueID);
                    image.Save(filename);
                    return filename;
                }
                return movie.backdropPath;
            }
            catch(Exception e)
            {
                return movie.backdropPath;
            }
        }

        public static String saveCustomPoster(MovieBean movie, String path)
        {
            try
            {
                if (GlobalFunctions.isImageFile(path))
                {
                    Bitmap image = new Bitmap(path);
                    string filename = applicationFolder + "\\MOVIES\\" + movie.uniqueID + "\\" + "Custom_Poster.jpg";
                    System.IO.Directory.CreateDirectory(applicationFolder + "\\MOVIES\\" + movie.uniqueID);
                    image.Save(filename);
                    return filename;
                }
                return movie.posterPath;
            }
            catch (Exception e)
            {
                return movie.posterPath;
            }
        }
    }
}
