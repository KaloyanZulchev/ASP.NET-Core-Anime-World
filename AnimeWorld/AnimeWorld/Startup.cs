using AnimeWorld.Data;
using AnimeWorld.Data.Models;
using AnimeWorld.Infrastructure.Extensions;
using AnimeWorld.Services.Animes;
using AnimeWorld.Services.Commets;
using AnimeWorld.Services.Ratings;
using AnimeWorld.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AnimeWorld
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<AnimeWorldDbContext>(options => options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services
               .AddDefaultIdentity<User>(options =>
               {
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
               })
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<AnimeWorldDbContext>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            services.AddTransient<IAnimeService, AnimeService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<Random>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app
               .UseHttpsRedirection()
               .UseStaticFiles()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapDefaultControllerRoute();
                   endpoints.MapRazorPages();
               });
        }
    }
}
