using CarSelling.Shared.Models;

namespace CarSelling.Api.Data;

public static class SampleDataSeeder
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
        {
            var toyotaId = brandLookup["Toyota"];
            modelsToAdd.AddRange(new[]
            {
                new CarModel { Name = "Camry", CarBrandId = toyotaId, Category = "Sedan", StartYear = 1982 },
                new CarModel { Name = "Corolla", CarBrandId = toyotaId, Category = "Sedan", StartYear = 1966 },
                new CarModel { Name = "Prius", CarBrandId = toyotaId, Category = "Hybrid", StartYear = 1997 },
                new CarModel { Name = "RAV4", CarBrandId = toyotaId, Category = "SUV", StartYear = 1994 },
                new CarModel { Name = "Highlander", CarBrandId = toyotaId, Category = "SUV", StartYear = 2000 },
                new CarModel { Name = "4Runner", CarBrandId = toyotaId, Category = "SUV", StartYear = 1984 },
                new CarModel { Name = "Tacoma", CarBrandId = toyotaId, Category = "Truck", StartYear = 1995 },
                new CarModel { Name = "Tundra", CarBrandId = toyotaId, Category = "Truck", StartYear = 1999 },
                new CarModel { Name = "Sienna", CarBrandId = toyotaId, Category = "Van", StartYear = 1997 },
                new CarModel { Name = "Avalon", CarBrandId = toyotaId, Category = "Sedan", StartYear = 1994 },
                new CarModel { Name = "Venza", CarBrandId = toyotaId, Category = "SUV", StartYear = 2008 }
            });
        }

        // Honda Models
        if (brandLookup.ContainsKey("Honda"))
        {
            var hondaId = brandLookup["Honda"];
            modelsToAdd.AddRange(new[]
            {
                new CarModel { Name = "Accord", CarBrandId = hondaId, Category = "Sedan", StartYear = 1976 },
                new CarModel { Name = "Civic", CarBrandId = hondaId, Category = "Sedan", StartYear = 1972 },
                new CarModel { Name = "CR-V", CarBrandId = hondaId, Category = "SUV", StartYear = 1995 },
                new CarModel { Name = "Pilot", CarBrandId = hondaId, Category = "SUV", StartYear = 2002 },
                new CarModel { Name = "Passport", CarBrandId = hondaId, Category = "SUV", StartYear = 1993 },
                new CarModel { Name = "Ridgeline", CarBrandId = hondaId, Category = "Truck", StartYear = 2005 },
                new CarModel { Name = "Odyssey", CarBrandId = hondaId, Category = "Van", StartYear = 1994 },
                new CarModel { Name = "HR-V", CarBrandId = hondaId, Category = "SUV", StartYear = 2014 },
                new CarModel { Name = "Insight", CarBrandId = hondaId, Category = "Hybrid", StartYear = 1999 }
            });
        }

        // Ford Models
        if (brandLookup.ContainsKey("Ford"))
        {
            var fordId = brandLookup["Ford"];
            modelsToAdd.AddRange(new[]
            {
                new CarModel { Name = "F-150", CarBrandId = fordId, Category = "Truck", StartYear = 1948 },
                new CarModel { Name = "Mustang", CarBrandId = fordId, Category = "Coupe", StartYear = 1964 },
                new CarModel { Name = "Explorer", CarBrandId = fordId, Category = "SUV", StartYear = 1990 },
                new CarModel { Name = "Edge", CarBrandId = fordId, Category = "SUV", StartYear = 2006 },
                new CarModel { Name = "Escape", CarBrandId = fordId, Category = "SUV", StartYear = 2000 },
                new CarModel { Name = "Expedition", CarBrandId = fordId, Category = "SUV", StartYear = 1996 },
                new CarModel { Name = "Bronco", CarBrandId = fordId, Category = "SUV", StartYear = 1965 },
                new CarModel { Name = "Ranger", CarBrandId = fordId, Category = "Truck", StartYear = 1982 }
            });
        }

        // BMW Models
        if (brandLookup.ContainsKey("BMW"))
        {
            var bmwId = brandLookup["BMW"];
            modelsToAdd.AddRange(new[]
            {
                new CarModel { Name = "3 Series", CarBrandId = bmwId, Category = "Sedan", StartYear = 1975 },
                new CarModel { Name = "5 Series", CarBrandId = bmwId, Category = "Sedan", StartYear = 1972 },
                new CarModel { Name = "7 Series", CarBrandId = bmwId, Category = "Sedan", StartYear = 1977 },
                new CarModel { Name = "X3", CarBrandId = bmwId, Category = "SUV", StartYear = 2003 },
                new CarModel { Name = "X5", CarBrandId = bmwId, Category = "SUV", StartYear = 1999 },
                new CarModel { Name = "X7", CarBrandId = bmwId, Category = "SUV", StartYear = 2018 },
                new CarModel { Name = "4 Series", CarBrandId = bmwId, Category = "Coupe", StartYear = 2013 },
                new CarModel { Name = "M3", CarBrandId = bmwId, Category = "Sedan", StartYear = 1985 },
                new CarModel { Name = "M5", CarBrandId = bmwId, Category = "Sedan", StartYear = 1984 }
            });
        }

        // Tesla Models
        if (brandLookup.ContainsKey("Tesla"))
        {
            var teslaId = brandLookup["Tesla"];
            modelsToAdd.AddRange(new[]
            {
                new CarModel { Name = "Model S", CarBrandId = teslaId, Category = "Sedan", StartYear = 2012 },
                new CarModel { Name = "Model 3", CarBrandId = teslaId, Category = "Sedan", StartYear = 2017 },
                new CarModel { Name = "Model X", CarBrandId = teslaId, Category = "SUV", StartYear = 2015 },
                new CarModel { Name = "Model Y", CarBrandId = teslaId, Category = "SUV", StartYear = 2020 },
                new CarModel { Name = "Cybertruck", CarBrandId = teslaId, Category = "Truck", StartYear = 2024 }
            });
        }

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
            new User { Id = "user2", Name = "Sarah Wilson", Email = "sarah.wilson@email.com", Phone = "+1-555-0103", UserType = "Individual" },
            new User { Id = "user3", Name = "Mercedes Owner", Email = "mercedes.owner@email.com", Phone = "+1-555-0105", UserType = "Individual" },
            new User { Id = "user4", Name = "Truck Owner", Email = "truck.owner@email.com", Phone = "+1-555-0107", UserType = "Individual" },
            new User { Id = "user5", Name = "Outdoor Lover", Email = "outdoor.lover@email.com", Phone = "+1-555-0109", UserType = "Individual" },
            new User { Id = "user6", Name = "Jeep Enthusiast", Email = "jeep.enthusiast@email.com", Phone = "+1-555-0111", UserType = "Individual" },
            new User { Id = "user7", Name = "VW Owner", Email = "vw.owner@email.com", Phone = "+1-555-0113", UserType = "Individual" },
            new User { Id = "user8", Name = "Porsche Collector", Email = "porsche.collector@email.com", Phone = "+1-555-0115", UserType = "Individual" },

            // Dealer Users
            new User { Id = "dealer1", Name = "Acme Auto Sales", Email = "dealer@acmeauto.com", Phone = "+1-555-0102", UserType = "Dealer" },
            new User { Id = "dealer2", Name = "Luxury BMW Dealer", Email = "bmw.dealer@luxury.com", Phone = "+1-555-0104", UserType = "Dealer" },
            new User { Id = "dealer3", Name = "Premium Audi", Email = "audi.sales@premium.com", Phone = "+1-555-0106", UserType = "Dealer" },
            new User { Id = "dealer4", Name = "Chevy Auto", Email = "chevy.dealer@auto.com", Phone = "+1-555-0108", UserType = "Dealer" },
            new User { Id = "dealer5", Name = "Mazda Sales", Email = "mazda.sales@dealer.com", Phone = "+1-555-0110", UserType = "Dealer" },
            new User { Id = "dealer6", Name = "Hyundai Auto", Email = "hyundai.dealer@auto.com", Phone = "+1-555-0112", UserType = "Dealer" },
            new User { Id = "dealer7", Name = "Lexus Sales", Email = "lexus.sales@luxury.com", Phone = "+1-555-0114", UserType = "Dealer" }
        };

        context.Users.AddRange(users);
        await context.SaveChangesAsync();

        // Create sample car listings
        var carListings = new List<CarListing>
        {
            new CarListing
            {
                Title = "2022 Toyota Camry LE - Excellent Condition",
                Make = "Toyota",
                Model = "Camry",
                Year = 2022,
                Price = 28500.00m,
                Mileage = 15000,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Description = "Well-maintained 2022 Toyota Camry with low mileage. Single owner, garage kept, all maintenance records available. Perfect family sedan with excellent fuel economy.",
                Images = new List<string> { "https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=800" },
                ContactEmail = "john.smith@email.com",
                ContactPhone = "+1-555-0101",
                Location = "San Francisco, CA",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "user1"
            },
            new CarListing
            {
                Title = "2020 Honda Accord Sport - Manual Transmission",
                Make = "Honda",
                Model = "Accord",
                Year = 2020,
                Price = 26900.00m,
                Mileage = 32000,
                FuelType = "Gasoline",
                Transmission = "Manual",
                Description = "Sporty Honda Accord with rare manual transmission. Well maintained with minor cosmetic damage on rear bumper. Great for driving enthusiasts.",
                Images = new List<string> { "https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800", "https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800" },
                ContactEmail = "dealer@acmeauto.com",
                ContactPhone = "+1-555-0102",
                Location = "Los Angeles, CA",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "dealer1"
            },
            new CarListing
            {
                Title = "2023 Tesla Model 3 Standard Range Plus",
                Make = "Tesla",
                Model = "Model 3",
                Year = 2023,
                Price = 42000.00m,
                Mileage = 8000,
                FuelType = "Electric",
                Transmission = "Automatic",
                Description = "Like-new Tesla Model 3 with latest software updates. Includes Enhanced Autopilot and free Supercharging. Perfect electric vehicle for daily commuting.",
                Images = new List<string> { "https://images.unsplash.com/photo-1617788138017-80ad40651399?w=800", "https://images.unsplash.com/photo-1617788138017-80ad40651399?w=800" },
                ContactEmail = "sarah.wilson@email.com",
                ContactPhone = "+1-555-0103",
                Location = "Seattle, WA",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "user2"
            },
            new CarListing
            {
                Title = "2021 BMW 330i xDrive - Luxury Package",
                Make = "BMW",
                Model = "3 Series",
                Year = 2021,
                Price = 35900.00m,
                Mileage = 24000,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Description = "Premium BMW 3 Series with xDrive all-wheel drive. Loaded with luxury features including heated seats, premium sound system, and advanced driver assistance.",
                Images = new List<string> { "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=800", "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=800" },
                ContactEmail = "bmw.dealer@luxury.com",
                ContactPhone = "+1-555-0104",
                Location = "Austin, TX",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "dealer2"
            },
            new CarListing
            {
                Title = "2019 Mercedes-Benz C300 4MATIC",
                Make = "Mercedes",
                Model = "C-Class",
                Year = 2019,
                Price = 31500.00m,
                Mileage = 45000,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Description = "Elegant Mercedes-Benz C300 with 4MATIC all-wheel drive. Well-maintained with complete service history. Perfect luxury sedan for daily driving.",
                Images = new List<string> { "https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=800", "https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=800" },
                ContactEmail = "mercedes.owner@email.com",
                ContactPhone = "+1-555-0105",
                Location = "Miami, FL",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "user3"
            },
            new CarListing
            {
                Title = "2020 Audi A4 Premium Plus Quattro",
                Make = "Audi",
                Model = "A4",
                Year = 2020,
                Price = 33800.00m,
                Mileage = 28000,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Description = "Premium Audi A4 with Quattro all-wheel drive and Virtual Cockpit. Excellent condition with advanced technology features and superior build quality.",
                Images = new List<string> { "https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800", "https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800" },
                ContactEmail = "audi.sales@premium.com",
                ContactPhone = "+1-555-0106",
                Location = "Denver, CO",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "dealer3"
            },
            new CarListing
            {
                Title = "2021 Ford F-150 XLT SuperCrew 4WD",
                Make = "Ford",
                Model = "F-150",
                Year = 2021,
                Price = 41200.00m,
                Mileage = 35000,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Description = "Powerful Ford F-150 with EcoBoost engine and 4WD capability. Great for work and recreation. Minor scratches on bed liner, otherwise excellent condition.",
                Images = new List<string> { "https://images.unsplash.com/photo-1558618047-3c8c76ca7d13?w=800", "https://images.unsplash.com/photo-1558618047-3c8c76ca7d13?w=800" },
                ContactEmail = "truck.owner@email.com",
                ContactPhone = "+1-555-0107",
                Location = "Houston, TX",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "user4"
            },
            new CarListing
            {
                Title = "2020 Chevrolet Tahoe LT 4WD",
                Make = "Chevrolet",
                Model = "Tahoe",
                Year = 2020,
                Price = 47500.00m,
                Mileage = 38000,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Description = "Spacious Chevrolet Tahoe perfect for large families. Features third-row seating, powerful V8 engine, and excellent towing capacity.",
                Images = new List<string> { "https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800", "https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800" },
                ContactEmail = "chevy.dealer@auto.com",
                ContactPhone = "+1-555-0108",
                Location = "Phoenix, AZ",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "dealer4"
            },
            new CarListing
            {
                Title = "2022 Subaru Outback Touring XT",
                Make = "Subaru",
                Model = "Outback",
                Year = 2022,
                Price = 36200.00m,
                Mileage = 18000,
                FuelType = "Gasoline",
                Transmission = "CVT",
                Description = "Adventure-ready Subaru Outback with turbo engine and standard AWD. Perfect for outdoor enthusiasts with excellent ground clearance and cargo space.",
                Images = new List<string> { "https://images.unsplash.com/photo-1544880503-2f0f3b4d1e2c?w=800", "https://images.unsplash.com/photo-1544880503-2f0f3b4d1e2c?w=800" },
                ContactEmail = "outdoor.lover@email.com",
                ContactPhone = "+1-555-0109",
                Location = "Portland, OR",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "user5"
            },
            new CarListing
            {
                Title = "2021 Mazda CX-5 Grand Touring Reserve",
                Make = "Mazda",
                Model = "CX-5",
                Year = 2021,
                Price = 29800.00m,
                Mileage = 22000,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Description = "Premium Mazda CX-5 with turbo engine and luxurious interior. Excellent build quality with advanced safety features and refined driving experience.",
                Images = new List<string> { "https://images.unsplash.com/photo-1549317661-bd32c8ce0db2?w=800", "https://images.unsplash.com/photo-1549317661-bd32c8ce0db2?w=800" },
                ContactEmail = "mazda.sales@dealer.com",
                ContactPhone = "+1-555-0110",
                Location = "Atlanta, GA",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "dealer5"
            },
            new CarListing
            {
                Title = "2022 Jeep Wrangler Unlimited Sahara 4x4",
                Make = "Jeep",
                Model = "Wrangler",
                Year = 2022,
                Price = 38900.00m,
                Mileage = 12000,
                FuelType = "Gasoline",
                Transmission = "Manual",
                Description = "Iconic Jeep Wrangler with removable doors and roof. Perfect for off-road adventures with manual transmission and excellent 4x4 capability.",
                Images = new List<string> { "https://images.unsplash.com/photo-1606220838315-056192d5e927?w=800", "https://images.unsplash.com/photo-1606220838315-056192d5e927?w=800" },
                ContactEmail = "jeep.enthusiast@email.com",
                ContactPhone = "+1-555-0111",
                Location = "Salt Lake City, UT",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "user6"
            },
            new CarListing
            {
                Title = "2023 Hyundai Elantra SEL",
                Make = "Hyundai",
                Model = "Elantra",
                Year = 2023,
                Price = 23400.00m,
                Mileage = 8500,
                FuelType = "Gasoline",
                Transmission = "CVT",
                Description = "Brand new Hyundai Elantra with excellent fuel economy and modern features. Perfect first car or daily commuter with comprehensive warranty coverage.",
                Images = new List<string> { "https://images.unsplash.com/photo-1617531653332-bd46c24f2068?w=800", "https://images.unsplash.com/photo-1617531653332-bd46c24f2068?w=800" },
                ContactEmail = "hyundai.dealer@auto.com",
                ContactPhone = "+1-555-0112",
                Location = "Las Vegas, NV",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "dealer6"
            },
            new CarListing
            {
                Title = "2021 Volkswagen Golf GTI S",
                Make = "Volkswagen",
                Model = "Golf",
                Year = 2021,
                Price = 28900.00m,
                Mileage = 19000,
                FuelType = "Gasoline",
                Transmission = "Manual",
                Description = "Fun-to-drive Volkswagen Golf GTI with manual transmission. Perfect hot hatch with excellent handling and practical everyday usability.",
                Images = new List<string> { "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=800", "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=800" },
                ContactEmail = "vw.owner@email.com",
                ContactPhone = "+1-555-0113",
                Location = "Chicago, IL",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "user7"
            },
            new CarListing
            {
                Title = "2020 Lexus RX 350 F Sport",
                Make = "Lexus",
                Model = "RX",
                Year = 2020,
                Price = 44200.00m,
                Mileage = 31000,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Description = "Luxury Lexus RX 350 with F Sport package. Exceptional reliability and comfort with premium features and smooth V6 engine performance.",
                Images = new List<string> { "https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800", "https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800" },
                ContactEmail = "lexus.sales@luxury.com",
                ContactPhone = "+1-555-0114",
                Location = "San Diego, CA",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "dealer7"
            },
            new CarListing
            {
                Title = "2019 Porsche 911 Carrera S",
                Make = "Porsche",
                Model = "911",
                Year = 2019,
                Price = 89500.00m,
                Mileage = 15000,
                FuelType = "Gasoline",
                Transmission = "Semi-Automatic",
                Description = "Iconic Porsche 911 Carrera S in classic Guards Red. Meticulously maintained with complete service history. A true drivers car with timeless design.",
                Images = new List<string> { "https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800", "https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800" },
                ContactEmail = "porsche.collector@email.com",
                ContactPhone = "+1-555-0115",
                Location = "Beverly Hills, CA",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = "user8"
            }
        };

        context.CarListings.AddRange(carListings);
        await context.SaveChangesAsync();
    }
}