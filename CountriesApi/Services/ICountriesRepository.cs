using CountriesApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesApi.Services
{
    public interface ICountriesRepository
    {
        IEnumerable<Country> GetCountries();

        FilteredCountries GetCountries(int first, int rows, string sortField, 
            SortOrderEnum sortOrder, Dictionary<string, string> filters);
    }
}
