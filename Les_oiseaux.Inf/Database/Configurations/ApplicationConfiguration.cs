using Les_oiseaux.App.Services.Interfaces;
using Les_oiseaux.Inf.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Les_oiseaux.Inf.Database.Configurations
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDatabase(
           this IServiceCollection services,
           string connectionString,
           Assembly mappingAssembly)
        {
            services.AddDbContext<DataBaseContext>(opt =>
            {
                opt.UseSqlite(connectionString, config =>
                {
                    config.MigrationsAssembly(mappingAssembly.GetName().Name);
                    config.MigrationsHistoryTable("migration_history", "dbo");
                });

                opt.EnableDetailedErrors(true);
                opt.ConfigureWarnings(e =>
                {
                    e.Default(WarningBehavior.Log);
                });
            });

            services.AddRepositories();

            return services;
        }

        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            return services;
        }

        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
        {
            var database = app.ApplicationServices.CreateScope()
                .ServiceProvider
                .GetRequiredService<DataBaseContext>();

            database.Database.Migrate();

            return app;
        }
    }
}
