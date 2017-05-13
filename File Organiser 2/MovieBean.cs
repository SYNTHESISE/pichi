using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using AForge.Video;
using AForge.Video.FFMPEG;
using System.Windows.Forms;

namespace File_Organiser_2
{
    public class MovieBean
    {
        public enum FIELD
        {
            FULL_PATH,
            FILENAME,
            WATCHED,
            DATE_ADDED,
            WATCHED_DATES,
            UNIQUE_ID,
            ADULT,
            BACKDROP_PATH,
            BELONGS_TO_COLLECTION,
            BUDGET,
            GENRES,
            ID,
            IMDB_ID,
            ORIGINAL_LANGUAGE,
            ORIGINAL_TITLE,
            OVERVIEW,
            POPULARITY,
            POSTER_PATH,
            PRODUCTION_COMPANIES,
            RELEASE_DATE,
            REVENUE,
            RUNTIME,
            SPOKEN_LANGUAGES,
            STATUS,
            TAGLINE,
            TITLE,
            VOTE,
            ACTORS,
            CREW,
            DIRECTORS
        }

        #region "Variables"
        public string fullPath;
        public string fileName;                                                             //label at top of scree
        public bool watched;                                                                //check mark before title if watched
        public System.DateTime dateAdded;
        public List<System.DateTime> watchedDates = new List<System.DateTime>();

        public string uniqueID = "";
        public bool adult;                                                                  //title in pink
        public string backdropPath;                                                         //background image
        public String belongsToCollection;                                     //smaller text underneath title '<collectionName> collection
        public int budget;
        public List<String> genres = new List<String>();                //ACTION | THRILLER | CRIME | COMEDY    underneath the title/collection
        public String id;
        public string imdbID;
        public string originallanguage;
        public string originalTitle;
        public string overview;                                                             //the main portion, should have the whole text i guess
        public decimal popularity;
        public string posterPath;                                                           //poster image
        public List<String> productionCompanies;
        public System.DateTime releaseDate = DateTime.MinValue;                                                 //underneath genres
        public int revenue;
        public int runtime;                                                                 //in line with release date
        public List<string> spokenLanguages;
        public string status;
        public string tagline;                                                              
        public string title;
        public decimal voteAverage;                                                         //
        public List<Movie_DB_ID_Name> cast;
        public List<Movie_DB_ID_Name> crew;
        #endregion

        #region "Constructors"
        public MovieBean(bool newAdult,
            string newBackdtopPath,
            String newBelongsToCollection,
            int newBudget,
            List<String> newGenres,
            String newID, string newIMDB_ID,
            string newOriginalLanguage,
            string newOriginalTitle,
            string newOverview,
            decimal newPopularity,
            string newPosterPath,
            List<String> newProductionCompanies,
            System.DateTime newReleaseDate,
            int newRevenue, int newRuntime,
            List<string> newSpokenLanguages,
            string newStatus, string newTagline,
            string newTitle, decimal newVoteAverage,
            List<Movie_DB_ID_Name> newCast,
            List<Movie_DB_ID_Name> newCrew)
        {
            adult = newAdult;
            backdropPath = newBackdtopPath;
            belongsToCollection = newBelongsToCollection;
            budget = newBudget;
            genres = newGenres;
            id = newID;
            imdbID = newIMDB_ID;
            originallanguage = newOriginalLanguage;
            originalTitle = newOriginalTitle;
            overview = newOverview;
            popularity = newPopularity;
            posterPath = newPosterPath;
            productionCompanies = newProductionCompanies;
            releaseDate = newReleaseDate;
            revenue = newRevenue;
            runtime = newRuntime;
            spokenLanguages = newSpokenLanguages;
            status = newStatus;
            tagline = newTagline;
            title = newTitle;
            voteAverage = newVoteAverage;
            cast = newCast;
            crew = newCrew;
        }

        public MovieBean()
        {
            //NO-ARG CONSTRUCTOR
            genres = new List<String>();
            releaseDate = new DateTimePicker().MinDate;
            productionCompanies = new List<String>();
            spokenLanguages = new List<string>();
            cast = new List<Movie_DB_ID_Name>();
            crew = new List<Movie_DB_ID_Name>();
        }

        public MovieBean merge(MovieBean movieBean)
        {
            movieBean.fullPath = fullPath;
            movieBean.fileName = fileName;
            movieBean.watched = watched;
            movieBean.dateAdded = dateAdded;
            movieBean.watchedDates = watchedDates;
            movieBean.uniqueID = uniqueID;
            return movieBean;
        }
        #endregion

        public void setup(string filePath, String uniqueID)
        {
            FileInfo f = new FileInfo(filePath);
            fullPath = f.FullName;
            fileName = f.Name;
            dateAdded = DateTime.Now;
            this.uniqueID = uniqueID;
            uniqueID += 1;
        }

