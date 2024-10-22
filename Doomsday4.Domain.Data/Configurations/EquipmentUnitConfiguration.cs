using Doomsday4.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Doomsday4.Domain.Data.Configurations;

public class EquipmentUnitConfiguration : IEntityTypeConfiguration<EquipmentUnit>
{
    public void Configure(EntityTypeBuilder<EquipmentUnit> builder)
    {
        builder.HasKey(eu => eu.Id);
        //builder.Property(eu => eu.EquipmentTypeId)
        builder.HasOne(eu => eu.EquipmentType)
            .WithMany(eu => eu.EquipmentsUnits)
            .HasForeignKey(eu => eu.EquipmentTypeId)
            .IsRequired();
        builder.Property(eu => eu.SerialNumber);
        builder.Property(eu => eu.Notes);
        builder.Property(eu => eu.Status).HasConversion<string>();
        // builder.HasOne(o => o.User)
        //     .WithMany(o => o.Orders)
        //     .HasForeignKey(o => o.UserId)
        //     .IsRequired();
        // builder.HasMany(e => e.Order).WithOne(e => e.)
        //
        
        // builder.Property(e => e.Category)
        //     .HasColumnType("jsonb")
        //     .HasConversion(
        //         v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
        //         v => JsonConvert.DeserializeObject<EquipmentCategory>(v)
        //     );
        
        //.HasConversion(v )
        //enum будет сохраняться в стринге
    }
}