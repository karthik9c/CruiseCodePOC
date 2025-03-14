using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure.Identity;
using Azure.Search.Documents;
using Azure.Storage.Blobs;
using Domain.Interfaces;
using Azure.AI.OpenAI;
using Application.UseCases;
using Infrastructure.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Infrastructure.APIStandard.Mapper.Interface;
using Infrastructure.APIStandard.Mapper.Octo;
using OctoEntities = Infrastructure.APIStandard.Models.Octo;
using ExpediaEntities = Infrastructure.APIStandard.Models.Expedia;
using Application.Models.Supplier;
using Infrastructure.APIStandard.Mapper.Expedia;


namespace Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureDependencyServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Access the AppConfig instance from the configuration
            var appConfig = new AppConfig(configuration); // or use DI to resolve AppConfig

            // Register services that depend on AppConfig
            services.AddSingleton(appConfig);

            services.AddScoped<ISupplierMappingStrategy<OctoEntities.Supplier>, OctoSupplierMappingStrategy>();
            services.AddScoped<ISupplierMappingStrategy<ExpediaEntities.Seller>, ExpediaSupplierMappingStrategy>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IGetSupplierUseCase, GetSupplierUseCase>();
        }

    }
}
