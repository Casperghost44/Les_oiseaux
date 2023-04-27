using Les_oiseaux.App.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_oiseaux.Inf.Database.Mappings
{
    public sealed class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category", "dbo");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("TEXT")
                .HasMaxLength(254)
                .IsRequired();

            builder.HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId);

            builder.HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}
