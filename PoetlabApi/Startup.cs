using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoetlabApi.Data;
using PoetlabApi.Data.Repositories;
using PoetlabApi.Models;

namespace PoetlabApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<PoemDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("PoemContext")));

            services.AddScoped<PoemDataInitializer>();
            services.AddScoped<IPoemRepository, PoemRepository>();

            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "Poem API";
                c.Version = "v1";
                c.Description = "The Poem API documentation description.";
            }); //for OpenAPI 3.0 else AddSwaggerDocument();

            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
        
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PoemDataInitializer poemDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwaggerUi3();
            app.UseSwagger();

            poemDataInitializer.InitializeData();
        }
    }
}
