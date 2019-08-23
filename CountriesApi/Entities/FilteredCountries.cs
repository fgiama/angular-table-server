using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesApi.Entities
{
    public class FilteredCountries
    {
        public List<Country> Countries { get; set; }
        public int TotalCountries { get; set; }
    }
}
