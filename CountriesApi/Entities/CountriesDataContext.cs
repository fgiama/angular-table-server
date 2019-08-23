using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesApi.Entities
{
    public class CountriesDataContext : DbContext
    {
        public CountriesDataContext(DbContextOptions<CountriesDataContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Country> Countries { get; set; }
    }
}
