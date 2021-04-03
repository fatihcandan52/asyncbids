using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SigortamNet.Data.Repositories;
using SigortamNet.Data.UnitOfWork;
using SigortamNet.MVC.Validations;
using SigortamNet.MVC.ViewModels;

namespace SigortamNet.MVC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFluentValdationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<VisitorViewModel>, VisitorViewModelValidator>();
            services.AddTransient<IValidator<MyBidsViewModel>, MyBidsViewModelValidator>();
            return services;
        }

        public static IServiceCollection AddRegisterWebsiteServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>)); // TODO: 


            return services;
        }
    }
}
