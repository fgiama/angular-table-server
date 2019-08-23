using CountriesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAPI
{
    public class CountriesDataStore
    {
        public static CountriesDataStore Current { get; } = new CountriesDataStore();
        public List<CountryDto> Countries { get; set; }

        public CountriesDataStore()
        {
            Countries = new List<CountryDto>()
            {
            };
        }
    }
}
