using Doomsday4.Common.Domain;
using Doomsday4.Domain.Data.Configurations;
using Doomsday4.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Doomsday4.Domain.Data;

public class RentDbContext : DbContext
{
    public RentDbContext(DbContextOptions<RentDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured) 
            throw new InvalidOperationException("Context was not configured");
        base.OnConfiguring(optionsBuilder);
        
    }
   
}

// public class RentDbContext : DbContext
// {
//     public DbSet<User> Users { get; set; }
//     public DbSet<Order> Orders { get; set; }
//     public DbSet<Equipment> Equipment { get; set; }
//     public RentDbContext()
//     {
//         Database.EnsureCreated();
//     }
//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//         optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=camerarentdb;Username=postgres;Password=0");
//     }
// }