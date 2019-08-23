using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesApi.Entities;
using CountriesApi.Models;
using CountriesApi.Services;
using CountriesAPI;
using Microsoft.AspNetCore.Mvc;

namespace CountriesApi.Controllers
{
    [Route("api/countries")]
    public class CountriesController : Controller
    {
        private ICountriesRepository _repository;

        public CountriesController(ICountriesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _repository.GetCountries().
                Select(n => new CountryDto()
                {
                    Id = n.Id.ToString(),
                    Name = n.Name,
                    Capital = n.Capital,
                    Population = n.Population.GetValueOrDefault(),
                    Region = n.Region
                });

            return Ok(countries);
        }

        [HttpPost("lazy")]
        public IActionResult GetCountries([FromBody]RequestViewModel model)
        {
            var filters = new Dictionary<string, string>();
            if(model.Filters != null)
            {
                if(model.Filters.Name != null && !string.IsNullOrEmpty(model.Filters.Name.Value))
                {
                   filters.Add("Name", model.Filters.Name.Value);
                }
                if (model.Filters.Capital != null && !string.IsNullOrEmpty(model.Filters.Capital.Value))
                {
                    filters.Add("Capital", model.Filters.Capital.Value);
                }
                if (model.Filters.Region != null && !string.IsNullOrEmpty(model.Filters.Region.Value))
                {
                    filters.Add("Region", model.Filters.Region.Value);
                }
            }

            var countries = _repository.GetCountries(model.First, model.Rows, model.SortField, model.SortOrder, filters);

            return Ok(new {list = countries.Countries.Select(n => new CountryDto()
                                                            {
                                                                Id = n.Id.ToString(),
                                                                Name = n.Name,
                                                                Capital = n.Capital,
                                                                Population = n.Population.GetValueOrDefault(),
                                                                Region = n.Region
                                                            }), totalRecords = countries.TotalCountries });

           
        }
    }
}