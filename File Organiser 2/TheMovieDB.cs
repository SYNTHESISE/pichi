using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace File_Organiser_2
{
    public class TheMovieDB
    {
        private const String THE_MOVIE_DB_API_KEY  = "c3072d4cab18326e8fb41e63a12abee3";

        public static MovieBean getMovieBean(MovieBean movie)
        {
            String searchString = GlobalFunctions.editFilename(movie.fileName);
            String TheMovieDB_ID = GlobalFunctions.getTheMovieDbKeyFromGoogle(movie.getTitle());

            if (TheMovieDB_ID.Length < 1)
                return movie;

            String movieJSON = GlobalFunctions.getHTML("https://api.themoviedb.org/3/movie/" + TheMovieDB_ID + "?api_key=" + THE_MOVIE_DB_API_KEY);
            String castJSON = GlobalFunctions.getHTML("https://api.themoviedb.org/3/movie/" + TheMovieDB_ID + "/credits?api_key=" + THE_MOVIE_DB_API_KEY);

            MovieBean importedMovie = parseJSONForBean(movieJSON, castJSON);

            importedMovie.posterPath = ImageHandler.savePoster(movie, importedMovie.posterPath);
            importedMovie.backdropPath = ImageHandler.saveBackdrop(movie, importedMovie.backdropPath);


            //add data to the storage list
            if (importedMovie.belongsToCollection != null && (!frmMain.files.collections.Contains(importedMovie.belongsToCollection)))
            {
                frmMain.files.collections.Add(importedMovie.belongsToCollection);
            }

            foreach(String genre in importedMovie.genres)
            {
                if (!frmMain.files.genres.Contains(genre))
                {
                    frmMain.files.genres.Add(genre);
                }
            }

            foreach(String prod in importedMovie.productionCompanies)
            {
                if (!frmMain.files.productionCompanies.Contains(prod))
                {
                    frmMain.files.productionCompanies.Add(prod);
                }
            }

            foreach (String lang in importedMovie.spokenLanguages)
            {
                if (!frmMain.files.languages.Contains(lang))
                {
                    frmMain.files.languages.Add(lang);
                }
            }

            foreach(MovieBean.Movie_DB_ID_Name actor in importedMovie.cast)
            {
                if (!frmMain.files.actors.Contains(actor.name))
                {
                    frmMain.files.actors.Add(actor.id);
                }
            }

            foreach(MovieBean.Movie_DB_ID_Name director in importedMovie.crew)
            {
                if (director.name.ToUpper().Equals("DIRECTOR"))
                {
                    if (!frmMain.files.actors.Contains(director.id))
                    {
                        frmMain.files.directors.Add(director.id);
                    }
                }
            }

            return importedMovie;
        }

        private static MovieBean parseJSONForBean(String json, String creditsJSON)
        {
            MovieBean returnBean = new MovieBean();
            
            JObject ser = JObject.Parse(json);
            List<JToken> data = ser.Children().ToList();

            foreach (JProperty item in data)
            {
                item.CreateReader();
                switch (item.Name)
                {
                    case "adult":
                        returnBean.adult = item.Value.Equals("False");
                        break;
                    case "backdrop_path":
                        returnBean.backdropPath = item.Value.ToString();
                        break;
                    case "belongs_to_collection":
                        try
                        {
                            returnBean.belongsToCollection = item.Value.Value<String>("name");
                        }
                        catch (Exception ex)
                        {
                            //Do Nothing - leave it as null
                        }
                        break;
                    case "budget":
                        try
                        {
                            returnBean.budget = int.Parse(item.Value.ToString());
                        }
                        catch
                        {
                            returnBean.budget = 0;
                        }
                        break;
                    case "genres":
                        foreach (JToken i in item.Value)
                        {
                            returnBean.genres.Add(i.Value<String>("name"));
                        }

                        break;
                    case "id":
                        returnBean.id = item.Value.ToString();
                        break;
                    case "original_language":
                        returnBean.originallanguage = new CultureInfo(item.Value.ToString()).DisplayName;
                        break;
                    case "overview":
                        returnBean.overview = item.Value.ToString();
                        break;
                    case "popularity":
                        try
                        {
                            returnBean.popularity = decimal.Parse(item.Value.ToString());
                        }
                        catch
                        {
                            returnBean.popularity = 0;
                        }
                        
                        break;
                    case "poster_path":
                        returnBean.posterPath = item.Value.ToString();
                        break;
                    case "production_companies":
                        foreach (JToken i in item.Value)
                        {
                            returnBean.productionCompanies.Add(i.Value<string>("name"));
                        }

                        break;
                    case "release_date":
                        try
                        {
                            returnBean.releaseDate = System.DateTime.Parse(item.Value.ToString());
                        }catch(Exception e)
                        {
                            returnBean.releaseDate = new System.Windows.Forms.DateTimePicker().MinDate;
                        }
                        
                        break;
                    case "revenue":
                        try
                        {
                            returnBean.revenue = int.Parse(item.Value.ToString());
                        }
                        catch
                        {
                            returnBean.revenue = 0;
                        }
                        break;
                    case "runtime":
                        if(item.Value.ToString() == "")
                        {
                            returnBean.runtime = 0;
                        }
                        else
                        {
                            returnBean.runtime = int.Parse(item.Value.ToString());
                        }
                        
                        break;
                    case "spoken_languages":
                        foreach (JToken i in item.Value)
                        {
                            returnBean.spokenLanguages.Add(i.Value<string>("name"));
                        }

                        break;
                    case "tagline":
                        returnBean.tagline = item.Value.ToString();
                        break;
                    case "title":
                        returnBean.title = item.Value.ToString();
                        break;
                    case "vote_average":
                        returnBean.voteAverage = Decimal.Parse(item.Value.ToString());
                        break;
                }
            }

            returnBean.cast = getAllCast(creditsJSON);
            returnBean.crew = getAllCrew(creditsJSON);

            return returnBean;
        }


        public static List<MovieBean.Movie_DB_ID_Name> getAllCast(string credits)
        {
            JObject ser = JObject.Parse(credits);
            List<JToken> data = ser.Children().ToList();

            List<MovieBean.Movie_DB_ID_Name> cast = new List<MovieBean.Movie_DB_ID_Name>();

            foreach (JProperty item in data)
            {
                item.CreateReader();
                if ((item.Name.Equals("cast")))
                {
                    foreach (JToken token in item)
                    {
                        foreach (JToken role in token)
                        {
                            cast.Add(new MovieBean.Movie_DB_ID_Name(role.Value<string>("name"), role.Value<string>("character")));
                        }
                    }
                }
            }

            return cast;
        }

        public static List<MovieBean.Movie_DB_ID_Name> getAllCrew(string credits)
        {
            JObject ser = JObject.Parse(credits);
            List<JToken> data = ser.Children().ToList();

            List<MovieBean.Movie_DB_ID_Name> crew = new List<MovieBean.Movie_DB_ID_Name>();

            foreach (JProperty item in data)
            {
                item.CreateReader();
                if ((item.Name.Equals("crew")))
                {
                    foreach (JToken token in item)
                    {
                        foreach (JToken role in token)
                        {
                            crew.Add(new MovieBean.Movie_DB_ID_Name(role.Value<string>("name"), role.Value<string>("job")));
                        }
                    }
                }
            }

            return crew;
        }
    }
}