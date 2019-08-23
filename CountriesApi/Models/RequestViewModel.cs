using CountriesApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesApi.Models
{
    public class RequestViewModel
    {
        public int First { get; set; }
        public int Rows { get; set; }
        public string SortField { get; set; }
        public SortOrderEnum SortOrder { get; set; }

        public FilterViewModel Filters { get; set; }
    }

    public class FilterViewModel
    {
        public FilterItem Region { get; set; }
        public FilterItem Name { get; set; }
        public FilterItem Capital { get; set; }
    }

    public class FilterItem
    {
        public string Value { get; set; }
        public string MatchMode { get; set; }
    }
}
