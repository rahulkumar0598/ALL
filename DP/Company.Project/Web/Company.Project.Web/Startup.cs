using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Company.Project.Core.ExceptionManagement;
using Company.Project.ProductDomain.AppServices;
using Company.Project.ProductDomain.AppServices.Mapper;
//using Company.Project.ProductDomain.Business.ProductDomain.Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Configuration;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.Web.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Company.Project.Web
{
    public class Startup
    {
        private MapperConfiguration _mapperConfiguration { get; set; }
        private IExceptionManager exceptionManager;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.AddProfile(new WebMappingProfile());
            });

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            Company.Project.Core.Logging.ILogger logger = new Company.Project.Loggig.NLog.Logger();
            exceptionManager = new ExceptionManager(logger);

            services.RegisterRepositories();
            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
            services.AddSingleton<ILoginUserAppService, LoginUserAppService>();
            services.AddSingleton<ISignUpUserAppService, SignUpUserAppService>();
            services.AddSingleton<IEventAppService, EventAppService>();
            services.AddSingleton<IProductAppService, ProductAppService>();
            services.AddSingleton<IExceptionManager, ExceptionManager>();
            services.AddSession();
            services.AddSingleton<Company.Project.Core.Logging.ILogger, Company.Project.Loggig.NLog.Logger>();
            services.AddDbContext<ProductDomainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            //services.AddDbContext<BooksContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Singleton);
            services.AddDbContext<BooksContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
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
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=NewIndex}/{id?}");
            });
        }
    }
}
