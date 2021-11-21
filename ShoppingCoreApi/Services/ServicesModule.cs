using Microsoft.Extensions.DependencyInjection;
using ShoppingCoreApi.Services.ShoppingCart;
using ShoppingCoreApi.Services.ShoppingCart.Interfaces;
using ShoppingCoreApi.Services.ShoppingStore;
using ShoppingCoreApi.Services.ShoppingStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCoreApi.Services
{
    public static class ServicesModule
    {
        //IMPORTANT NOTE: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2#service-lifetimes-and-registration-options
        //For DB calls, use Scoped
        //For HttpClients, use Singleton : https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.8

        public static void AddServices(this IServiceCollection services)
        {
            //Cart
            services.AddScoped<ICartService, CartService>();

            //DiscountStore
            services.AddScoped<IDiscountStoreService, DiscountStoreService>();
        }
    }
}
