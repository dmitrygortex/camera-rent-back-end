using Doomsday4.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Doomsday4.Domain.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        // builder.HasMany(o => o.Equipments).WithOne(e => e.);
        builder.HasOne(o => o.User)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.UserId)
            .IsRequired();
        builder.Property(o => o.OrderStatus).HasConversion<string>();
        builder
            .HasMany(o => o.EquipmentUnits)
            .WithOne()
            .IsRequired(false);


        //.HasConversion(v )
        //enum будет сохраняться в стринге
    }
}