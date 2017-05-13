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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            addVersion("1.0.1");
            addWork("Implemented ability to add actors and directors to files.");//movie bean has actors, and crew (which containts directors)
            addWork("Program now supports drag & drop of files.");//done, with directory recursion and extension filtering

            addVersion("1.0.2");
            addWork("Implemented ability to add genres to files.");//done, movie bean has genres.

            addVersion("1.0.3");
            addWork("Search bar added.");//done

            addVersion("1.1.0");
            addWork("Filtering files implemented to display only files matching a rule.");

            addVersion("1.1.1");
            addWork("Implemented an 'Open in IMDB' button to aid data entry for a file.");//lol. remember when nick suggested that? and i was like, idk, that seems hard. Nicks suggestion here is what spurred this whole thing
                                                                                          //and now it's not gonna be a thing. Maybe i'll leave it in, for nostalgia


            addVersion("1.2.0");
            addWork("Implemented an 'Import from IMDB' option to further aid data entry.");//removed
            addWork("Added 'year' and 'running time' data entries for files.");//done
            addWork("Added 'year' and 'running time' in filtering.");


            addVersion("1.2.1");
            addWork("Added 'rating' data entry for files.");//done
            addWork("Added 'rating' in filtering.");


            addVersion("1.2.2");
            addWork("Added 'watched' data entry for files.");//done
            addWork("Added 'watched' in filtering.");


            addVersion("1.2.3");
            addWork("Implemented episode management (Still in Alpha Development).");


            addVersion("1.3.0");
            addWork("Improved algorithm for importing data from IMDB.");//n/a
            addWork("Added option to set your genre list to IMDB's genre list (reccomended).");
            addWork("Added 'storyline' data entry for files.");//done
            addWork("Added 'storyline' in IMDB import.");//themoviedb import now



            addVersion("1.3.1");
            addWork("Implemented Batch IMDB importing.");
            addWork("Batch IMDB importing has options to allow for automation.");



            addVersion("1.3.2");
            addWork("Improved algorithm for importing data from IMDB (again).");
            addWork("Added a backup file (If program cannot load regular file, it checks for the backup).");
            addWork("Improved algorithm for importing storyline from IMDB.");



            addVersion("1.3.3");
            addWork("Added Wikipedia importing (useful for files with no IMDB entry).");
            addWork("Improved Algorithm for batch IMDB importing.");



            addVersion("1.3.4");
            addWork("Implemented updating from withing the program.");
            addWork("Added option to add files to the program via command line arguments (full path of the file to be added).");
            addWork("Added option to close the program after command line arguments have been added(-c).");
            addWork("Improved Batch IMDB importing(including canceling).");
            addWork("Added a changelog.");
            addWork("Improved algorithm for filtering files.");
            addWork("Improved algorithm for getting directors from Wikipedia.");
            addWork("Added option to colour-code the background of 'Manage File' according to file image.");
            addWork("Implemented an easily viewable list of genres, actors and directors in 'Manage File'");
            addWork("Improved algorithm for getting storyline from IMDB.");
            addWork("Improved algorithm for getting running time from Wikipedia.");
            addWork("Improved algorithm for batch importing data from Wikipedia.");
            addWork("Added ability to set and delete a custom image for a file.");
            addWork("Added progress tracking to batch importing.");



            addVersion("1.3.5");
            addWork("Implemented sorting options to the file list.");
            addWork("When importing a file, the program will attempt to get the running time. (Works for .avi & .mp4 file extensions).");
            addWork("Batch IMDB importing will attempt to retrieve wikipedia data if it cannot find an IMDB entry.");
            addWork("Implemented an animation when switching to TV Shows view from Movies view and vice versa.");
            addWork("Improved episode management (Still in Alpha Development).");



            addVersion("1.4.0");
            addWork("Implemented file scanning for movies and TV Shows.");
            addWork("Implemented playing entire season or series with VLC.");
            addWork("Option for entering and saving location of VLC if needed.");
            addWork("Deleting a series will delete all its episodes.");
            addWork("Added IMDB importing for TV Series Data.");
            addWork("Movie File scanning will now give you the option to get IMDB data.");
            addWork("Implemented searching on TV Shows.");
            addWork("Added filtering to TV Shows(Genres, Actors & Creators only).");
            addWork("Added 'Play All From Here' context menu for episodes.");
            addWork("Fixed bugs related to creating a new series.");
            addWork("Added ability to apply and remove your own images for a movie or series.");
            addWork("Added context menu for series.");



            addVersion("1.4.1");
            addWork("Added Torrenting features for series");
            addWork("sorting algorithm to sort episodes in a series/season by episode order(based on filenames).");
            addWork("Added 'Play Selected' context menu for episodes(you can now queue more than one file in VLC).");
            addWork("Context menu on 'Series' will now allow you to play the 'Next Episode'");
            addWork("Option to scan for next episode torrent on startup(check on in series screen).");
            addWork("Now any epidoe played will be marked as such(even if playing a whole series at once). This will give better accuracy for things like 'Play Next Episde' NOTE: playing all episodes in a series at once will not mark the episodes as watched.");
            addWork("Torrenting updates.");
            addWork("Integration with Shutdown Timer 2.0 - .mkv files not supported.");
            addWork("Integration with shifT.");
            addWork("Fixed bug with episode management.");
            addWork("Fixed bug where when an episode was played, it didn't add apropriate metadata to the episode.");
            addWork("Saves the last series you were watching in memory - added for future improvements.");
            addWork("Changed the way managing an episode look and feels.Setting the season number is alot better than a text box.");
            addWork("Added a Help window to provide people with some information on how to use the software.");
            addWork("Added a movie reminder option.Type the name of the movie and you wll be reminded when it is availale to download.");
            addWork("TV Show filtering is now filtered per episode rather than per series.");



            addVersion("1.4.2");
            addWork("Added an introduction wizard to get you started - helps you import your movies and TV Shows.");
            addWork("Added a second torrent method for when the original one fails.");
            addWork("Implemented Usage Charts for visualizing different aspects of what you have in your library and how you watch them.");
            addWork("Added new Alert for a brand new series if you might be interested in it.");
            addWork("Program will continuously scan for new movies and TV Shows in your movie scanning and episode scanning lists.");
            addWork("Updated the movie management screen to be a little prettier.");
            addWork("Added 'x' buttons on the movie and TV Show search boxes for quickly cancelling searches.");
            addWork("Updated the series management screen to be consistent with movie management screen.");
            addWork("Added visual cue on the filter button to indicate if a filter is active.");
            addWork("Updated filtering windows to be consistent with the new UI style.");
            addWork("Overhaul of all windows to be consistent with the new style.");
            addWork("Adding a new series is easier and a little more advanced.");



            addVersion("1.4.3");
            addWork("Reccomendations now occur in a background thread.");
            addWork("You are now able to delete all movies by navigating to Manage>Movies>Delete All Movies");


            addVersion("1.4.4");
            addWork("Added new sorting mode(Recently Watched)");
            addWork("Added ability to set a point in a movie.If you dont finish watching a movie, set the point you were up to, and the next time you play the movie, it will be played from that point.");

            addVersion("2.0.0");
            addWork("Complete rewrite of the codebase in C# (was VB.NET)");
            addWork("TheMovieDB API usage instead of IMDB web scraping for faster, better, more accurate, and more complete information");
            addWork("filtering rewrite to accomodate all the extra data themoviedb provides");

            
        }


        private void addVersion(String version)
        {
            richTextBox1.Text += "\r\n" + version + "\r\n---------------------\r\n";
        }
        private void addWork(String task)
        {
            richTextBox1.Text += "--" + task + "\r\n";
        }
    }
}
