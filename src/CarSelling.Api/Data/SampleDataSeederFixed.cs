using CarSelling.Shared.Models;

namespace CarSelling.Api.Data;

public static class SampleDataSeederFixed
{
    public static async Task SeedSampleDataAsync(CarSellingContext context)
    {
        Console.WriteLine("=== STARTING SAMPLE DATA SEEDING ===");
        
        // Clear existing data
        Console.WriteLine("Clearing existing data...");
        context.CarListings.RemoveRange(context.CarListings);
        context.Users.RemoveRange(context.Users);
        context.ModelGenerations.RemoveRange(context.ModelGenerations);
        context.CarModels.RemoveRange(context.CarModels);
        context.CarBrands.RemoveRange(context.CarBrands);
        await context.SaveChangesAsync();
        Console.WriteLine("Existing data cleared.");

        // Seed car brands first - reset IDs to let database auto-generate
        Console.WriteLine("Creating car brands...");
        var brandsToAdd = CarBrands.AllBrands.Select(b => new CarBrand 
        { 
            Name = b.Name, 
            Country = b.Country, 
            IsLuxury = b.IsLuxury, 
            IsActive = b.IsActive 
        }).ToList();
        
        Console.WriteLine($"Adding {brandsToAdd.Count} brands to context...");
        context.CarBrands.AddRange(brandsToAdd);
        await context.SaveChangesAsync();
        Console.WriteLine("Car brands saved to database.");

        // Get the actual brand IDs from database for model relationships
        var brandLookup = context.CarBrands.ToDictionary(b => b.Name, b => b.Id);

        // Seed all car models with correct brand IDs using comprehensive static data
        Console.WriteLine($"Creating car models from {CarModels.AllModels.Count} comprehensive models...");
        var modelsToAdd = new List<CarModel>();
        
        // Map all models from static data to database with correct brand IDs
        foreach (var staticModel in CarModels.AllModels)
        {
            // Find the brand name for this model
            var brandName = CarBrands.AllBrands.FirstOrDefault(b => b.Id == staticModel.CarBrandId)?.Name;
            if (!string.IsNullOrEmpty(brandName) && brandLookup.ContainsKey(brandName))
            {
                var actualBrandId = brandLookup[brandName];
                modelsToAdd.Add(new CarModel
                {
                    Name = staticModel.Name,
                    CarBrandId = actualBrandId,
                    Category = staticModel.Category,
                    StartYear = staticModel.StartYear,
                    EndYear = staticModel.EndYear,
                    IsActive = staticModel.IsActive
                });
            }
            else
            {
                Console.WriteLine($"Warning: Could not find brand '{brandName}' for model '{staticModel.Name}'");
            }
        }

        Console.WriteLine($"Successfully mapped {modelsToAdd.Count} models from static data");

        // Add all models to database
        context.CarModels.AddRange(modelsToAdd);
        await context.SaveChangesAsync();
        Console.WriteLine("Car models saved to database.");

        // Get the actual model IDs from database for generation relationships
        var modelLookup = context.CarModels.ToDictionary(m => new { m.CarBrandId, m.Name }, m => m.Id);

        // Seed model generations with correct model IDs
        Console.WriteLine("Creating model generations...");
        var generationsToAdd = new List<ModelGeneration>();

        // Map generations to correct model IDs using brand name and model name lookup
        Console.WriteLine($"Processing {ModelGenerations.AllGenerations.Count} generations...");
        
        foreach (var generation in ModelGenerations.AllGenerations)
        {
            // Find the model this generation belongs to by looking up the original model ID
            var originalModel = CarModels.AllModels.FirstOrDefault(m => m.Id == generation.CarModelId);
            if (originalModel != null)
            {
                // Find the brand name for this model
                var brandName = CarBrands.AllBrands.FirstOrDefault(b => b.Id == originalModel.CarBrandId)?.Name;
                Console.WriteLine($"Processing generation {generation.Name} for {brandName} {originalModel.Name}");
                
                if (!string.IsNullOrEmpty(brandName))
                {
                    // Find the actual database brand ID
                    var actualBrandId = brandLookup.GetValueOrDefault(brandName, -1);
                    if (actualBrandId != -1)
                    {
                        var modelKey = new { CarBrandId = actualBrandId, Name = originalModel.Name };
                        if (modelLookup.ContainsKey(modelKey))
                        {
                            var actualModelId = modelLookup[modelKey];
                            Console.WriteLine($"✅ Mapping generation {generation.Name} to database model ID {actualModelId}");
                            generationsToAdd.Add(new ModelGeneration
                            {
                                Name = generation.Name,
                                CarModelId = actualModelId,
                                StartYear = generation.StartYear,
                                EndYear = generation.EndYear,
                                Description = generation.Description,
                                IsActive = generation.IsActive
                            });
                        }
                        else
                        {
                            Console.WriteLine($"❌ Could not find model {originalModel.Name} for brand {brandName} (Brand ID: {actualBrandId})");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"❌ Could not find brand {brandName} in database");
                    }
                }
            }
            else
            {
                Console.WriteLine($"❌ Could not find original model for generation ID {generation.CarModelId}");
            }
        }

        Console.WriteLine($"Adding {generationsToAdd.Count} model generations to context...");
        context.ModelGenerations.AddRange(generationsToAdd);
        await context.SaveChangesAsync();
        Console.WriteLine("Model generations saved to database.");

        // Create sample users
        var users = new List<User>
        {
            // Individual Users
            new User { Id = "user1", Name = "John Smith", Email = "john.smith@email.com", Phone = "+1-555-0101", UserType = "Individual" },
            new User { Id = "user2", Name = "Sarah Johnson", Email = "sarah.johnson@email.com", Phone = "+1-555-0102", UserType = "Individual" },
            new User { Id = "user3", Name = "Michael Brown", Email = "michael.brown@email.com", Phone = "+1-555-0103", UserType = "Individual" },
            new User { Id = "user4", Name = "Emily Davis", Email = "emily.davis@email.com", Phone = "+1-555-0104", UserType = "Individual" },
            new User { Id = "user5", Name = "David Wilson", Email = "david.wilson@email.com", Phone = "+1-555-0105", UserType = "Individual" },
            new User { Id = "user6", Name = "Lisa Miller", Email = "lisa.miller@email.com", Phone = "+1-555-0106", UserType = "Individual" },
            new User { Id = "user7", Name = "James Anderson", Email = "james.anderson@email.com", Phone = "+1-555-0107", UserType = "Individual" },
            new User { Id = "user8", Name = "Jennifer Taylor", Email = "jennifer.taylor@email.com", Phone = "+1-555-0108", UserType = "Individual" },
            
            // Professional Dealers
            new User { Id = "dealer1", Name = "Premium Auto Sales", Email = "sales@premiumauto.com", Phone = "+1-555-0201", UserType = "Professional Dealer", CompanyName = "Premium Auto Sales", LicenseNumber = "DL001" },
            new User { Id = "dealer2", Name = "City Motors", Email = "info@citymotors.com", Phone = "+1-555-0202", UserType = "Professional Dealer", CompanyName = "City Motors", LicenseNumber = "DL002" },
            new User { Id = "dealer3", Name = "Elite Car Center", Email = "sales@elitecar.com", Phone = "+1-555-0203", UserType = "Professional Dealer", CompanyName = "Elite Car Center", LicenseNumber = "DL003" },
            new User { Id = "dealer4", Name = "AutoMax", Email = "contact@automax.com", Phone = "+1-555-0204", UserType = "Professional Dealer", CompanyName = "AutoMax", LicenseNumber = "DL004" },
            new User { Id = "dealer5", Name = "Royal Motors", Email = "sales@royalmotors.com", Phone = "+1-555-0205", UserType = "Professional Dealer", CompanyName = "Royal Motors", LicenseNumber = "DL005" },
            new User { Id = "dealer6", Name = "Grand Auto Gallery", Email = "info@grandauto.com", Phone = "+1-555-0206", UserType = "Professional Dealer", CompanyName = "Grand Auto Gallery", LicenseNumber = "DL006" },
            new User { Id = "dealer7", Name = "Luxury Car Depot", Email = "sales@luxurycar.com", Phone = "+1-555-0207", UserType = "Professional Dealer", CompanyName = "Luxury Car Depot", LicenseNumber = "DL007" }
        };

        context.Users.AddRange(users);
        await context.SaveChangesAsync();

        // Create sample car listings
        var carListings = new List<CarListing>
        {
            new CarListing
            {
                Title = "2022 Toyota Camry LE",
                Make = "Toyota",
                Model = "Camry",
                Year = 2022,
                Price = 28500.00m,
                Mileage = 15000,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Description = "Excellent condition Toyota Camry with low mileage. Well maintained, single owner, complete service history.",
                Images = new List<string> { "https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=800", "https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=800" },
                ContactEmail = "john.smith@email.com",
                ContactPhone = "+1-555-0101",
                Location = "Seattle, WA",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "user1"
            },
            new CarListing
            {
                Title = "2020 Honda Accord Sport",
                Make = "Honda",
                Model = "Accord",
                Year = 2020,
                Price = 24900.00m,
                Mileage = 35000,
                FuelType = "Gasoline",
                Transmission = "Manual",
                Description = "Sporty Honda Accord with manual transmission. Great handling and fuel economy. Perfect for enthusiasts.",
                Images = new List<string> { "https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800", "https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800" },
                ContactEmail = "sales@premiumauto.com",
                ContactPhone = "+1-555-0201",
                Location = "Portland, OR",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "dealer1"
            }
        };

        context.CarListings.AddRange(carListings);
        await context.SaveChangesAsync();
    }
}