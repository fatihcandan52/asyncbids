using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SigortamNet.Application.Contracts.Operations.Bid;
using SigortamNet.Application.Contracts.Operations.Partner;
using SigortamNet.Application.Contracts.Operations.Visitor;
using SigortamNet.Application.Operations.Bid;
using SigortamNet.Application.Operations.Partner;
using SigortamNet.Application.Operations.Visitor;
using SigortamNet.Data.Repositories;
using SigortamNet.Data.UnitOfWork;
using SigortamNet.Integration.Contracts.Insurance;
using SigortamNet.Integration.Insurance;
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
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IBidService, BidManager>();
            services.AddScoped<IVisitorService, VisitorManager>();
            services.AddScoped<IPartnerService, PartnerManager>();

            services.AddScoped<IInsuranceFactoryService, InsuranceFactoryManager>();

            return services;
        }
    }
}
