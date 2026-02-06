using System.Linq;
using Stationery.PaperStore.API.Errors;
using Stationery.PaperStore.Core.Interfaces;
using Stationery.PaperStore.Infrastructure.Data;
using Stationery.PaperStore.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Stationery.PaperStore.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            // caching needs to be singleton for any request
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IEcommerceRepository<>), typeof(StationeryStoreRepository<>));
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            
             services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = acttionContext =>
                {
                    var errors = acttionContext.ModelState
                                               .Where(e => e.Value.Errors.Count > 0)
                                               .SelectMany(x => x.Value.Errors)
                                               .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new APIValidationError
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}