        public Object get(FIELD field)
        {
            switch (field) {
                case FIELD.ADULT:
                    return adult;

                case FIELD.BACKDROP_PATH:
                    return backdropPath;

                case FIELD.BELONGS_TO_COLLECTION:
                    return belongsToCollection;

                case FIELD.BUDGET:
                    return budget;

                case FIELD.ACTORS:
                    List<String> actors = new List<string>();
                    foreach(MovieBean.Movie_DB_ID_Name a in cast)
                    {
                        actors.Add(a.id);
                    }
                    return actors;

                case FIELD.DIRECTORS:
                    List<String> directors = new List<string>();
                    foreach (MovieBean.Movie_DB_ID_Name d in crew)
                    {
                        if (d.name.Equals("Director"))
                        {
                            directors.Add(d.id);
                        }
                    }
                    return directors;

                case FIELD.CREW:
                    return crew;

                case FIELD.DATE_ADDED:
                    return dateAdded;

                case FIELD.FILENAME:
                    return fileName;

                case FIELD.FULL_PATH:
                    return fullPath;

                case FIELD.GENRES:
                    return genres;

                case FIELD.ID:
                    return id;

                case FIELD.IMDB_ID:
                    return imdbID;

                case FIELD.ORIGINAL_LANGUAGE:
                    return originallanguage;

                case FIELD.ORIGINAL_TITLE:
                    return originalTitle;

                case FIELD.OVERVIEW:
                    return overview;

                case FIELD.POPULARITY:
                    return popularity;

                case FIELD.POSTER_PATH:
                    return posterPath;

                case FIELD.PRODUCTION_COMPANIES:
                    return productionCompanies;

                case FIELD.RELEASE_DATE:
                    return releaseDate;

                case FIELD.REVENUE:
                    return revenue;

                case FIELD.RUNTIME:
                    return runtime;

                case FIELD.SPOKEN_LANGUAGES:
                    return spokenLanguages;

                case FIELD.STATUS:
                    return status;

                case FIELD.TAGLINE:
                    return tagline;

                case FIELD.TITLE:
                    return title;

                case FIELD.UNIQUE_ID:
                    return uniqueID;

                case FIELD.VOTE:
                    return voteAverage;

                case FIELD.WATCHED:
                    return watched;

                case FIELD.WATCHED_DATES:
                    return watchedDates;
            }
            return "";
        }

        public String getTitle()
        {
            if(title == null || title.Equals(""))
            {
                return fileName;
            }
            return title;
        }

        public Bitmap generateBackdrop()
        {
            //throw new NotImplementedException();
            VideoFileReader reader = new AForge.Video.FFMPEG.VideoFileReader();
            reader.Open(fullPath);
            int frame = 3000;
            if(frame > reader.FrameCount)
            {
                frame = (int)(reader.FrameCount / 2);
            }
            for(int i = 0; i <frame; i++)
            {
                Bitmap b = reader.ReadVideoFrame();
                b.Dispose();
                //reader.ReadVideoFrame();

            }
            return reader.ReadVideoFrame();
        }

        public Bitmap generateOverviewImages()
        {
            //throw new NotImplementedException();
            VideoFileReader reader = new VideoFileReader();
            reader.Open(fullPath);
            List<Bitmap> images = new List<Bitmap>();
            for(int i = 0; i < reader.FrameCount; i++)
            {
                Bitmap b = reader.ReadVideoFrame();
                if(i % (reader.FrameCount/8) == 0)
                {
                    images.Add(b);
                }
                else
                {
                    b.Dispose();
                }
            }
            int origWidth = images[0].Width;
            int origHeight = images[0].Height;

            int newWidth = images[0].Width * 2;
            int newHeight = images[0].Height * 4;
            Bitmap composite = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(composite);
            g.DrawImage(images[0], new Point(0, 0));
            g.DrawImage(images[1], new Point(origWidth, 0));

            g.DrawImage(images[2], new Point(0, origHeight));
            g.DrawImage(images[3], new Point(origWidth, origHeight));

            g.DrawImage(images[4], new Point(0, origHeight * 2));
            g.DrawImage(images[5], new Point(origWidth, origHeight * 2));

            g.DrawImage(images[6], new Point(0, origHeight * 3));
            g.DrawImage(images[7], new Point(origWidth, origHeight * 3));

            return composite;

        }
        
        public String toString()
        {
            return fullPath;
        }



        public class Movie_DB_Collection
        {
            public string id;
            public string name;
            public string poster_path;

            public string backdrop_path;
            public Movie_DB_Collection()
            {
                //NO-ARG CONSTRUCTOR
            }

            public Movie_DB_Collection(string newId, string newName, string posterPath, string backdropPath)
            {
                id = newId;
                name = newName;
                poster_path = posterPath;
                backdrop_path = backdropPath;
            }

            public String toString()
            {
                return name;
            }
        }

        public class Movie_DB_ID_Name
        {
            public string id;

            public string name;
            public Movie_DB_ID_Name()
            {//NO-ARG CONSTRUCTOR
            }

            public Movie_DB_ID_Name(string newId, string newName)
            {
                id = newId;
                name = newName;
            }
        }
        
    }
}