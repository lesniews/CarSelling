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
        logger.LogInformation("Starting database initialization...");
        
        // For development, let's use EnsureCreated to make sure we get the latest schema
        if (app.Environment.IsDevelopment())
        {
            logger.LogInformation("Development mode: Recreating database with latest schema...");
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            logger.LogInformation("Database recreated successfully.");
        }
        else
        {
            // In production, use migrations
            logger.LogInformation("Production mode: Applying database migrations...");
            await context.Database.MigrateAsync();
            logger.LogInformation("Database migrations applied successfully.");
        }
        
        // Always seed data in development, check if needed in production
        if (app.Environment.IsDevelopment())
        {
            logger.LogInformation("Development mode: Seeding database with sample data...");
            await SampleDataSeeder.SeedSampleDataAsync(context);
            logger.LogInformation("Database seeding completed successfully.");
        }
        else
        {
            var hasData = await context.CarBrands.AnyAsync();
            if (!hasData)
            {
                logger.LogInformation("Production mode: Database empty, seeding data...");
                await SampleDataSeeder.SeedSampleDataAsync(context);
                logger.LogInformation("Database seeding completed successfully.");
            }
        }
        
        // Verify the data was created
        var brandCount = await context.CarBrands.CountAsync();
        var modelCount = await context.CarModels.CountAsync();
        logger.LogInformation($"Database verification: {brandCount} brands, {modelCount} models");
        
        if (brandCount == 0)
        {
            logger.LogWarning("No car brands found in database after seeding!");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Critical error during database initialization: {Message}", ex.Message);
        throw; // Re-throw to see the full error
    }
}

app.Run();