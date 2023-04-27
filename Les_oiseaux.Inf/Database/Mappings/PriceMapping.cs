using Les_oiseaux.App.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Les_oiseaux.Inf.Database.Mappings
{
    public sealed class PriceMapping : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("price", "dbo");

            builder.HasKey(e => e.Id).HasName("id");
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .HasColumnType("REAL")
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("TEXT")
                .HasMaxLength(3)
                .IsRequired();

            builder.HasOne(e => e.Product)
                .WithOne(e => e.Price)
                .HasForeignKey<Product>(e => e.PriceId)
                .IsRequired();
        }
    }
}
