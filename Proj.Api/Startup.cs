using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proj.Core.Repositories;
using Proj.Infrastructure.Repositories;
using Proj.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Proj.Infrastructure.DataAccess;
using Proj.Api.Logger;

namespace Proj.Api
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
            services.AddLogging();
            services.AddMvc()
            .AddJsonOptions(x => x.JsonSerializerOptions.WriteIndented = true);
            services.AddScoped<IContactsRepository, ContactsRepository>();
            services.AddScoped<IContactsService, ContactsService>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ICustomLogger, CustomLogger>();
            services.AddControllersWithViews();        
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            services.AddDbContext<ContactsDbContext>(options =>
            {
                options.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=pdominiakDB;Persist Security Info=False;Connection Timeout=30;");

            });
            // In production, the Angular files will be served from this directory
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200", "http://192.168.0.99:4200")
               .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();  
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

           
        }
    }
}
