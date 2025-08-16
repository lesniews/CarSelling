using CarSelling.Api.Data;
using CarSelling.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Entity Framework - using connection string instead of Aspire for now
builder.Services.AddDbContext<CarSellingContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
        "Server=(localdb)\\mssqllocaldb;Database=CarSellingDb;Trusted_Connection=true;MultipleActiveResultSets=true";
    options.UseSqlServer(connectionString);
});

// Add services - Both old and new interfaces are now in the same service classes
builder.Services.AddScoped<ICarListingService, CarListingService>();
builder.Services.AddScoped<IExtendedCarListingService, ExtendedCarListingService>();
builder.Services.AddScoped<IUserService, UserService>();

// Add API services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

// Initialize database with migrations and seeding
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CarSellingContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    
    try
    {
        logger.LogInformation("=== STARTING DATABASE INITIALIZATION ===");
        logger.LogInformation($"Environment: {app.Environment.EnvironmentName}");
        logger.LogInformation($"Connection String: {context.Database.GetConnectionString()}");
        
        // Force development mode behavior for now
        logger.LogInformation("FORCE: Recreating database with latest schema...");
        await context.Database.EnsureDeletedAsync();
        logger.LogInformation("Database deleted successfully.");
        
        await context.Database.EnsureCreatedAsync();
        logger.LogInformation("Database created successfully.");
        
        // Check what tables were created
        var tableNames = context.Model.GetEntityTypes().Select(t => t.GetTableName()).ToList();
        logger.LogInformation($"Tables created: {string.Join(", ", tableNames)}");
        
        logger.LogInformation("FORCE: Seeding database with sample data...");
        await SampleDataSeeder.SeedSampleDataAsync(context);
        logger.LogInformation("Database seeding completed successfully.");
        
        // Verify the data was created
        var brandCount = await context.CarBrands.CountAsync();
        var modelCount = await context.CarModels.CountAsync();
        var listingCount = await context.CarListings.CountAsync();
        logger.LogInformation($"=== DATABASE VERIFICATION ===");
        logger.LogInformation($"Brands: {brandCount}");
        logger.LogInformation($"Models: {modelCount}"); 
        logger.LogInformation($"Listings: {listingCount}");
        
        if (brandCount == 0)
        {
            logger.LogError("CRITICAL: No car brands found in database after seeding!");
            
            // Let's try to manually add one brand to test
            logger.LogInformation("Attempting manual brand insertion...");
            var testBrand = new CarBrand { Name = "TestBrand", Country = "Test", IsActive = true };
            context.CarBrands.Add(testBrand);
            await context.SaveChangesAsync();
            logger.LogInformation("Manual brand inserted successfully.");
        }
        
        logger.LogInformation("=== DATABASE INITIALIZATION COMPLETE ===");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Critical error during database initialization: {Message}", ex.Message);
        throw; // Re-throw to see the full error
    }
}

app.Run();