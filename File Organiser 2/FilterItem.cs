using System;
using System.Collections.Generic;
using System.Linq;

namespace File_Organiser_2
{
    public abstract class FilterItem
    {
        public MovieBean.FIELD filterField;
        public abstract bool check(MovieBean movie);

    }

    public class NumberFilterItem : FilterItem
    {
        public enum TYPE
        {
            LESS_THAN,
            BETWEEN,
            EXACT,
            GREATER_THAN
        }
        
        public double lowerBound;
        public double upperBound;
        public TYPE filterType;

        public NumberFilterItem(MovieBean.FIELD newFilterField, double newLowerBound, double newUpperBound, TYPE newFilterType)
        {
            filterField = newFilterField;
            lowerBound = newLowerBound;
            upperBound = newUpperBound;
            filterType = newFilterType;
        }

        public override bool check(MovieBean movie)
        {
            double value = double.Parse(movie.get(filterField).ToString());
            switch (filterType)
            {
                case TYPE.BETWEEN:
                    return (value > lowerBound) && (value < upperBound);
                case TYPE.EXACT:
                    return value == lowerBound;
                case TYPE.GREATER_THAN:
                    return value > lowerBound;
                case TYPE.LESS_THAN:
                    return value < lowerBound;
            }
            return true;
        }
    }

    public class ListFilterItem : FilterItem
    {
        public enum TYPE
        {
            RELAXED,
            STRICT
        }

        public List<String> filterValue;
        public TYPE filterType;

        public ListFilterItem(MovieBean.FIELD newFilterField, List<String> newList, TYPE newFilterType)
        {
            filterField = newFilterField;
            filterValue = newList;
            filterType = newFilterType;
        }

        public override bool check(MovieBean movie)
        {
            List<string> value = (List<string>)movie.get(filterField);
            switch (filterType)
            {
                case TYPE.RELAXED:
                    return value.Intersect(filterValue).Any();
                case TYPE.STRICT:
                    return value.Intersect(filterValue).ToList().Count == filterValue.Count;
            }
            return true;
        }
    }

    public class BooleanFilterItem : FilterItem
    {
        public bool filterValue;

        public BooleanFilterItem(MovieBean.FIELD newFilterField, bool newFilterValue)
        {
            filterField = newFilterField;
            filterValue = newFilterValue;
        }

        public override bool check(MovieBean movie)
        {
            bool val = (bool)movie.get(filterField);
            return val == filterValue;
        }
    }

    public class StringFilterItem : FilterItem
    {
        public enum TYPE
        {
            CONTAINS,
            EQUALS,
            STARTS_WITH,
            ENDS_WITH
        }

        public TYPE filterType;
        public String filterValue;
        public Boolean not;

        public StringFilterItem(MovieBean.FIELD newFilterField, String newFilterValue, bool newNot, TYPE newFilterType)
        {
            filterField = newFilterField;
            filterValue = newFilterValue;
            not = newNot;
            filterType = newFilterType;
        }

        public override bool check(MovieBean movie)
        {
            String movieVal = (String)movie.get(filterField);
            if(movieVal == null)
            {
                movieVal = "";
            }
            bool returnVal = true;
            switch (filterType)
            {
                case TYPE.CONTAINS:
                    returnVal = movieVal.ToUpper().Contains(filterValue.ToUpper());
                    break;
                case TYPE.ENDS_WITH:
                    returnVal = movieVal.ToUpper().EndsWith(filterValue.ToUpper());
                    break;
                case TYPE.EQUALS:
                    returnVal = movieVal.ToUpper().Equals(filterValue.ToUpper());
                    break;
                case TYPE.STARTS_WITH:
                    returnVal = movieVal.ToUpper().StartsWith(filterValue.ToUpper());
                    break;
            }
            if (not)
            {
                return !returnVal;
            }
            return returnVal;
        }
    }

    public class DateFilterItem : FilterItem
    {
        public enum TYPE
        {
            BEFORE,
            BETWEEN,
            EXACT,
            AFTER
        }
        
        public DateTime lowerBound;
        public DateTime upperBound;
        public TYPE filterType;

        public DateFilterItem(MovieBean.FIELD newFilterField, DateTime newLowerBound, DateTime newUpperBound, TYPE newFilterType)
        {
            filterField = newFilterField;
            lowerBound = newLowerBound;
            upperBound = newUpperBound;
            filterType = newFilterType;
        }

        public override bool check(MovieBean movie)
        {
            DateTime movieVal = (DateTime)movie.get(filterField);
            switch (filterType)
            {
                case TYPE.AFTER:
                    return lowerBound.CompareTo(movieVal) < 0;
                case TYPE.BEFORE:
                    return upperBound.CompareTo(movieVal) > 0;
                case TYPE.BETWEEN:
                    return lowerBound.CompareTo(movieVal) < 0 && upperBound.CompareTo(movieVal) > 0;
                case TYPE.EXACT:
                    return lowerBound.CompareTo(movieVal) == 0; 
            }
            return true;
        }
    }

    public class CollectionFilteritem : FilterItem
    {
        public List<String> filterValues = new List<string>();

        public CollectionFilteritem(List<String> newFilterVal)
        {
            filterField = MovieBean.FIELD.BELONGS_TO_COLLECTION;
            filterValues = newFilterVal;
        }

        public override bool check(MovieBean movie)//This will need re-work if a movie can be part of more than one collection
        {
            String collection = ((String)movie.get(filterField));
            String movieVal = "";
            if(collection != null || collection != "")
            {
                movieVal = collection;
            }
                
            return filterValues.Contains(movieVal);
        }
    }
}