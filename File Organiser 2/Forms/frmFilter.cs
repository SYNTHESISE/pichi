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
    public partial class frmFilter : Form
    {

        private Point contentPanelLovation = new Point(213, 0);
        private Size windowSize = new Size(599, 501);

        private List<MovieBean.Movie_DB_Collection> collections;


        public List<FilterItem> filters = new List<FilterItem>();

        
        public frmFilter()
        {
            InitializeComponent();

            this.Size = windowSize;

            setupData();
            showPanel(lblWatched.Name);
        }
        
        private void setupData()
        {
            chkCollections.Items.Clear();
            foreach(String collection in frmMain.files.collections)
            {
                chkCollections.Items.Add(collection);
            }

            chkGenres.Items.Clear();
            foreach(String genre in frmMain.files.genres)
            {
                chkGenres.Items.Add(genre);
            }

            chkDirectors.Items.Clear();
            foreach(String director in frmMain.files.directors)
            {
                chkDirectors.Items.Add(director);
            }

            chkProductionCompanies.Items.Clear();
            foreach(String prod in frmMain.files.productionCompanies)
            {
                chkProductionCompanies.Items.Add(prod);
            }

            chkSpokenLanguages.Items.Clear();
            foreach(String lang in frmMain.files.languages)
            {
                chkSpokenLanguages.Items.Add(lang);
            }

            chkActors.Items.Clear();
            foreach(String actor in frmMain.files.actors)
            {
                chkActors.Items.Add(actor);
            }
        }

        public void showPanel(String label)
        {
            //find the panel relating to the label you just clicked on, put it in the right place, and bring it to the front.
            Panel p = (Panel)Controls.Find(label.Replace("lbl", "pnl"), false)[0];
            p.Location = contentPanelLovation;
            p.BringToFront();

            //MessageBox.Show(label);
        }

        public List<FilterItem> getFilters(List<FilterItem> filters)
        {
            this.filters = filters;
            loadFilters();
            ShowDialog();
            return filters;
        } 

        public void loadFilters()
        {
            foreach(FilterItem filter in filters)
            {
                switch (filter.filterField)
                {
                    case MovieBean.FIELD.WATCHED:
                        chkWatchedEnabled.Checked = true;
                        rdoWatched.Checked = ((BooleanFilterItem)filter).filterValue;
                        rdoNotWatched.Checked = !((BooleanFilterItem)filter).filterValue;
                        break;

                    case MovieBean.FIELD.ADULT:
                        chkAdultEnabled.Checked = true;
                        rdoAdult.Checked = ((BooleanFilterItem)filter).filterValue;
                        rdoNotAdult.Checked = !((BooleanFilterItem)filter).filterValue;
                        break;

                    case MovieBean.FIELD.BELONGS_TO_COLLECTION:
                        chkBelongsToCollectionEnabled.Checked = true;
                        List<String> itemsToCheck = ((CollectionFilteritem)filter).filterValues;
                        for(int i = 0; i < chkCollections.Items.Count; i++)
                        {
                            chkCollections.SetItemChecked(i, ((CollectionFilteritem)filter).filterValues.Contains(chkCollections.Items[i].ToString()));
                        }
                        break;
                    case MovieBean.FIELD.BUDGET:
                        chkBudgetEnabled.Checked = true;
                        rdoBudgetBetween.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.BETWEEN;
                        rdoBudgetExactly.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.EXACT;
                        rdoBudgetGreaterThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.GREATER_THAN;
                        rdoBudgetLessThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.LESS_THAN;
                        txtBudget1.Text = ((NumberFilterItem)filter).lowerBound.ToString();
                        txtBudget2.Text = ((NumberFilterItem)filter).upperBound.ToString();
                        break;
                    case MovieBean.FIELD.DIRECTORS:
                        chkDirectorsEnabled.Checked = true;
                        rdoDirectorsRelaxed.Checked = ((ListFilterItem)filter).filterType == ListFilterItem.TYPE.RELAXED;
                        for(int i = 0; i < chkDirectors.Items.Count; i++)
                        {
                            chkDirectors.SetItemChecked(i, ((ListFilterItem)filter).filterValue.Contains(chkDirectors.Items[i]));
                        }
                        break;
                    case MovieBean.FIELD.GENRES:
                        chkGenresEnabled.Checked = true;
                        rdoGenresRelaxed.Checked = ((ListFilterItem)filter).filterType == ListFilterItem.TYPE.RELAXED;
                        for(int i = 0; i < chkGenres.Items.Count; i++)
                        {
                            chkGenres.SetItemChecked(i, ((ListFilterItem)filter).filterValue.Contains(chkGenres.Items[i]));
                        }
                        break;
                    case MovieBean.FIELD.OVERVIEW:
                        chkOverviewEnabled.Checked = true;
                        rdoOverviewContains.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.CONTAINS;
                        rdoOverviewEndsWith.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.ENDS_WITH;
                        rdoOverviewEquals.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.EQUALS;
                        rdoOverviewStartsWith.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.STARTS_WITH;
                        chkOverviewNot.Checked = ((StringFilterItem)filter).not;
                        txtOverview.Text = ((StringFilterItem)filter).filterValue;
                        break;
                    case MovieBean.FIELD.POPULARITY:
                        chkPopularityEnabled.Checked = true;
                        rdoPopularityBetween.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.BETWEEN;
                        rdoPopularityExactly.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.EXACT;
                        rdoPopularityGreaterThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.GREATER_THAN;
                        rdoPopularityLessThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.LESS_THAN;
                        txtPopularity1.Text = ((NumberFilterItem)filter).lowerBound.ToString();
                        txtPopularity2.Text = ((NumberFilterItem)filter).upperBound.ToString();
                        break;
                    case MovieBean.FIELD.PRODUCTION_COMPANIES:
                        chkProductionCompaniesEnabled.Checked = true;
                        rdoProductionCompaniesRelaxed.Checked = ((ListFilterItem)filter).filterType == ListFilterItem.TYPE.RELAXED;
                        for(int i = 0; i < chkProductionCompanies.Items.Count; i++)
                        {
                            chkProductionCompanies.SetItemChecked(i, ((ListFilterItem)filter).filterValue.Contains(chkProductionCompanies.Items[i]));
                        }
                        break;
                    case MovieBean.FIELD.RELEASE_DATE:
                        chkReleaseDateEnabled.Checked = true;
                        rdoReleaseDateAfter.Checked = ((DateFilterItem)filter).filterType == DateFilterItem.TYPE.AFTER;
                        rdoReleaseDateBetween.Checked = ((DateFilterItem)filter).filterType == DateFilterItem.TYPE.BETWEEN;
                        rdoReleaseDateEarlierThan.Checked = ((DateFilterItem)filter).filterType == DateFilterItem.TYPE.BEFORE;
                        rdoReleaseDateExactly.Checked = ((DateFilterItem)filter).filterType == DateFilterItem.TYPE.EXACT;
                        dtpReleaseDate1.Value = ((DateFilterItem)filter).lowerBound;
                        dtpReleaseDate2.Value = ((DateFilterItem)filter).upperBound;
                        break;
                    case MovieBean.FIELD.REVENUE:
                        chkRevenueEnabled.Checked = true;
                        rdoRevenueBetween.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.BETWEEN;
                        rdoRevenueExactly.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.EXACT;
                        rdoRevenueGreaterThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.GREATER_THAN;
                        rdoRevenueLessThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.LESS_THAN;
                        txtRevenue1.Text = ((NumberFilterItem)filter).lowerBound.ToString();
                        txtRevenue2.Text = ((NumberFilterItem)filter).upperBound.ToString();
                        break;
                    case MovieBean.FIELD.RUNTIME:
                        chkRuntimeEnabled.Checked = true;
                        rdoRuntimeBetween.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.BETWEEN;
                        rdoRuntimeExactly.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.EXACT;
                        rdoRuntimeGreaterThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.GREATER_THAN;
                        rdoRuntimeLessThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.LESS_THAN;
                        txtRuntime1.Text = ((NumberFilterItem)filter).lowerBound.ToString();
                        txtRuntime2.Text = ((NumberFilterItem)filter).upperBound.ToString();
                        break;
                    case MovieBean.FIELD.SPOKEN_LANGUAGES:
                        chkSpokenLanguagesEnabled.Checked = true;
                        rdoLanguagesRelaxed.Checked = ((ListFilterItem)filter).filterType == ListFilterItem.TYPE.RELAXED;
                        for(int i = 0; i < chkSpokenLanguages.Items.Count; i++)
                        {
                            chkSpokenLanguages.SetItemChecked(i, ((ListFilterItem)filter).filterValue.Contains(chkSpokenLanguages.Items[i]));
                        }
                        break;
                    case MovieBean.FIELD.TAGLINE:
                        chkTaglineEnabled.Checked = true;
                        chkTaglineNot.Checked = ((StringFilterItem)filter).not;
                        rdoTaglineContains.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.CONTAINS;
                        rdoTaglineEndsWith.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.ENDS_WITH;
                        rdoTaglineEquals.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.EQUALS;
                        rdoTaglineStartsWith.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.STARTS_WITH;
                        txtTagline.Text = ((StringFilterItem)filter).filterValue;
                        break;
                    case MovieBean.FIELD.TITLE:
                        chkTitleEnabled.Checked = true;
                        chkTitleNot.Checked = ((StringFilterItem)filter).not;
                        rdoTitleContains.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.CONTAINS;
                        rdoTitleEndsWith.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.ENDS_WITH;
                        rdoTitleEquals.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.EQUALS;
                        rdoTitleStartsWith.Checked = ((StringFilterItem)filter).filterType == StringFilterItem.TYPE.STARTS_WITH;
                        txtTitle.Text = ((StringFilterItem)filter).filterValue;
                        break;
                    case MovieBean.FIELD.VOTE:
                        chkVoteEnabled.Checked = true;
                        rdoVoteBetween.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.BETWEEN;
                        rdoVoteExactly.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.EXACT;
                        rdoVoteGreaterThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.GREATER_THAN;
                        rdoVoteLessThan.Checked = ((NumberFilterItem)filter).filterType == NumberFilterItem.TYPE.LESS_THAN;
                        txtVote1.Text = ((NumberFilterItem)filter).lowerBound.ToString();
                        txtVote2.Text = ((NumberFilterItem)filter).upperBound.ToString();
                        break;
                    case MovieBean.FIELD.ACTORS:
                        chkActorsEnabled.Checked = true;
                        rdoActorsRelaxed.Checked = ((ListFilterItem)filter).filterType == ListFilterItem.TYPE.RELAXED;
                        for(int i = 0; i < chkActors.Items.Count; i++)
                        {
                            chkActors.SetItemChecked(i, ((ListFilterItem)filter).filterValue.Contains(chkActors.Items[i].ToString()));
                        }
                        break;
                }
            }
        }

        public void saveFilters()
        {
            filters.Clear();

            //watchedFilter
            if (chkWatchedEnabled.Checked)
            {
                filters.Add(new BooleanFilterItem(MovieBean.FIELD.WATCHED, rdoWatched.Checked));
            }

            //adult filter
            if (chkAdultEnabled.Checked)
            {
                filters.Add(new BooleanFilterItem(MovieBean.FIELD.ADULT, rdoAdult.Checked));
            }

            //collections
            if (chkBelongsToCollectionEnabled.Checked)
            {
                filters.Add(new CollectionFilteritem(chkCollections.CheckedItems.Cast<string>().ToList()));
            }

            //budget
            if (chkBudgetEnabled.Checked)
            {
                String lower = GlobalFunctions.stripNonNumericChars(txtBudget1.Text);
                String upper = GlobalFunctions.stripNonNumericChars(txtBudget2.Text);

                int lowerInt = 0;
                int upperInt = 0;

                int.TryParse(lower, out lowerInt);
                int.TryParse(upper, out upperInt);
                
                NumberFilterItem.TYPE budgetType = NumberFilterItem.TYPE.BETWEEN;
                if (rdoBudgetExactly.Checked)
                {
                    budgetType = NumberFilterItem.TYPE.EXACT;
                }
                else if (rdoBudgetGreaterThan.Checked)
                {
                    budgetType = NumberFilterItem.TYPE.GREATER_THAN;
                }
                else if (rdoBudgetLessThan.Checked)
                {
                    budgetType = NumberFilterItem.TYPE.LESS_THAN;
                }
                filters.Add(new NumberFilterItem(MovieBean.FIELD.BUDGET, lowerInt, upperInt, budgetType)); 
            }

            //genres
            if (chkGenresEnabled.Checked)
            {
                ListFilterItem.TYPE genresType = ListFilterItem.TYPE.STRICT;
                if (rdoGenresRelaxed.Checked)
                {
                    genresType = ListFilterItem.TYPE.RELAXED;
                }
                filters.Add(new ListFilterItem(MovieBean.FIELD.GENRES, chkGenres.CheckedItems.Cast<String>().ToList(), genresType));
            }

            //overview
            if (chkOverviewEnabled.Checked)
            {
                StringFilterItem.TYPE overviewType = StringFilterItem.TYPE.CONTAINS;
                if (rdoOverviewEndsWith.Checked)
                {
                    overviewType = StringFilterItem.TYPE.ENDS_WITH;
                }
                else if (rdoOverviewEquals.Checked)
                {
                    overviewType = StringFilterItem.TYPE.EQUALS;
                }
                else if (rdoOverviewStartsWith.Checked)
                {
                    overviewType = StringFilterItem.TYPE.STARTS_WITH;
                }
                filters.Add(new StringFilterItem(MovieBean.FIELD.OVERVIEW, txtOverview.Text, chkOverviewNot.Checked, overviewType));
            }

            //popularity
            if (chkPopularityEnabled.Checked)
            {
                double lower = Double.Parse(GlobalFunctions.stripNonNumericChars(txtPopularity1.Text));
                double upper = Double.Parse(GlobalFunctions.stripNonNumericChars(txtPopularity2.Text));

                NumberFilterItem.TYPE popularityType = NumberFilterItem.TYPE.BETWEEN;
                if (rdoPopularityExactly.Checked)
                {
                    popularityType = NumberFilterItem.TYPE.EXACT;
                }
                else if (rdoPopularityGreaterThan.Checked)
                {
                    popularityType = NumberFilterItem.TYPE.GREATER_THAN;
                }
                else if (rdoPopularityLessThan.Checked)
                {
                    popularityType = NumberFilterItem.TYPE.LESS_THAN;
                }

                filters.Add(new NumberFilterItem(MovieBean.FIELD.POPULARITY, lower, upper, popularityType));
            }

            //production companies
            if (chkProductionCompaniesEnabled.Checked)
            {
                ListFilterItem.TYPE productionCompaniesType = ListFilterItem.TYPE.RELAXED;
                if (rdoProductionCompaniesStrict.Checked)
                {
                    productionCompaniesType = ListFilterItem.TYPE.STRICT;
                }
                filters.Add(new ListFilterItem(MovieBean.FIELD.PRODUCTION_COMPANIES, chkProductionCompanies.CheckedItems.Cast<String>().ToList(), productionCompaniesType));
            }

            //release date
            if (chkReleaseDateEnabled.Checked)
            {
                DateFilterItem.TYPE releaseDateType = DateFilterItem.TYPE.AFTER;
                if (rdoReleaseDateBetween.Checked)
                {
                    releaseDateType = DateFilterItem.TYPE.BETWEEN;
                }
                else if (rdoReleaseDateEarlierThan.Checked)
                {
                    releaseDateType = DateFilterItem.TYPE.BEFORE;
                }
                else if (rdoReleaseDateExactly.Checked)
                {
                    releaseDateType = DateFilterItem.TYPE.EXACT;
                }
                filters.Add(new DateFilterItem(MovieBean.FIELD.RELEASE_DATE, dtpReleaseDate1.Value, dtpReleaseDate2.Value, releaseDateType));
            }

            //revenue
            if (chkRevenueEnabled.Checked)
            {

                int lower = int.Parse(GlobalFunctions.stripNonNumericChars(txtRevenue1.Text));
                int upper = int.Parse(GlobalFunctions.stripNonNumericChars(txtRevenue2.Text));

                NumberFilterItem.TYPE revenueType = NumberFilterItem.TYPE.BETWEEN;
                if (rdoRevenueExactly.Checked)
                {
                    revenueType = NumberFilterItem.TYPE.EXACT;
                }
                else if (rdoRevenueGreaterThan.Checked)
                {
                    revenueType = NumberFilterItem.TYPE.GREATER_THAN;
                }
                else if (rdoRevenueLessThan.Checked)
                {
                    revenueType = NumberFilterItem.TYPE.LESS_THAN;
                }
                filters.Add(new NumberFilterItem(MovieBean.FIELD.REVENUE, lower, upper, revenueType));
            }

            //runtime
            if (chkRuntimeEnabled.Checked)
            {
                int lower = int.Parse(GlobalFunctions.stripNonNumericChars(txtRuntime1.Text));
                int upper = int.Parse(GlobalFunctions.stripNonNumericChars(txtRuntime2.Text));

                NumberFilterItem.TYPE runtimeType = NumberFilterItem.TYPE.BETWEEN;
                if (rdoRuntimeExactly.Checked)
                {
                    runtimeType = NumberFilterItem.TYPE.EXACT;
                }
                else if (rdoRuntimeGreaterThan.Checked)
                {
                    runtimeType = NumberFilterItem.TYPE.GREATER_THAN;
                }
                else if (rdoRuntimeLessThan.Checked)
                {
                    runtimeType = NumberFilterItem.TYPE.LESS_THAN;
                }
                filters.Add(new NumberFilterItem(MovieBean.FIELD.RUNTIME, lower, upper, runtimeType));
            }

            //spoken languages
            if (chkSpokenLanguagesEnabled.Checked)
            {
                ListFilterItem.TYPE spokenLanguagesType = ListFilterItem.TYPE.RELAXED;
                if (rdoLanguagesStrict.Checked)
                {
                    spokenLanguagesType = ListFilterItem.TYPE.STRICT;
                }
                filters.Add(new ListFilterItem(MovieBean.FIELD.SPOKEN_LANGUAGES, chkSpokenLanguages.CheckedItems.Cast<String>().ToList(), spokenLanguagesType));
            }


            //tagline
            if (chkTaglineEnabled.Checked)
            {
                StringFilterItem.TYPE taglineType = StringFilterItem.TYPE.CONTAINS;
                if (rdoTaglineEndsWith.Checked)
                {
                    taglineType = StringFilterItem.TYPE.ENDS_WITH;
                }
                else if (rdoTaglineEquals.Checked)
                {
                    taglineType = StringFilterItem.TYPE.EQUALS;
                }
                else if (rdoTaglineStartsWith.Checked)
                {
                    taglineType = StringFilterItem.TYPE.STARTS_WITH;
                }
                filters.Add(new StringFilterItem(MovieBean.FIELD.TAGLINE, txtTagline.Text, chkTaglineNot.Checked, taglineType));
            }

            //title
            if (chkTitleEnabled.Checked)
            {
                StringFilterItem.TYPE titleType = StringFilterItem.TYPE.CONTAINS;
                if (rdoTitleEndsWith.Checked)
                {
                    titleType = StringFilterItem.TYPE.ENDS_WITH;
                }
                else if (rdoTitleEquals.Checked)
                {
                    titleType = StringFilterItem.TYPE.EQUALS;
                }
                else if (rdoTitleStartsWith.Checked)
                {
                    titleType = StringFilterItem.TYPE.STARTS_WITH;
                }
                filters.Add(new StringFilterItem(MovieBean.FIELD.TITLE, txtTitle.Text, chkTitleNot.Checked, titleType));
            }

            //vote
            if (chkVoteEnabled.Checked)
            {
                
                int lower = int.Parse(GlobalFunctions.stripNonNumericChars(txtVote1.Text));
                int upper = int.Parse(GlobalFunctions.stripNonNumericChars(txtVote2.Text));

                NumberFilterItem.TYPE voteType = NumberFilterItem.TYPE.BETWEEN;
                if (rdoVoteExactly.Checked)
                {
                    voteType = NumberFilterItem.TYPE.EXACT;
                }
                else if (rdoVoteGreaterThan.Checked)
                {
                    voteType = NumberFilterItem.TYPE.GREATER_THAN;
                }
                else if (rdoVoteLessThan.Checked)
                {
                    voteType = NumberFilterItem.TYPE.LESS_THAN;
                }
                filters.Add(new NumberFilterItem(MovieBean.FIELD.VOTE, lower, upper, voteType));
            }

            //actors
            if (chkActorsEnabled.Checked)
            {
                ListFilterItem.TYPE actorsType = ListFilterItem.TYPE.RELAXED;
                if (rdoActorsStrict.Checked)
                {
                    actorsType = ListFilterItem.TYPE.STRICT;
                }
                filters.Add(new ListFilterItem(MovieBean.FIELD.ACTORS, chkActors.CheckedItems.Cast<String>().ToList(), actorsType));
            }

            //directors
            if (chkDirectorsEnabled.Checked)
            {
                ListFilterItem.TYPE directorsType = ListFilterItem.TYPE.RELAXED;
                if (rdoDirectorsStrict.Checked)
                {
                    directorsType = ListFilterItem.TYPE.STRICT;
                }
                filters.Add(new ListFilterItem(MovieBean.FIELD.DIRECTORS, chkDirectors.CheckedItems.Cast<String>().ToList(), directorsType));
            }
        }

        #region "Event handlers"
        private void lblWatched_Click_1(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            showPanel(lbl.Name);
        }

        private void lblWatched_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Label l = (Label)sender;

            String checkboxName = ((Label)sender).Name.Replace("lbl", "chk") + "Enabled";
            CheckBox c = (CheckBox)this.Controls.Find(checkboxName, true)[0];
            if (c.Checked)
            {
                l.ForeColor = Color.Black;
            }
            else
            {
                l.ForeColor = Color.White;
            }
        }

        private void lblWatched_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Label l = (Label)sender;
            l.ForeColor = Color.Black;
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            saveFilters();
            Close();
        }
        #endregion

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txtBudget2.Enabled = rdoBudgetBetween.Checked;
        }

        private void chkWatchedEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Label l = (Label)panel1.Controls.Find(((CheckBox)sender).Parent.Parent.Name.Replace("pnl", "lbl"), true)[0];
            l.ForeColor = ((CheckBox)sender).Checked? Color.Black: Color.White;
        }
    }
}
