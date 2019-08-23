using CountriesApi.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CountriesApi
{
    public static class CountriesDataContextExtensions
    {
        public static void EnsureSeedDataForContext(this CountriesDataContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            var data = System.IO.File.ReadAllText("countries.json");
            var countriesResponse = JsonConvert.DeserializeObject<IEnumerable<Country>>(data);

            var countries = new List<Country>();
            foreach(var item in countriesResponse)
            {
                var country = new Country()
                {
                    Name = item.Name,
                    Capital = item.Name,
                    Population = item.Population,
                    Region = item.Region
                };

                countries.Add(country);
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();
        }

    }
}
