using CarSelling.Shared.Models;

namespace CarSelling.Api.Data;

public static class SampleDataSeeder
{
    public static async Task SeedSampleDataAsync(CarSellingContext context)
    {
        // Clear existing data
        context.CarListings.RemoveRange(context.CarListings);
        context.Users.RemoveRange(context.Users);
        await context.SaveChangesAsync();

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