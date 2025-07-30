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

// Initialize database (recreate on each run during development)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CarSellingContext>();
    
    // Delete and recreate database to ensure schema changes are applied
    if (app.Environment.IsDevelopment())
    {
        await context.Database.EnsureDeletedAsync();
    }
    await context.Database.EnsureCreatedAsync();
    
    // Seed sample data on every startup in development
    if (app.Environment.IsDevelopment())
    {
        await SampleDataSeeder.SeedSampleDataAsync(context);
    }
}

app.Run();