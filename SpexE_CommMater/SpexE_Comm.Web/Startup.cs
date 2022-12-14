using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpexE_Comm.Data.Data;
using SpexE_Comm.Model;
using SpexE_Comm.Web.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEssentials.AspNetCore.Pwa;

namespace SpexE_Comm.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //services.AddProgressiveWebApp(new PwaOptions { RegisterServiceWorker = true });

            services.AddDataProtection();

            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Never",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddServiceWorker(new PwaOptions
            {
                Strategy = ServiceWorkerStrategy.NetworkFirst,
                CacheId = "v4",
            });

            Services_Factory_Helper(services, Configuration);

            services.AddSession(options =>
            {
                options.Cookie.Name = "SpexE_Comm";
                options.IdleTimeout = TimeSpan.FromDays(15);
            });

            services.AddHttpClient();

            //services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = Configuration["Jwt:Issuer"],
            //            ValidAudience = Configuration["Jwt:Issuer"],
            //            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //        };
            //    });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSingleton(_ => Configuration);

            services.AddMemoryCache();

            services.AddResponseCaching();

            //services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContext<SpexE_CommContext>
                (options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SpexE_CommContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        private static void Services_Factory_Helper(IServiceCollection services, IConfiguration configuration)
        {
            DependencyContainer.ServicesFactoryHelper(services, configuration);
        }
    }
}
