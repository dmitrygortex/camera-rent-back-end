using Doomsday4.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Doomsday4.Domain.Data.Configurations;

public class EquipmentTypeConfiguration : IEntityTypeConfiguration<EquipmentType>
{
    public void Configure(EntityTypeBuilder<EquipmentType> builder)
    {
        builder.HasKey(et => et.Id);
        builder.Property(et => et.Name);
        builder.Property(et => et.Description);
        builder.Property(et => et.Price);
        builder.Property(et => et.Category)
            .HasColumnType("jsonb").HasConversion(
                v => JsonConvert.SerializeObject(v),
                
                // TODO: del NULL POSSIBLE
                v => JsonConvert.DeserializeObject<EquipmentCategory>(v) 
        
            );
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