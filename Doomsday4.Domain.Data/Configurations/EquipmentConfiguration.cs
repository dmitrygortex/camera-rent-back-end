using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doomsday4.Domain.Data.Configurations;

public class EquipmentConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        // builder.HasMany(o => o.Equipments).WithOne(e => e.);
        // builder.HasOne(o => o.User)
        //     .WithMany(o=>o.Orders)
        //     .HasForeignKey(o=>o.UserId)
        //     .IsRequired();
        builder.Property(o => o.Status).HasConversion<string>(); //enum будет сохраняться в стринге
    }
}