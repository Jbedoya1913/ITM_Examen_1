using Microsoft.EntityFrameworkCore;
using ITM.VehicleSales.Models;

namespace ITM.VehicleSales.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Agency>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
            });

           
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DocumentNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Address).HasMaxLength(200);
            });

            
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Country).HasMaxLength(50);
            });

            
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.Color).HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.VIN).IsRequired().HasMaxLength(17);
                
                
                entity.HasOne(v => v.Brand)
                      .WithMany(b => b.Vehicles)
                      .HasForeignKey(v => v.BrandId)
                      .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(v => v.Agency)
                      .WithMany(a => a.Vehicles)
                      .HasForeignKey(v => v.AgencyId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SaleDate).IsRequired();
                entity.Property(e => e.SalePrice).HasColumnType("decimal(18,2)");
                
                
                entity.HasOne(s => s.Vehicle)
                      .WithOne(v => v.Sale)
                      .HasForeignKey<Sale>(s => s.VehicleId)
                      .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(s => s.Customer)
                      .WithMany(c => c.Sales)
                      .HasForeignKey(s => s.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
} 
