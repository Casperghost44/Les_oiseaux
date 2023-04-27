using Les_oiseaux.App.Models;
using Les_oiseaux.Inf;
using Les_oiseaux.Inf.Database.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_oiseaux.Inf.Database.Configurations
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {

        }

        public DataBaseContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ProductMapping).Assembly);

            var category1 = Category.Create("Other");
            category1.Id = 1;

            modelBuilder.Entity<Category>()
                .HasData(category1);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=main.db", config =>
                {
                    config.MigrationsAssembly("Les_oiseaux.Inf");
                    config.MigrationsHistoryTable("migration_history", "dbo");
                });

                optionsBuilder.EnableDetailedErrors(true);
                optionsBuilder.ConfigureWarnings(e =>
                {
                    e.Default(WarningBehavior.Log);
                });
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
