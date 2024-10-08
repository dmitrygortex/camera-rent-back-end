using Doomsday4.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doomsday4.Domain.Data.Configurations;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Status).HasConversion<string>();
        builder.Property(e => e.Category)
            .HasColumnType("jsonb");

        //.HasConversion(v )
        //enum будет сохраняться в стринге
    }
}