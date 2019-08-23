using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesApi.Models
{
    public class CountryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public long Population { get; set; }
    }
}
