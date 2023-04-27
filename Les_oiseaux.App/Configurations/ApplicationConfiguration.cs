using Les_oiseaux.App.Services.Implementations;
using Les_oiseaux.App.Services.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Les_oiseaux.App.Configurations
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddAutoMapper(
                Assembly.GetExecutingAssembly(),
                Assembly.GetEntryAssembly(),
            Assembly.GetCallingAssembly());

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
