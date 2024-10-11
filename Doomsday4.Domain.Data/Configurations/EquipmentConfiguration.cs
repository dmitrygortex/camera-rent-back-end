using Doomsday4.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Doomsday4.Domain.Data.Configurations;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name);
        builder.Property(e => e.Description);
        builder.Property(e => e.Status).HasConversion<string>();
        builder.Property(e => e.Price);
        builder.Property(e => e.Category)
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