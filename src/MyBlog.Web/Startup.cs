using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Core;
using MyBlog.Core.Queries;
using MyBlog.Infrastructure;
using MyBlog.Infrastructure.Data;
using MyBlog.Web.Models;

namespace MyBlog.Web
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
            services.AddMvc();
            services.AddMediatR(typeof(TagGetsQuery), typeof(DataContext));
            services.AddAutoMapper(typeof(Startup));

            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DataConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<AppSettings>(settings =>
            {
                Configuration.GetSection("AppSettings").Bind(settings);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var s = app.ApplicationServices.GetService<AppSettings>();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "oldBlog",
                    template: "post/{id}/{slug}",
                    defaults: new { Controller = "Redirect", Action = "OldBlog" });
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (serviceScope.ServiceProvider.GetService<DataContext>().AllMigrationsApplied())
                    return;

                serviceScope.ServiceProvider.GetService<DataContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<DataContext>().EnsureSeeded();
            }
        }
    }
}