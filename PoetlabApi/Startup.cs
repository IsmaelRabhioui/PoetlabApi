using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PoetlabApi.Data;
using PoetlabApi.Data.Repositories;
using PoetlabApi.Models;
using System;
using System.Text;

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
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<PoemDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("PoemContext")));

            services.AddDefaultIdentity<UserModel>().AddEntityFrameworkStores<PoemDbContext>();
            services.AddScoped<PoemDataInitializer>();
            services.AddScoped<IPoemRepository, PoemRepository>();

            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "Poem API";
                c.Version = "v1";
                c.Description = "The Poem API documentation description.";
            }); //for OpenAPI 3.0 else AddSwaggerDocument();

            services.AddCors();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            });
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
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

            app.UseAuthentication();
            app.UseCors(builder =>
                builder.WithOrigins(Configuration["ApplicationSettings:Client_Url"]).AllowAnyHeader().AllowAnyMethod()
            );


            app.UseAuthentication();
            app.UseSwaggerUi3();
            app.UseSwagger();
            app.UseMvc();
            poemDataInitializer.InitializeData();
        }
    }
}
