using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesApi.Entities;
using CountriesApi.Models;

namespace CountriesApi.Services
{
    public class CountriesRepository : ICountriesRepository
    {
        private CountriesDataContext _context;

        public CountriesRepository(CountriesDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries;
        }

        public FilteredCountries GetCountries(int first, int rows, string sortField, 
            SortOrderEnum sortOrder, Dictionary<string, string> filters)
        {
            var countryList = _context.Countries.ToList();
            if (filters != null)
            {
                string value = string.Empty;
                if (filters.ContainsKey("Capital"))
                { 
                    filters.TryGetValue("Capital", out value);
                    countryList = countryList.Where(n => n.Capital.Contains(value)).ToList();
                }
                if (filters.ContainsKey("Name"))
                {
                    filters.TryGetValue("Name", out value);
                    countryList = countryList.Where(n => n.Name.Contains(value)).ToList();
                }
                if (filters.ContainsKey("Region"))
                {
                    filters.TryGetValue("Region", out value);
                    countryList = countryList.Where(n => n.Region.Contains(value)).ToList();
                }
            }
            var totalRows = countryList.Count();
            switch (sortField)
            {
                case "Capital":
                    countryList = sortOrder == SortOrderEnum.ASC ? countryList.OrderBy(n => n.Capital).Skip(first).Take(rows).ToList() :
                        countryList.OrderByDescending(n => n.Capital).Skip(first).Take(rows).ToList();
                    break;
                case "Name":
                    countryList = sortOrder == SortOrderEnum.ASC ? countryList.OrderBy(n => n.Name).Skip(first).Take(rows).ToList() :
                        countryList.OrderByDescending(n => n.Name).Skip(first).Take(rows).ToList();
                    break;
                default:
                    countryList = sortOrder == SortOrderEnum.ASC ? countryList.OrderBy(n => n.Id).Skip(first).Take(rows).ToList() :
                        countryList.OrderByDescending(n => n.Id).Skip(first).Take(rows).ToList();
                    break;

            }

            var countries = new FilteredCountries() { Countries = countryList.ToList(), TotalCountries = totalRows};

            return countries;
        }
    }

    public enum SortOrderEnum
    {
        DESC,
        ASC
    }

    public class CoutriesQueryResponse
    {
        IEnumerable<Country> Countries { get; set; }
        public int TotalRows { get; set; }
    }
}
