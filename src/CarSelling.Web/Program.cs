using CarSelling.Web.Components;
using CarSelling.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Blazor Server services (standard approach)
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add HTTP client for API communication
builder.Services.AddHttpClient<ICarListingApiService, CarListingApiService>(client =>
{
    // Configure the API base address - use HTTP to avoid SSL certificate issues in development
    client.BaseAddress = new Uri("http://localhost:5004/");
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