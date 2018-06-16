using System.Text;
using AplikacjaKulinarna.API.Helpers;
using AplikacjaKulinarna.Repository;
using AplikacjaKulinarna.Repository.Interfaces;
using AplikacjaKulinarna.Repository.Repositories;
using AplikacjaKulinarna.Service.Interfaces;
using AplikacjaKulinarna.Service.Services;
using AplikacjaKulinarna.Service.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AplikacjaKulinarna.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("AplikacjaKulinarna.Repository")));
            services.AddMvc();
            services.AddAutoMapper();

            var appSettingsSection = Configuration.GetSection("jwt");
            services.Configure<JwtSettings>(appSettingsSection);
            //var appSettings = appSettingsSection.Get<JwtSettings>();
            //var appSettings = appSettingsSection.Key;
            //var test = appSettings.Key;
            var key = Encoding.UTF8.GetBytes("super_hubert_nie_super_lokata");
            services.AddAuthorization(x => x.AddPolicy("HasAdminRole", p => p.RequireRole("admin")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            //services.AddAuthentication(x =>
            //    {
            //        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    })
            //  .AddJwtBearer(cfg =>
            //    {
            //        cfg.RequireHttpsMetadata = false;
            //        cfg.SaveToken = true;

            //        cfg.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidIssuer = "http://localhost:44304/",
            //            ValidAudience = "http://localhost:44304/",
            //            IssuerSigningKey = new SymmetricSecurityKey(key)
            //        };

            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseErrorHandler();
            app.UseMvc();
           
        }
    }
}
