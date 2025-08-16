using CarSelling.Web.Components;
using CarSelling.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Blazor Server services (standard approach)
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add HTTP client for API communication
builder.Services.AddHttpClient<ICarListingApiService, CarListingApiService>(client =>
{
    // Get API base URL from configuration
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5004/";
    client.BaseAddress = new Uri(apiBaseUrl);
    Console.WriteLine($"Configured Car Listing API base URL: {apiBaseUrl}");
});

// Add HTTP client for car brands API
builder.Services.AddHttpClient<CarBrandApiService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5004/";
    client.BaseAddress = new Uri(apiBaseUrl);
    Console.WriteLine($"Configured Car Brand API base URL: {apiBaseUrl}");
});

// Add HTTP client for car models API
builder.Services.AddHttpClient<CarModelApiService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5004/";
    client.BaseAddress = new Uri(apiBaseUrl);
    Console.WriteLine($"Configured Car Model API base URL: {apiBaseUrl}");
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();