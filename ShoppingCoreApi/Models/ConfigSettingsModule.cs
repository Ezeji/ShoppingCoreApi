using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCoreApi.Models
{
    public static class ConfigSettingsModule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Does not apply")]
        public static void AddConfigSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DiscountConfig>(configuration.GetSection("DiscountConfig"));
        }
    }
}
