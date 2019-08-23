using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesApi.Entities;
using CountriesApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CountriesApi
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Startup.Configuration["connectionStrings:countriesDBConnectionString"];
            services.AddDbContext<CountriesDataContext>(o => o.UseSqlServer(connectionString));
            services.AddMvc().AddMvcOptions(o => o.OutputFormatters.Add(
                new XmlDataContractSerializerOutputFormatter()));

            services.AddScoped<ICountriesRepository, CountriesRepository>();

            services.AddCors(o => o.AddPolicy("AllowAnyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            CountriesDataContext countriesDataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else app.UseExceptionHandler("/error");
            app.UseCors("AllowAnyPolicy");
            app.UseStatusCodePages();
            app.UseMvc();

            countriesDataContext.EnsureSeedDataForContext();

        }
    }
}
