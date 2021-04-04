using FluentValidation.AspNetCore;
using FormHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SigortamNet.Application.Operations.Partner;
using SigortamNet.Data.Contexts;
using SigortamNet.MVC.Extensions;

namespace SigortamNet.MVC
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SigortamNetContext>(x => x.UseSqlServer(connection));

            services.AddRegisterWebsiteServices();
            services.AddFluentValdationServices();
            services.AddAutoMapper(typeof(Startup), typeof(PartnerMapper));

            services.AddControllersWithViews().AddFormHelper(options =>
            {
                options.CheckTheFormFieldsMessage = "Form alanlarınızı kontrol ediniz";
                options.RedirectDelay = 3000;
                options.EmbeddedFiles = false;
            }).AddFluentValidation();
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
            app.UseStaticFiles();

            app.UseFormHelper();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
