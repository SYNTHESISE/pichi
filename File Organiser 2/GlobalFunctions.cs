using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace File_Organiser_2
{
    public class GlobalFunctions
    {
        public static String getHTML(string url)
        {
            String returnSring = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                returnSring = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return returnSring;
        }

        public static String editFilename(string fileName)
        {
            String s = fileName;
            if (s.Contains("."))
                s = s.Substring(0, s.LastIndexOf("."));
            s = s.Replace(". ", " ");

            s = s.Replace(".avi", "");
            s = s.Replace(" avi", "");
            s = s.Replace("avi.", "");
            s = s.Replace("avi ", "");

            s = s.Replace("_", " ");
            s = s.Replace(".", " ");

            s = s.Replace("MP4", " ");
            s = s.Replace("mp4", " ");
            s = s.Replace("Mp4", " ");
            s = s.Replace("mP4", " ");

            s = s.Replace("AVI", " ");

            s = s.Replace("720p", " ");
            s = s.Replace("720P", " ");

            s = s.Replace("DivX", " ");
            s = s.Replace("DIVX", " ");
            s = s.Replace("divx", " ");
            s = s.Replace("Divx", " ");

            s = s.Replace("Xvid", " ");
            s = s.Replace("xvid", " ");
            s = s.Replace("XviD", " ");
            s = s.Replace("XVID", " ");
            s = s.Replace("1080p", " ");
            s = s.Replace("BDRip", " ");
            s = s.Replace("DVDRip", " ");
            s = s.Replace("BrRip", " ");
            s = s.Replace("BRRiP", " ");
            s = s.Replace("DvDrip", " ");

            s = s.Replace("HDRip", " ");
            s = s.Replace("HDrip", " ");
            s = s.Replace("HDRIP", " ");
            s = s.Replace("hdrip", " ");
            s = s.Replace("HdRip", " ");

            s = s.Replace("s4a", "");

            s = s.Replace("DVDRiP", " ");
            s = s.Replace("XViD", " ");
            s = s.Replace("dvd", " ");
            s = s.Replace("divx", " ");
            s = s.Replace(" rip", " ");
            s = s.Replace("rip ", " ");


            s = s.Replace("DvDRip", " ");
            s = s.Replace("DvD", " ");
            s = s.Replace("FxM", " ");
            s = s.Replace("aXXo", " ");

            s = s.Replace("WEB-DL", " ");


            //bad neighbours
            s = s.Replace("WEBRip HC", "");
            s = s.Replace("WEBRip", "");

            //drive
            s = s.Replace(" SCR", "");

            //dumb and dumber, cable guy, titan AE, leaving las vegas, one flew ovet he cuckoos nest
            s = s.Replace("KLAXXON", "");

            //free birds, moneyball, moonrise kingdom, this is the end, vanashing point, 
            s = s.Replace("BRRip", "");

            //harriet the spy
            s = s.Replace("S3RiAL", "");

            //her, wolf of wall st, wreck it ralph
            s = s.Replace("DVDSCR", "");

            //hulk
            s = s.Replace(" iNTERNAL", "");

            //kickass, oz the great and powerful
            s = s.Replace("BRRip", "");


            //kickass, 12 monkeys, oz the great and powerful, 
            
            foreach (String item in s.Split(' '))
            {
                if (item.Trim().StartsWith("x264") | item.Trim().StartsWith("X264"))
                {
                    s = s.Replace(item, "");
                }
            }
            s = s.Replace("x264", "");
            s = s.Replace("X264", "");

            //life after beth
            s = s.Replace("WEBRip", "");

            //lost in translation, 
            s = s.Replace("BluRay", "");

            //one flew over the cuckoos nest
            s = s.Replace("DVDRIP", "");

            //The darwin awards
            s = s.Replace(" NORDIC", "");


            //12 monkeys (series)
            s = s.Replace(" HDTV", "");

            s = s.Replace("&", "+");



            if (s.Contains("["))
            {
                s = s.Substring(0, s.IndexOf("["));
            }

            if (s.Contains("{"))
            {
                s = s.Substring(0, s.IndexOf("{"));
            }

            if (s.Contains("("))
            {
                s = s.Substring(0, s.IndexOf("("));
            }

            if (s.Contains("  "))
            {
                s = s.Substring(0, s.IndexOf("  "));
            }

            s = s.Replace("-", "");


            if (s.EndsWith("taste"))
            {
                s = s.Substring(0, s.Length - "taste".Length);
            }

            if (s.EndsWith(" SWEDISH"))
            {
                s = s.Substring(0, s.Length - " SWEDISH".Length);
            }

            if (s.EndsWith(" RETAIL"))
            {
                s = s.Substring(0, s.Length - " RETAIL".Length);
            }


            //REMOVE SEASON AND EPISODE NUMBER
            string season = null;
            string episode = null;
            bool success = false;
            string filename = s;

            //S04E01
            Regex regX = new Regex("S(?<season>\\d{1,2})E(?<episode>\\d{1,2})");
            Match match = regX.Match(filename);

            if (match.Success)
            {
                try
                {
                    s = s.Replace(s.Substring(match.Index, match.Length), "");
                    success = true;
                }
                catch (Exception ex)
                {
                }
            }

            if (!success)
            {
                //Season 4 Episode 1
                Regex regX1 = new Regex("SEASON (?<season>\\d{1,2}) EPISODE (?<episode>\\d{1,2})");
                Match match1 = regX1.Match(filename);

                if (match1.Success)
                {
                    try
                    {
                        s = s.Replace(s.Substring(match.Index, match.Length), "");
                        success = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }

            }


            if (!success)
            {
                //4x01
                Regex regX1 = new Regex("(?<season>\\d{1,2})X(?<episode>\\d{1,2})");
                Match match1 = regX1.Match(filename);

                if (match1.Success)
                {
                    try
                    {
                        s = s.Replace(s.Substring(match.Index, match.Length), "");
                        success = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }

            }

            if (!success)
            {
                //401
                Regex regX4 = new Regex("(?<season>\\d{1})(?<episode>\\d{2})");
                Match match1 = regX4.Match(filename);

                if (match1.Success)
                {
                    try
                    {
                        s = s.Replace(s.Substring(match.Index, match.Length), "");
                        success = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            if (!success)
            {
                //Season 4 - Episode 1
                Regex regX4 = new Regex("SEASON (?<season>\\d{1,2}) - EPISODE (?<episode>\\d{1,2})");
                Match match1 = regX4.Match(filename);

                if (match1.Success)
                {
                    try
                    {
                        s = s.Replace(s.Substring(match.Index, match.Length), "");
                        success = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }


            if (!success)
            {
                //4-01
                Regex regX4 = new Regex("(?<season>\\d{1,2})-(?<episode>\\d{1,2})");
                Match match1 = regX4.Match(filename);

                if (match1.Success)
                {
                    try
                    {
                        s = s.Replace(s.Substring(match.Index, match.Length), "");
                        success = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return s;

        }

        public static bool isVideoFile(string filePath)
        {
            List<String> validExtensions = new List<string>();
            validExtensions.Add(".webm");
            validExtensions.Add(".flv");
            //validExtensions.Add(".vob");
            validExtensions.Add(".ogv");
            validExtensions.Add(".ogg");
            validExtensions.Add(".drc");
            validExtensions.Add(".avi");
            validExtensions.Add(".mov");
            validExtensions.Add(".qt");
            validExtensions.Add(".wmv");
            validExtensions.Add(".yuv");
            validExtensions.Add(".rm");
            validExtensions.Add(".rmvb");
            validExtensions.Add(".asf");
            validExtensions.Add(".amv");
            validExtensions.Add(".mp4");
            validExtensions.Add(".m4v");
            validExtensions.Add(".mpg");
            validExtensions.Add(".mp2");
            validExtensions.Add(".mpeg");
            validExtensions.Add(".mpe");
            validExtensions.Add(".mpv");
            validExtensions.Add(".3gp");
            validExtensions.Add(".avi");
            validExtensions.Add(".mp4");
            validExtensions.Add(".mkv");
            validExtensions.Add(".divx");
            validExtensions.Add(".m4v");
            validExtensions.Add(".avi");
            validExtensions.Add(".flv");
            validExtensions.Add(".mp4");
            
            String extension = filePath.Substring(filePath.LastIndexOf(".")).ToLower();
            return validExtensions.Contains(extension);
        }

        public static bool isImageFile(String filePath)
        {
            List<String> validExtensions = new List<string>();
            validExtensions.Add(".jpg");
            validExtensions.Add(".jpeg");
            validExtensions.Add(".bmp");
            validExtensions.Add(".png");
            validExtensions.Add(".tiff");
            validExtensions.Add(".gif");

            String extension = filePath.Substring(filePath.LastIndexOf(".")).ToLower();
            return validExtensions.Contains(extension);
        }
        public static String getTheMovieDbKeyFromGoogle(String movie)
        {
            return getTheMovieDbKeyFromBing(movie);
            //String name = movie;
            //if (name.Contains("."))
            //{
            //    name = name.Substring(0, name.LastIndexOf("."));
            //}
            //name = editFilename(name).Replace(" ", "+");
            //String query = ("http://www.google.com/search?q=" + name + " site:themoviedb.org");
            //string readID = getHTML(query);
            //readID = readID.Substring(readID.IndexOf("https://www.themoviedb.org/movie/") + "https://www.themoviedb.org/movie/".Length);
            //readID = readID.Substring(0, readID.IndexOf("-"));
            //return readID;
        }

        public static String getTheMovieDbKeyFromBing(String movie)
        {
            String name = movie;
            name = editFilename(name).Replace(" ", "+");
            String query = ("https://www.bing.com/search?q=" + name + " site%3Athemoviedb.org");
            string readID = getHTML(query);
            readID = readID.Substring(readID.IndexOf("https://www.themoviedb.org/movie/") + "https://www.themoviedb.org/movie/".Length);
            readID = readID.Substring(0, readID.IndexOf("-"));
            try
            {
                int.Parse(readID);
                return readID;
            }
            catch
            {
                return "";
            }
            
            
        }

        public static String stripNonNumericChars(String value)
        {
            String s = Regex.Replace(value, "[^.0-9]", "");
            if (s.Length == 0)
            {
                return "0";
            }
            return s;
            
        }

    }
    
    public class MovieComparer
    {
        public enum COMPARE
        {
            TITLE,
            YEAR,
            RUNNING_TIME,
            RATING,
            RECENTLY_ADDED,
            RECENTLY_WATCHED
        }

        public class LexicographicalComparator : IComparer<MovieBean>
        {
            public int Compare(MovieBean a, MovieBean b)
            {
                //this is the only comparator that uses a compareTo b, all the others are reversed to have the 'highest' at the top
                //lexicographically, we want 'A' at the top, so we use a compareTo b.
                return a.getTitle().CompareTo(b.getTitle());
            }
        }

        public class YearComparer : IComparer<MovieBean>
        {
            public int Compare(MovieBean a, MovieBean b)
            {
                return b.releaseDate.CompareTo(a.releaseDate);
            }
        }

        public class RunningTimeComparer : IComparer<MovieBean>
        {
            public int Compare(MovieBean a, MovieBean b)
            {
                return b.runtime.CompareTo(a.runtime);
            }
        }

        public class RatingComparer : IComparer<MovieBean>
        {
            public int Compare(MovieBean a, MovieBean b)
            {
                return b.voteAverage.CompareTo(a.voteAverage);
            }
        }

        public class RecentlyAddedComparer : IComparer<MovieBean>
        {
            public int Compare(MovieBean a, MovieBean b)
            {
                return b.dateAdded.CompareTo(a.dateAdded);
            }
        }

        public class RecentlyWatchedComparer : IComparer<MovieBean>
        {
            public int Compare(MovieBean a, MovieBean b)
            {
                return b.watchedDates.Last().CompareTo(a.watchedDates.Last());
            }
        }
    }
}
