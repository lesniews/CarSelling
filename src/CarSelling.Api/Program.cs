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
        // Apply any pending migrations automatically
        logger.LogInformation("Applying database migrations...");
        await context.Database.MigrateAsync();
        logger.LogInformation("Database migrations applied successfully.");
        
        // Seed sample data if database is empty
        var hasData = await context.CarBrands.AnyAsync();
        if (!hasData)
        {
            logger.LogInformation("Seeding database with car brands and models...");
            await SampleDataSeeder.SeedSampleDataAsync(context);
            logger.LogInformation("Database seeding completed successfully.");
        }
        else
        {
            logger.LogInformation("Database already contains data, skipping seeding.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while initializing the database.");
        
        // Fallback to EnsureCreated in case of migration issues
        logger.LogWarning("Falling back to EnsureCreated approach...");
        if (app.Environment.IsDevelopment())
        {
            await context.Database.EnsureDeletedAsync();
        }
        await context.Database.EnsureCreatedAsync();
        await SampleDataSeeder.SeedSampleDataAsync(context);
        logger.LogInformation("Database initialized using fallback method.");
    }
}

app.Run();