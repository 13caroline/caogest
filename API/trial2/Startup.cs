using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using trial2.Models;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace trial2
{
    public class Startup
    {
        readonly string MyPolicy = "_myPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options => options.AddPolicy(MyPolicy,builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));

            string server = "caogestli.mysql.database.azure.com";
            string database = "caogest";
            string dbId = "host@caogestli";
            string dbPassword = "AzureLI4";
            string connectionString;
            connectionString = "server=" + server + ";" + "database=" +
            database + ";" + "uid=" + dbId + ";" + "password=" + dbPassword + ";";

            services.AddDbContext<trial2Context>(opt =>
               opt.UseMySql(connectionString));
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = true,
                            ValidAudience = "https://localhost:44321",
                            ValidateIssuer = true,
                            ValidIssuer = "https://localhost:44321",
                            ValidateIssuerSigningKey = true,
                            RequireExpirationTime = true,
                            RequireSignedTokens = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("damfdertyuiopsaz")),
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes*/
                        };
                    });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;

                    });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.AllowAnyHeader().WithMethods("GET","POST","PUT","DELETE","OPTIONS").WithOrigins("http://localhost:8080").AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
