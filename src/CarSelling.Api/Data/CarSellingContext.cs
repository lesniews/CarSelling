using CarSelling.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Api.Data;

public class CarSellingContext : DbContext
{
    public CarSellingContext(DbContextOptions<CarSellingContext> options) : base(options) { }

    public DbSet<CarListing> CarListings { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarListing>(entity =>
        {
            entity.HasKey(e => e.Id);

            // Basic required fields
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Make).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ContactEmail).IsRequired().HasMaxLength(100);

            // Decimal precision
            entity.Property(e => e.Price).HasColumnType("decimal(10,2)");

            // String length limits
            entity.Property(e => e.ModelGeneration).HasMaxLength(50);
            entity.Property(e => e.BodyType).HasMaxLength(30);
            entity.Property(e => e.FuelType).HasMaxLength(30);
            entity.Property(e => e.Transmission).HasMaxLength(30);
            entity.Property(e => e.EngineSize).HasMaxLength(20);
            entity.Property(e => e.Drivetrain).HasMaxLength(20);
            entity.Property(e => e.Condition).HasMaxLength(20);
            entity.Property(e => e.DamageStatus).HasMaxLength(30);
            entity.Property(e => e.CarStatus).HasMaxLength(30);
            entity.Property(e => e.FinancingOptions).HasMaxLength(100);
            entity.Property(e => e.ExteriorColor).HasMaxLength(30);
            entity.Property(e => e.InteriorColor).HasMaxLength(30);
            entity.Property(e => e.InteriorMaterial).HasMaxLength(30);
            entity.Property(e => e.SellerType).HasMaxLength(30);
            entity.Property(e => e.SellerRating).HasMaxLength(10);
            entity.Property(e => e.VIN).HasMaxLength(17);
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(30);
            entity.Property(e => e.ZipCode).HasMaxLength(10);
            entity.Property(e => e.VideoUrl).HasMaxLength(500);

            // JSON conversion for lists
            entity.Property(e => e.Images)
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

            entity.Property(e => e.Equipment)
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

            // Indexes for better query performance
            entity.HasIndex(e => e.Make);
            entity.HasIndex(e => e.Model);
            entity.HasIndex(e => e.Year);
            entity.HasIndex(e => e.Price);
            entity.HasIndex(e => e.Mileage);
            entity.HasIndex(e => e.FuelType);
            entity.HasIndex(e => e.BodyType);
            entity.HasIndex(e => e.Condition);
            entity.HasIndex(e => e.CreatedAt);
            entity.HasIndex(e => e.IsActive);
            entity.HasIndex(e => e.IsFeatured);

            // Default values
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ViewCount).HasDefaultValue(0);
            entity.Property(e => e.FavoriteCount).HasDefaultValue(0);
            entity.Property(e => e.AvailableDate).HasDefaultValueSql("GETUTCDATE()");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PreferredLocation).HasMaxLength(100);
            entity.Property(e => e.UserType).HasMaxLength(20);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.LicenseNumber).HasMaxLength(50);
            entity.Property(e => e.AverageRating).HasColumnType("decimal(3,2)");

            // Relationship
            entity.HasMany(e => e.Listings)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.UserType);

            // Default values
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UserType).HasDefaultValue("Individual");
            entity.Property(e => e.TotalListings).HasDefaultValue(0);
            entity.Property(e => e.SoldCars).HasDefaultValue(0);
            entity.Property(e => e.AverageRating).HasDefaultValue(0);
            entity.Property(e => e.ReviewCount).HasDefaultValue(0);
        });
    }
}