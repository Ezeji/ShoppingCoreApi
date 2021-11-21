using Microsoft.Extensions.DependencyInjection;
using ShoppingCoreRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCoreRepository
{
    public static class RepositoryModule
    {
        public static void AddCoreRepository(this IServiceCollection services)
        {
            //Inject Business Login Layers. Use Scoped for Repos that use EF (our BLL) since EF uses Scope.
            //See https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.1 for details

            //Extended for Cart Repos
            services.AddScoped<ICartRepository, CartRepository>();

            //Extended for DiscountStore Repos
            services.AddScoped<IDiscountStoreRepository, DiscountStoreRepository>();     
        }
    }
}
