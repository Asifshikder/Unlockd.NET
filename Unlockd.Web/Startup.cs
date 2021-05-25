using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Unlockd.Data;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Repo;
using Unlockd.Service.Implementation.Blog;
using Unlockd.Service.Implementation.Device;
using Unlockd.Service.Implementation.Network;
using Unlockd.Service.Implementation.Orders;
using Unlockd.Service.Implementation.Services;
using Unlockd.Service.Implementation.Testimonials;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Blog;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Service.Interface.Orders;
using Unlockd.Service.Interface.Services;
using Unlockd.Service.Interface.Testimonials;
using Unlockd.Web.Helpers;

namespace Unlockd.Web
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<UnlockdContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("constring"));
                option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddIdentity<User, IdentityRole>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.SignIn.RequireConfirmedEmail = false;
                }).AddEntityFrameworkStores<UnlockdContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(
                options =>
                {
                    options.LoginPath = new PathString("/Home/Index");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                    options.LogoutPath = new PathString("/Account/Logout");
                });
         
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IFileHandler, FileHandler>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IWorkContext, WorkContext>();
            services.AddSingleton<IImeiCheck, ImeiCheck>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<INetworkCarrierService, NetworkCarrierService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IFAQService, FAQService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IDeviceModelService, DeviceModelService>();
            services.AddTransient<IBlogPostService, BlogPostService>();
            services.AddTransient<IBlogCategoryService, BlogCategoryService>();
            services.AddTransient<ITestimonialService, TestimonialService>();
            services.AddTransient<IOurInfoService, OurInfoService>();
            services.AddTransient<IBrandFAQService, BrandFAQService>();
            services.AddTransient<ISupportMenuService, SupportMenuService>();
            services.AddTransient<IOrderService, OrderService>();
            //Pricing
            services.AddTransient<IBlackListCheckService, BlackListCheckService>();
            services.AddTransient<ICarrierCheckService, CarrierCheckService>();
            services.AddTransient<ISprintStatusCheckService, SprintStatusCheckService>();
            services.AddTransient<IICloudCheckService, ICloudCheckService>();
            services.AddTransient<IModelVsCarrierService, ModelVsCarrierService>();
            //pricing
            services.AddMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;

            });
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
