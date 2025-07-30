var builder = DistributedApplication.CreateBuilder(args);

// For now, let's run the projects without containers to avoid complexity
// Add the Web API
var api = builder.AddProject("api", "../CarSelling.Api/CarSelling.Api.csproj");

// Add the Blazor Web App
builder.AddProject("web", "../CarSelling.Web/CarSelling.Web.csproj")
    .WithReference(api);

var app = builder.Build();
app.Run();