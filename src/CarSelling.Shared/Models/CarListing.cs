using System.ComponentModel.DataAnnotations;

namespace CarSelling.Shared.Models;

public class CarListing
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    // Basic Vehicle Info
    [Required]
    [StringLength(50)]
    public string Make { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Model { get; set; } = string.Empty;

    [Range(1900, 2030)]
    public int Year { get; set; }

    [Range(0, 999999.99)]
    public decimal Price { get; set; }

    [Range(0, 999999)]
    public int Mileage { get; set; }

    // Extended Vehicle Details from Figma
    public string ModelGeneration { get; set; } = string.Empty;
    public string BodyType { get; set; } = string.Empty; // Sedan, SUV, Hatchback, etc.
    public string FuelType { get; set; } = string.Empty;
    public string Transmission { get; set; } = string.Empty;

    // Engine & Drive
    public string EngineSize { get; set; } = string.Empty; // e.g., "2.0L", "3.5L V6"
    public int? Horsepower { get; set; }
    public string Drivetrain { get; set; } = string.Empty; // FWD, RWD, AWD, 4WD
    public int? FuelEconomyCity { get; set; } // MPG
    public int? FuelEconomyHighway { get; set; } // MPG

    // Car Status from Figma
    public string Condition { get; set; } = string.Empty; // Excellent, Very Good, Good, etc.
    public string DamageStatus { get; set; } = string.Empty; // No damage, Minor damage, etc.
    public string CarStatus { get; set; } = string.Empty; // Clean title, Salvage, etc.

    // Financial Options
    public string FinancingOptions { get; set; } = string.Empty; // Loan available, Cash only, etc.
    public bool TradeInAccepted { get; set; }
    public bool NegotiablePrice { get; set; }

    // Equipment/Features (from checkboxes in Figma)
    public List<string> Equipment { get; set; } = new(); // Air Conditioning, Navigation, etc.

    // Colors & Interior
    public string ExteriorColor { get; set; } = string.Empty;
    public string InteriorColor { get; set; } = string.Empty;
    public string InteriorMaterial { get; set; } = string.Empty; // Leather, Cloth, etc.

    // Vehicle History
    public int? PreviousOwners { get; set; }
    public bool AccidentHistory { get; set; }
    public bool ServiceHistoryAvailable { get; set; }
    public string VIN { get; set; } = string.Empty;

    // Seller Information
    public string SellerType { get; set; } = string.Empty; // Private Seller, Professional Dealer
    public string SellerRating { get; set; } = string.Empty; // For dealer ratings

    // Media
    public List<string> Images { get; set; } = new();
    public string VideoUrl { get; set; } = string.Empty;
    public bool Has360View { get; set; }

    // Existing fields
    public string Description { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string ContactEmail { get; set; } = string.Empty;

    [Phone]
    public string ContactPhone { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;

    // Availability
    public DateTime AvailableDate { get; set; }
    public bool TestDriveAvailable { get; set; }
    public bool ViewingAppointmentRequired { get; set; }

    // System fields
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; }
    public string UserId { get; set; } = string.Empty;

    // Statistics tracking
    public int ViewCount { get; set; }
    public int FavoriteCount { get; set; }
    public DateTime LastViewedAt { get; set; }
}

// Equipment/Features enum for consistent data
public static class CarEquipment
{
    public static readonly List<string> AvailableEquipment = new()
    {
        "Air Conditioning",
        "Autopilot",
        "Backup Camera",
        "Bang & Olufsen Audio",
        "Bed Liner",
        "Bluetooth",
        "Cruise Control",
        "Driver Assistance",
        "Harman Kardon Audio",
        "Leather Seats",
        "MMI Navigation",
        "Mobile Connector",
        "Navigation",
        "Panoramic Roof",
        "Power Seats",
        "Premium Audio",
        "Premium Interior",
        "Premium Package",
        "Running Boards",
        "Sport Package",
        "Sunroof",
        "Supercharging",
        "Towing Package",
        "Virtual Cockpit"
    };
}

// Body Types enum
public static class BodyTypes
{
    public static readonly List<string> Types = new()
    {
        "Sedan",
        "SUV",
        "Hatchback",
        "Coupe",
        "Convertible",
        "Wagon",
        "Truck",
        "Van",
        "Crossover"
    };
}

// Fuel Types
public static class FuelTypes
{
    public static readonly List<string> Types = new()
    {
        "Gasoline",
        "Diesel",
        "Hybrid",
        "Electric",
        "Plug-in Hybrid"
    };
}

// Transmission Types
public static class TransmissionTypes
{
    public static readonly List<string> Types = new()
    {
        "Manual",
        "Automatic",
        "CVT",
        "Semi-Automatic"
    };
}

// Car Brands
public class CarBrand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsLuxury { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public List<CarModel> Models { get; set; } = new();
}

// Car Models
public class CarModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CarBrandId { get; set; }
    public CarBrand CarBrand { get; set; } = null!;
    public string Category { get; set; } = string.Empty; // Sedan, SUV, Truck, etc.
    public int StartYear { get; set; } = 1990;
    public int? EndYear { get; set; } // null if still in production
    public bool IsActive { get; set; } = true;
    public List<ModelGeneration> Generations { get; set; } = new();
}

// Model Generations
public class ModelGeneration
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CarModelId { get; set; }
    public CarModel CarModel { get; set; } = null!;
    public int StartYear { get; set; }
    public int? EndYear { get; set; } // null if still in production
    public string Description { get; set; } = string.Empty; // e.g., "Facelift", "Major redesign"
    public bool IsActive { get; set; } = true;
}

// Comprehensive list of car brands
public static class CarBrands
{
    public static readonly List<CarBrand> AllBrands = new()
    {
        // German Brands
        new CarBrand { Id = 1, Name = "Audi", Country = "Germany", IsLuxury = true },
        new CarBrand { Id = 2, Name = "BMW", Country = "Germany", IsLuxury = true },
        new CarBrand { Id = 3, Name = "Mercedes-Benz", Country = "Germany", IsLuxury = true },
        new CarBrand { Id = 4, Name = "Porsche", Country = "Germany", IsLuxury = true },
        new CarBrand { Id = 5, Name = "Volkswagen", Country = "Germany" },
        new CarBrand { Id = 6, Name = "Opel", Country = "Germany" },
        new CarBrand { Id = 7, Name = "Smart", Country = "Germany" },
        new CarBrand { Id = 8, Name = "Maybach", Country = "Germany", IsLuxury = true },
        
        // American Brands
        new CarBrand { Id = 9, Name = "Ford", Country = "USA" },
        new CarBrand { Id = 10, Name = "Chevrolet", Country = "USA" },
        new CarBrand { Id = 11, Name = "Cadillac", Country = "USA", IsLuxury = true },
        new CarBrand { Id = 12, Name = "Buick", Country = "USA" },
        new CarBrand { Id = 13, Name = "GMC", Country = "USA" },
        new CarBrand { Id = 14, Name = "Chrysler", Country = "USA" },
        new CarBrand { Id = 15, Name = "Dodge", Country = "USA" },
        new CarBrand { Id = 16, Name = "Jeep", Country = "USA" },
        new CarBrand { Id = 17, Name = "Ram", Country = "USA" },
        new CarBrand { Id = 18, Name = "Lincoln", Country = "USA", IsLuxury = true },
        new CarBrand { Id = 19, Name = "Tesla", Country = "USA", IsLuxury = true },
        
        // Japanese Brands
        new CarBrand { Id = 20, Name = "Toyota", Country = "Japan" },
        new CarBrand { Id = 21, Name = "Honda", Country = "Japan" },
        new CarBrand { Id = 22, Name = "Nissan", Country = "Japan" },
        new CarBrand { Id = 23, Name = "Mazda", Country = "Japan" },
        new CarBrand { Id = 24, Name = "Subaru", Country = "Japan" },
        new CarBrand { Id = 25, Name = "Mitsubishi", Country = "Japan" },
        new CarBrand { Id = 26, Name = "Suzuki", Country = "Japan" },
        new CarBrand { Id = 27, Name = "Lexus", Country = "Japan", IsLuxury = true },
        new CarBrand { Id = 28, Name = "Acura", Country = "Japan", IsLuxury = true },
        new CarBrand { Id = 29, Name = "Infiniti", Country = "Japan", IsLuxury = true },
        
        // Korean Brands
        new CarBrand { Id = 30, Name = "Hyundai", Country = "South Korea" },
        new CarBrand { Id = 31, Name = "Kia", Country = "South Korea" },
        new CarBrand { Id = 32, Name = "Genesis", Country = "South Korea", IsLuxury = true },
        
        // British Brands
        new CarBrand { Id = 33, Name = "Jaguar", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 34, Name = "Land Rover", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 35, Name = "Bentley", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 36, Name = "Rolls-Royce", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 37, Name = "Aston Martin", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 38, Name = "McLaren", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 39, Name = "Lotus", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 40, Name = "Mini", Country = "UK" },
        
        // Italian Brands
        new CarBrand { Id = 41, Name = "Ferrari", Country = "Italy", IsLuxury = true },
        new CarBrand { Id = 42, Name = "Lamborghini", Country = "Italy", IsLuxury = true },
        new CarBrand { Id = 43, Name = "Maserati", Country = "Italy", IsLuxury = true },
        new CarBrand { Id = 44, Name = "Alfa Romeo", Country = "Italy", IsLuxury = true },
        new CarBrand { Id = 45, Name = "Fiat", Country = "Italy" },
        new CarBrand { Id = 46, Name = "Lancia", Country = "Italy" },
        new CarBrand { Id = 47, Name = "Pagani", Country = "Italy", IsLuxury = true },
        
        // French Brands
        new CarBrand { Id = 48, Name = "Peugeot", Country = "France" },
        new CarBrand { Id = 49, Name = "Renault", Country = "France" },
        new CarBrand { Id = 50, Name = "Citroën", Country = "France" },
        new CarBrand { Id = 51, Name = "Bugatti", Country = "France", IsLuxury = true },
        new CarBrand { Id = 52, Name = "Alpine", Country = "France", IsLuxury = true },
        
        // Swedish Brands
        new CarBrand { Id = 53, Name = "Volvo", Country = "Sweden" },
        new CarBrand { Id = 54, Name = "Saab", Country = "Sweden" },
        new CarBrand { Id = 55, Name = "Polestar", Country = "Sweden", IsLuxury = true },
        new CarBrand { Id = 56, Name = "Koenigsegg", Country = "Sweden", IsLuxury = true },
        
        // Czech Brands
        new CarBrand { Id = 57, Name = "Škoda", Country = "Czech Republic" },
        
        // Spanish Brands
        new CarBrand { Id = 58, Name = "SEAT", Country = "Spain" },
        new CarBrand { Id = 59, Name = "Cupra", Country = "Spain" },
        
        // Chinese Brands
        new CarBrand { Id = 60, Name = "BYD", Country = "China" },
        new CarBrand { Id = 61, Name = "Geely", Country = "China" },
        new CarBrand { Id = 62, Name = "Great Wall", Country = "China" },
        new CarBrand { Id = 63, Name = "Chery", Country = "China" },
        new CarBrand { Id = 64, Name = "NIO", Country = "China", IsLuxury = true },
        new CarBrand { Id = 65, Name = "Xpeng", Country = "China" },
        new CarBrand { Id = 66, Name = "Li Auto", Country = "China" },
        
        // Other Notable Brands
        new CarBrand { Id = 67, Name = "Dacia", Country = "Romania" },
        new CarBrand { Id = 68, Name = "Lada", Country = "Russia" },
        new CarBrand { Id = 69, Name = "Tata", Country = "India" },
        new CarBrand { Id = 70, Name = "Mahindra", Country = "India" },
        new CarBrand { Id = 71, Name = "Proton", Country = "Malaysia" },
        new CarBrand { Id = 72, Name = "Perodua", Country = "Malaysia" },
        
        // Electric Vehicle Brands
        new CarBrand { Id = 73, Name = "Rivian", Country = "USA", IsLuxury = true },
        new CarBrand { Id = 74, Name = "Lucid", Country = "USA", IsLuxury = true },
        new CarBrand { Id = 75, Name = "Fisker", Country = "USA", IsLuxury = true },
        
        // Defunct/Classic Brands (still valuable for used cars)
        new CarBrand { Id = 76, Name = "Pontiac", Country = "USA", IsActive = false },
        new CarBrand { Id = 77, Name = "Saturn", Country = "USA", IsActive = false },
        new CarBrand { Id = 78, Name = "Oldsmobile", Country = "USA", IsActive = false },
        new CarBrand { Id = 79, Name = "Plymouth", Country = "USA", IsActive = false },
        new CarBrand { Id = 80, Name = "Mercury", Country = "USA", IsActive = false },
        new CarBrand { Id = 81, Name = "Hummer", Country = "USA", IsActive = false },
        new CarBrand { Id = 82, Name = "Scion", Country = "Japan", IsActive = false },
        
        // Specialty/Rare Brands
        new CarBrand { Id = 83, Name = "Morgan", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 84, Name = "Caterham", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 85, Name = "TVR", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 86, Name = "Noble", Country = "UK", IsLuxury = true },
        new CarBrand { Id = 87, Name = "Spyker", Country = "Netherlands", IsLuxury = true },
        new CarBrand { Id = 88, Name = "Zenvo", Country = "Denmark", IsLuxury = true },
        new CarBrand { Id = 89, Name = "Rimac", Country = "Croatia", IsLuxury = true }
    };
}

// Comprehensive list of car models
public static class CarModels
{
    public static readonly List<CarModel> AllModels = new()
    {
        // Toyota Models (Brand ID: 20)
        new CarModel { Id = 1, Name = "Camry", CarBrandId = 20, Category = "Sedan", StartYear = 1982 },
        new CarModel { Id = 2, Name = "Corolla", CarBrandId = 20, Category = "Sedan", StartYear = 1966 },
        new CarModel { Id = 3, Name = "Prius", CarBrandId = 20, Category = "Hybrid", StartYear = 1997 },
        new CarModel { Id = 4, Name = "RAV4", CarBrandId = 20, Category = "SUV", StartYear = 1994 },
        new CarModel { Id = 5, Name = "Highlander", CarBrandId = 20, Category = "SUV", StartYear = 2000 },
        new CarModel { Id = 6, Name = "4Runner", CarBrandId = 20, Category = "SUV", StartYear = 1984 },
        new CarModel { Id = 7, Name = "Tacoma", CarBrandId = 20, Category = "Truck", StartYear = 1995 },
        new CarModel { Id = 8, Name = "Tundra", CarBrandId = 20, Category = "Truck", StartYear = 1999 },
        new CarModel { Id = 9, Name = "Sienna", CarBrandId = 20, Category = "Van", StartYear = 1997 },
        new CarModel { Id = 10, Name = "Avalon", CarBrandId = 20, Category = "Sedan", StartYear = 1994 },
        new CarModel { Id = 11, Name = "Venza", CarBrandId = 20, Category = "SUV", StartYear = 2008 },

        // Honda Models (Brand ID: 21)
        new CarModel { Id = 12, Name = "Accord", CarBrandId = 21, Category = "Sedan", StartYear = 1976 },
        new CarModel { Id = 13, Name = "Civic", CarBrandId = 21, Category = "Sedan", StartYear = 1972 },
        new CarModel { Id = 14, Name = "CR-V", CarBrandId = 21, Category = "SUV", StartYear = 1995 },
        new CarModel { Id = 15, Name = "Pilot", CarBrandId = 21, Category = "SUV", StartYear = 2002 },
        new CarModel { Id = 16, Name = "Passport", CarBrandId = 21, Category = "SUV", StartYear = 1993 },
        new CarModel { Id = 17, Name = "Ridgeline", CarBrandId = 21, Category = "Truck", StartYear = 2005 },
        new CarModel { Id = 18, Name = "Odyssey", CarBrandId = 21, Category = "Van", StartYear = 1994 },
        new CarModel { Id = 19, Name = "HR-V", CarBrandId = 21, Category = "SUV", StartYear = 2014 },
        new CarModel { Id = 20, Name = "Insight", CarBrandId = 21, Category = "Hybrid", StartYear = 1999 },
        new CarModel { Id = 21, Name = "Fit", CarBrandId = 21, Category = "Hatchback", StartYear = 2006, EndYear = 2020 },

        // Ford Models (Brand ID: 9)
        new CarModel { Id = 22, Name = "F-150", CarBrandId = 9, Category = "Truck", StartYear = 1948 },
        new CarModel { Id = 23, Name = "Mustang", CarBrandId = 9, Category = "Coupe", StartYear = 1964 },
        new CarModel { Id = 24, Name = "Explorer", CarBrandId = 9, Category = "SUV", StartYear = 1990 },
        new CarModel { Id = 25, Name = "Edge", CarBrandId = 9, Category = "SUV", StartYear = 2006 },
        new CarModel { Id = 26, Name = "Escape", CarBrandId = 9, Category = "SUV", StartYear = 2000 },
        new CarModel { Id = 27, Name = "Expedition", CarBrandId = 9, Category = "SUV", StartYear = 1996 },
        new CarModel { Id = 28, Name = "Bronco", CarBrandId = 9, Category = "SUV", StartYear = 1965 },
        new CarModel { Id = 29, Name = "Ranger", CarBrandId = 9, Category = "Truck", StartYear = 1982 },
        new CarModel { Id = 30, Name = "Fusion", CarBrandId = 9, Category = "Sedan", StartYear = 2005, EndYear = 2020 },
        new CarModel { Id = 31, Name = "Focus", CarBrandId = 9, Category = "Hatchback", StartYear = 1998, EndYear = 2018 },

        // Chevrolet Models (Brand ID: 10)
        new CarModel { Id = 32, Name = "Silverado", CarBrandId = 10, Category = "Truck", StartYear = 1998 },
        new CarModel { Id = 33, Name = "Equinox", CarBrandId = 10, Category = "SUV", StartYear = 2004 },
        new CarModel { Id = 34, Name = "Tahoe", CarBrandId = 10, Category = "SUV", StartYear = 1994 },
        new CarModel { Id = 35, Name = "Suburban", CarBrandId = 10, Category = "SUV", StartYear = 1934 },
        new CarModel { Id = 36, Name = "Traverse", CarBrandId = 10, Category = "SUV", StartYear = 2008 },
        new CarModel { Id = 37, Name = "Camaro", CarBrandId = 10, Category = "Coupe", StartYear = 1966 },
        new CarModel { Id = 38, Name = "Corvette", CarBrandId = 10, Category = "Coupe", StartYear = 1953 },
        new CarModel { Id = 39, Name = "Malibu", CarBrandId = 10, Category = "Sedan", StartYear = 1964 },
        new CarModel { Id = 40, Name = "Impala", CarBrandId = 10, Category = "Sedan", StartYear = 1958, EndYear = 2020 },
        new CarModel { Id = 41, Name = "Blazer", CarBrandId = 10, Category = "SUV", StartYear = 1969 },

        // BMW Models (Brand ID: 2)
        new CarModel { Id = 42, Name = "3 Series", CarBrandId = 2, Category = "Sedan", StartYear = 1975 },
        new CarModel { Id = 43, Name = "5 Series", CarBrandId = 2, Category = "Sedan", StartYear = 1972 },
        new CarModel { Id = 44, Name = "7 Series", CarBrandId = 2, Category = "Sedan", StartYear = 1977 },
        new CarModel { Id = 45, Name = "X3", CarBrandId = 2, Category = "SUV", StartYear = 2003 },
        new CarModel { Id = 46, Name = "X5", CarBrandId = 2, Category = "SUV", StartYear = 1999 },
        new CarModel { Id = 47, Name = "X7", CarBrandId = 2, Category = "SUV", StartYear = 2018 },
        new CarModel { Id = 48, Name = "4 Series", CarBrandId = 2, Category = "Coupe", StartYear = 2013 },
        new CarModel { Id = 49, Name = "M3", CarBrandId = 2, Category = "Sedan", StartYear = 1985 },
        new CarModel { Id = 50, Name = "M5", CarBrandId = 2, Category = "Sedan", StartYear = 1984 },
        new CarModel { Id = 51, Name = "X1", CarBrandId = 2, Category = "SUV", StartYear = 2009 },

        // Mercedes-Benz Models (Brand ID: 3)
        new CarModel { Id = 52, Name = "C-Class", CarBrandId = 3, Category = "Sedan", StartYear = 1993 },
        new CarModel { Id = 53, Name = "E-Class", CarBrandId = 3, Category = "Sedan", StartYear = 1993 },
        new CarModel { Id = 54, Name = "S-Class", CarBrandId = 3, Category = "Sedan", StartYear = 1972 },
        new CarModel { Id = 55, Name = "GLE", CarBrandId = 3, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 56, Name = "GLC", CarBrandId = 3, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 57, Name = "G-Class", CarBrandId = 3, Category = "SUV", StartYear = 1979 },
        new CarModel { Id = 58, Name = "A-Class", CarBrandId = 3, Category = "Hatchback", StartYear = 1997 },
        new CarModel { Id = 59, Name = "CLA", CarBrandId = 3, Category = "Sedan", StartYear = 2013 },
        new CarModel { Id = 60, Name = "GLS", CarBrandId = 3, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 61, Name = "AMG GT", CarBrandId = 3, Category = "Coupe", StartYear = 2014 },

        // Audi Models (Brand ID: 1)
        new CarModel { Id = 62, Name = "A3", CarBrandId = 1, Category = "Sedan", StartYear = 1996 },
        new CarModel { Id = 63, Name = "A4", CarBrandId = 1, Category = "Sedan", StartYear = 1994 },
        new CarModel { Id = 64, Name = "A6", CarBrandId = 1, Category = "Sedan", StartYear = 1994 },
        new CarModel { Id = 65, Name = "A8", CarBrandId = 1, Category = "Sedan", StartYear = 1994 },
        new CarModel { Id = 66, Name = "Q3", CarBrandId = 1, Category = "SUV", StartYear = 2011 },
        new CarModel { Id = 67, Name = "Q5", CarBrandId = 1, Category = "SUV", StartYear = 2008 },
        new CarModel { Id = 68, Name = "Q7", CarBrandId = 1, Category = "SUV", StartYear = 2005 },
        new CarModel { Id = 69, Name = "Q8", CarBrandId = 1, Category = "SUV", StartYear = 2018 },
        new CarModel { Id = 70, Name = "TT", CarBrandId = 1, Category = "Coupe", StartYear = 1998 },
        new CarModel { Id = 71, Name = "R8", CarBrandId = 1, Category = "Coupe", StartYear = 2006 },

        // Tesla Models (Brand ID: 19)
        new CarModel { Id = 72, Name = "Model S", CarBrandId = 19, Category = "Sedan", StartYear = 2012 },
        new CarModel { Id = 73, Name = "Model 3", CarBrandId = 19, Category = "Sedan", StartYear = 2017 },
        new CarModel { Id = 74, Name = "Model X", CarBrandId = 19, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 75, Name = "Model Y", CarBrandId = 19, Category = "SUV", StartYear = 2020 },
        new CarModel { Id = 76, Name = "Cybertruck", CarBrandId = 19, Category = "Truck", StartYear = 2024 },
        new CarModel { Id = 77, Name = "Roadster", CarBrandId = 19, Category = "Coupe", StartYear = 2008, EndYear = 2012 },

        // Nissan Models (Brand ID: 22)
        new CarModel { Id = 78, Name = "Altima", CarBrandId = 22, Category = "Sedan", StartYear = 1992 },
        new CarModel { Id = 79, Name = "Sentra", CarBrandId = 22, Category = "Sedan", StartYear = 1982 },
        new CarModel { Id = 80, Name = "Rogue", CarBrandId = 22, Category = "SUV", StartYear = 2007 },
        new CarModel { Id = 81, Name = "Murano", CarBrandId = 22, Category = "SUV", StartYear = 2002 },
        new CarModel { Id = 82, Name = "Pathfinder", CarBrandId = 22, Category = "SUV", StartYear = 1985 },
        new CarModel { Id = 83, Name = "Armada", CarBrandId = 22, Category = "SUV", StartYear = 2003 },
        new CarModel { Id = 84, Name = "Frontier", CarBrandId = 22, Category = "Truck", StartYear = 1997 },
        new CarModel { Id = 85, Name = "Titan", CarBrandId = 22, Category = "Truck", StartYear = 2003 },
        new CarModel { Id = 86, Name = "370Z", CarBrandId = 22, Category = "Coupe", StartYear = 2008 },
        new CarModel { Id = 87, Name = "GT-R", CarBrandId = 22, Category = "Coupe", StartYear = 2007 },

        // Hyundai Models (Brand ID: 30)
        new CarModel { Id = 88, Name = "Elantra", CarBrandId = 30, Category = "Sedan", StartYear = 1990 },
        new CarModel { Id = 89, Name = "Sonata", CarBrandId = 30, Category = "Sedan", StartYear = 1985 },
        new CarModel { Id = 90, Name = "Tucson", CarBrandId = 30, Category = "SUV", StartYear = 2004 },
        new CarModel { Id = 91, Name = "Santa Fe", CarBrandId = 30, Category = "SUV", StartYear = 2000 },
        new CarModel { Id = 92, Name = "Palisade", CarBrandId = 30, Category = "SUV", StartYear = 2018 },
        new CarModel { Id = 93, Name = "Accent", CarBrandId = 30, Category = "Sedan", StartYear = 1994 },
        new CarModel { Id = 94, Name = "Veloster", CarBrandId = 30, Category = "Hatchback", StartYear = 2011 },
        new CarModel { Id = 95, Name = "Ioniq", CarBrandId = 30, Category = "Hybrid", StartYear = 2016 },

        // Kia Models (Brand ID: 31)
        new CarModel { Id = 96, Name = "Forte", CarBrandId = 31, Category = "Sedan", StartYear = 2008 },
        new CarModel { Id = 97, Name = "Optima", CarBrandId = 31, Category = "Sedan", StartYear = 2000, EndYear = 2020 },
        new CarModel { Id = 98, Name = "K5", CarBrandId = 31, Category = "Sedan", StartYear = 2020 },
        new CarModel { Id = 99, Name = "Sorento", CarBrandId = 31, Category = "SUV", StartYear = 2002 },
        new CarModel { Id = 100, Name = "Sportage", CarBrandId = 31, Category = "SUV", StartYear = 1993 },
        new CarModel { Id = 101, Name = "Telluride", CarBrandId = 31, Category = "SUV", StartYear = 2019 },
        new CarModel { Id = 102, Name = "Soul", CarBrandId = 31, Category = "Hatchback", StartYear = 2008 },
        new CarModel { Id = 103, Name = "Stinger", CarBrandId = 31, Category = "Sedan", StartYear = 2017 },

        // Mazda Models (Brand ID: 23)
        new CarModel { Id = 104, Name = "Mazda3", CarBrandId = 23, Category = "Sedan", StartYear = 2003 },
        new CarModel { Id = 105, Name = "Mazda6", CarBrandId = 23, Category = "Sedan", StartYear = 2002 },
        new CarModel { Id = 106, Name = "CX-3", CarBrandId = 23, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 107, Name = "CX-5", CarBrandId = 23, Category = "SUV", StartYear = 2012 },
        new CarModel { Id = 108, Name = "CX-9", CarBrandId = 23, Category = "SUV", StartYear = 2006 },
        new CarModel { Id = 109, Name = "MX-5 Miata", CarBrandId = 23, Category = "Convertible", StartYear = 1989 },
        new CarModel { Id = 110, Name = "CX-30", CarBrandId = 23, Category = "SUV", StartYear = 2019 },

        // Subaru Models (Brand ID: 24)
        new CarModel { Id = 111, Name = "Outback", CarBrandId = 24, Category = "SUV", StartYear = 1994 },
        new CarModel { Id = 112, Name = "Forester", CarBrandId = 24, Category = "SUV", StartYear = 1997 },
        new CarModel { Id = 113, Name = "Impreza", CarBrandId = 24, Category = "Sedan", StartYear = 1992 },
        new CarModel { Id = 114, Name = "Legacy", CarBrandId = 24, Category = "Sedan", StartYear = 1989 },
        new CarModel { Id = 115, Name = "Ascent", CarBrandId = 24, Category = "SUV", StartYear = 2018 },
        new CarModel { Id = 116, Name = "Crosstrek", CarBrandId = 24, Category = "SUV", StartYear = 2012 },
        new CarModel { Id = 117, Name = "WRX", CarBrandId = 24, Category = "Sedan", StartYear = 2001 },
        new CarModel { Id = 118, Name = "BRZ", CarBrandId = 24, Category = "Coupe", StartYear = 2012 },

        // Volkswagen Models (Brand ID: 5)
        new CarModel { Id = 119, Name = "Jetta", CarBrandId = 5, Category = "Sedan", StartYear = 1979 },
        new CarModel { Id = 120, Name = "Passat", CarBrandId = 5, Category = "Sedan", StartYear = 1973 },
        new CarModel { Id = 121, Name = "Golf", CarBrandId = 5, Category = "Hatchback", StartYear = 1974 },
        new CarModel { Id = 122, Name = "Tiguan", CarBrandId = 5, Category = "SUV", StartYear = 2007 },
        new CarModel { Id = 123, Name = "Atlas", CarBrandId = 5, Category = "SUV", StartYear = 2017 },
        new CarModel { Id = 124, Name = "Arteon", CarBrandId = 5, Category = "Sedan", StartYear = 2017 },
        new CarModel { Id = 125, Name = "Beetle", CarBrandId = 5, Category = "Hatchback", StartYear = 1938, EndYear = 2019 },
        new CarModel { Id = 126, Name = "ID.4", CarBrandId = 5, Category = "SUV", StartYear = 2020 },

        // Lexus Models (Brand ID: 27)
        new CarModel { Id = 127, Name = "ES", CarBrandId = 27, Category = "Sedan", StartYear = 1989 },
        new CarModel { Id = 128, Name = "IS", CarBrandId = 27, Category = "Sedan", StartYear = 1999 },
        new CarModel { Id = 129, Name = "GS", CarBrandId = 27, Category = "Sedan", StartYear = 1991, EndYear = 2020 },
        new CarModel { Id = 130, Name = "LS", CarBrandId = 27, Category = "Sedan", StartYear = 1989 },
        new CarModel { Id = 131, Name = "RX", CarBrandId = 27, Category = "SUV", StartYear = 1997 },
        new CarModel { Id = 132, Name = "GX", CarBrandId = 27, Category = "SUV", StartYear = 2002 },
        new CarModel { Id = 133, Name = "LX", CarBrandId = 27, Category = "SUV", StartYear = 1995 },
        new CarModel { Id = 134, Name = "NX", CarBrandId = 27, Category = "SUV", StartYear = 2014 },
        new CarModel { Id = 135, Name = "UX", CarBrandId = 27, Category = "SUV", StartYear = 2018 },

        // Jeep Models (Brand ID: 16)
        new CarModel { Id = 136, Name = "Wrangler", CarBrandId = 16, Category = "SUV", StartYear = 1986 },
        new CarModel { Id = 137, Name = "Grand Cherokee", CarBrandId = 16, Category = "SUV", StartYear = 1992 },
        new CarModel { Id = 138, Name = "Cherokee", CarBrandId = 16, Category = "SUV", StartYear = 1974 },
        new CarModel { Id = 139, Name = "Compass", CarBrandId = 16, Category = "SUV", StartYear = 2006 },
        new CarModel { Id = 140, Name = "Renegade", CarBrandId = 16, Category = "SUV", StartYear = 2014 },
        new CarModel { Id = 141, Name = "Gladiator", CarBrandId = 16, Category = "Truck", StartYear = 2019 },
        new CarModel { Id = 142, Name = "Grand Wagoneer", CarBrandId = 16, Category = "SUV", StartYear = 2021 },

        // Porsche Models (Brand ID: 4)
        new CarModel { Id = 143, Name = "911", CarBrandId = 4, Category = "Coupe", StartYear = 1963 },
        new CarModel { Id = 144, Name = "Cayenne", CarBrandId = 4, Category = "SUV", StartYear = 2002 },
        new CarModel { Id = 145, Name = "Macan", CarBrandId = 4, Category = "SUV", StartYear = 2014 },
        new CarModel { Id = 146, Name = "Panamera", CarBrandId = 4, Category = "Sedan", StartYear = 2009 },
        new CarModel { Id = 147, Name = "718 Boxster", CarBrandId = 4, Category = "Convertible", StartYear = 1996 },
        new CarModel { Id = 148, Name = "718 Cayman", CarBrandId = 4, Category = "Coupe", StartYear = 2005 },
        new CarModel { Id = 149, Name = "Taycan", CarBrandId = 4, Category = "Sedan", StartYear = 2019 },

        // Acura Models (Brand ID: 26)
        new CarModel { Id = 150, Name = "TLX", CarBrandId = 26, Category = "Sedan", StartYear = 2014 },
        new CarModel { Id = 151, Name = "ILX", CarBrandId = 26, Category = "Sedan", StartYear = 2012 },
        new CarModel { Id = 152, Name = "RDX", CarBrandId = 26, Category = "SUV", StartYear = 2006 },
        new CarModel { Id = 153, Name = "MDX", CarBrandId = 26, Category = "SUV", StartYear = 2000 },
        new CarModel { Id = 154, Name = "NSX", CarBrandId = 26, Category = "Coupe", StartYear = 1990 },
        new CarModel { Id = 155, Name = "Integra", CarBrandId = 26, Category = "Sedan", StartYear = 2021 },

        // Alfa Romeo Models (Brand ID: 6)
        new CarModel { Id = 156, Name = "Giulia", CarBrandId = 6, Category = "Sedan", StartYear = 2016 },
        new CarModel { Id = 157, Name = "Stelvio", CarBrandId = 6, Category = "SUV", StartYear = 2016 },
        new CarModel { Id = 158, Name = "4C", CarBrandId = 6, Category = "Coupe", StartYear = 2013 },
        new CarModel { Id = 159, Name = "Tonale", CarBrandId = 6, Category = "SUV", StartYear = 2022 },

        // Aston Martin Models (Brand ID: 7)
        new CarModel { Id = 160, Name = "DB11", CarBrandId = 7, Category = "Coupe", StartYear = 2016 },
        new CarModel { Id = 161, Name = "Vantage", CarBrandId = 7, Category = "Coupe", StartYear = 2005 },
        new CarModel { Id = 162, Name = "DBS", CarBrandId = 7, Category = "Coupe", StartYear = 2007 },
        new CarModel { Id = 163, Name = "DBX", CarBrandId = 7, Category = "SUV", StartYear = 2020 },

        // Bentley Models (Brand ID: 8)
        new CarModel { Id = 164, Name = "Continental GT", CarBrandId = 8, Category = "Coupe", StartYear = 2003 },
        new CarModel { Id = 165, Name = "Bentayga", CarBrandId = 8, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 166, Name = "Flying Spur", CarBrandId = 8, Category = "Sedan", StartYear = 2005 },
        new CarModel { Id = 167, Name = "Mulsanne", CarBrandId = 8, Category = "Sedan", StartYear = 2010, EndYear = 2020 },

        // Bugatti Models (Brand ID: 9)
        new CarModel { Id = 168, Name = "Chiron", CarBrandId = 9, Category = "Coupe", StartYear = 2016 },
        new CarModel { Id = 169, Name = "Veyron", CarBrandId = 9, Category = "Coupe", StartYear = 2005, EndYear = 2015 },
        new CarModel { Id = 170, Name = "Divo", CarBrandId = 9, Category = "Coupe", StartYear = 2018 },

        // Buick Models (Brand ID: 10)
        new CarModel { Id = 171, Name = "Enclave", CarBrandId = 10, Category = "SUV", StartYear = 2007 },
        new CarModel { Id = 172, Name = "Encore", CarBrandId = 10, Category = "SUV", StartYear = 2012 },
        new CarModel { Id = 173, Name = "Envision", CarBrandId = 10, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 174, Name = "Lacrosse", CarBrandId = 10, Category = "Sedan", StartYear = 2004 },
        new CarModel { Id = 175, Name = "Regal", CarBrandId = 10, Category = "Sedan", StartYear = 1973 },

        // Cadillac Models (Brand ID: 11)
        new CarModel { Id = 176, Name = "Escalade", CarBrandId = 11, Category = "SUV", StartYear = 1998 },
        new CarModel { Id = 177, Name = "XT5", CarBrandId = 11, Category = "SUV", StartYear = 2016 },
        new CarModel { Id = 178, Name = "XT6", CarBrandId = 11, Category = "SUV", StartYear = 2019 },
        new CarModel { Id = 179, Name = "CT5", CarBrandId = 11, Category = "Sedan", StartYear = 2019 },
        new CarModel { Id = 180, Name = "CT4", CarBrandId = 11, Category = "Sedan", StartYear = 2019 },
        new CarModel { Id = 181, Name = "Lyriq", CarBrandId = 11, Category = "SUV", StartYear = 2022 },

        // Chevrolet Models (Brand ID: 12)
        new CarModel { Id = 182, Name = "Silverado", CarBrandId = 12, Category = "Truck", StartYear = 1998 },
        new CarModel { Id = 183, Name = "Tahoe", CarBrandId = 12, Category = "SUV", StartYear = 1994 },
        new CarModel { Id = 184, Name = "Suburban", CarBrandId = 12, Category = "SUV", StartYear = 1935 },
        new CarModel { Id = 185, Name = "Equinox", CarBrandId = 12, Category = "SUV", StartYear = 2004 },
        new CarModel { Id = 186, Name = "Traverse", CarBrandId = 12, Category = "SUV", StartYear = 2008 },
        new CarModel { Id = 187, Name = "Malibu", CarBrandId = 12, Category = "Sedan", StartYear = 1964 },
        new CarModel { Id = 188, Name = "Camaro", CarBrandId = 12, Category = "Coupe", StartYear = 1966 },
        new CarModel { Id = 189, Name = "Corvette", CarBrandId = 12, Category = "Coupe", StartYear = 1953 },
        new CarModel { Id = 190, Name = "Blazer", CarBrandId = 12, Category = "SUV", StartYear = 1969 },

        // Chrysler Models (Brand ID: 13)
        new CarModel { Id = 191, Name = "300", CarBrandId = 13, Category = "Sedan", StartYear = 2004 },
        new CarModel { Id = 192, Name = "Pacifica", CarBrandId = 13, Category = "Van", StartYear = 2016 },
        new CarModel { Id = 193, Name = "Voyager", CarBrandId = 13, Category = "Van", StartYear = 2019 },

        // Dodge Models (Brand ID: 14)
        new CarModel { Id = 194, Name = "Charger", CarBrandId = 14, Category = "Sedan", StartYear = 1966 },
        new CarModel { Id = 195, Name = "Challenger", CarBrandId = 14, Category = "Coupe", StartYear = 1969 },
        new CarModel { Id = 196, Name = "Durango", CarBrandId = 14, Category = "SUV", StartYear = 1997 },
        new CarModel { Id = 197, Name = "Journey", CarBrandId = 14, Category = "SUV", StartYear = 2008, EndYear = 2020 },
        new CarModel { Id = 198, Name = "Grand Caravan", CarBrandId = 14, Category = "Van", StartYear = 1983, EndYear = 2020 },

        // Ferrari Models (Brand ID: 15)
        new CarModel { Id = 199, Name = "488", CarBrandId = 15, Category = "Coupe", StartYear = 2015, EndYear = 2019 },
        new CarModel { Id = 200, Name = "F8 Tributo", CarBrandId = 15, Category = "Coupe", StartYear = 2019 },
        new CarModel { Id = 201, Name = "SF90 Stradale", CarBrandId = 15, Category = "Coupe", StartYear = 2019 },
        new CarModel { Id = 202, Name = "Roma", CarBrandId = 15, Category = "Coupe", StartYear = 2020 },
        new CarModel { Id = 203, Name = "Portofino", CarBrandId = 15, Category = "Convertible", StartYear = 2017 },
        new CarModel { Id = 204, Name = "812 Superfast", CarBrandId = 15, Category = "Coupe", StartYear = 2017 },

        // Fiat Models (Brand ID: 17)
        new CarModel { Id = 205, Name = "500", CarBrandId = 17, Category = "Hatchback", StartYear = 2007 },
        new CarModel { Id = 206, Name = "500X", CarBrandId = 17, Category = "SUV", StartYear = 2014 },
        new CarModel { Id = 207, Name = "500L", CarBrandId = 17, Category = "Hatchback", StartYear = 2012 },
        new CarModel { Id = 208, Name = "124 Spider", CarBrandId = 17, Category = "Convertible", StartYear = 2016 },

        // Ford Models (Brand ID: 18)
        new CarModel { Id = 209, Name = "F-150", CarBrandId = 18, Category = "Truck", StartYear = 1975 },
        new CarModel { Id = 210, Name = "Explorer", CarBrandId = 18, Category = "SUV", StartYear = 1990 },
        new CarModel { Id = 211, Name = "Escape", CarBrandId = 18, Category = "SUV", StartYear = 2000 },
        new CarModel { Id = 212, Name = "Edge", CarBrandId = 18, Category = "SUV", StartYear = 2006 },
        new CarModel { Id = 213, Name = "Expedition", CarBrandId = 18, Category = "SUV", StartYear = 1996 },
        new CarModel { Id = 214, Name = "Mustang", CarBrandId = 18, Category = "Coupe", StartYear = 1964 },
        new CarModel { Id = 215, Name = "Bronco", CarBrandId = 18, Category = "SUV", StartYear = 1965 },
        new CarModel { Id = 216, Name = "Ranger", CarBrandId = 18, Category = "Truck", StartYear = 1982 },
        new CarModel { Id = 217, Name = "Fusion", CarBrandId = 18, Category = "Sedan", StartYear = 2005, EndYear = 2020 },

        // Genesis Models (Brand ID: 20)
        new CarModel { Id = 218, Name = "G90", CarBrandId = 20, Category = "Sedan", StartYear = 2016 },
        new CarModel { Id = 219, Name = "G80", CarBrandId = 20, Category = "Sedan", StartYear = 2016 },
        new CarModel { Id = 220, Name = "G70", CarBrandId = 20, Category = "Sedan", StartYear = 2017 },
        new CarModel { Id = 221, Name = "GV70", CarBrandId = 20, Category = "SUV", StartYear = 2021 },
        new CarModel { Id = 222, Name = "GV80", CarBrandId = 20, Category = "SUV", StartYear = 2020 },

        // GMC Models (Brand ID: 21)
        new CarModel { Id = 223, Name = "Sierra", CarBrandId = 21, Category = "Truck", StartYear = 1987 },
        new CarModel { Id = 224, Name = "Yukon", CarBrandId = 21, Category = "SUV", StartYear = 1991 },
        new CarModel { Id = 225, Name = "Acadia", CarBrandId = 21, Category = "SUV", StartYear = 2006 },
        new CarModel { Id = 226, Name = "Terrain", CarBrandId = 21, Category = "SUV", StartYear = 2009 },
        new CarModel { Id = 227, Name = "Canyon", CarBrandId = 21, Category = "Truck", StartYear = 2003 },
        new CarModel { Id = 228, Name = "Savana", CarBrandId = 21, Category = "Van", StartYear = 1995 },

        // Infiniti Models (Brand ID: 25)
        new CarModel { Id = 229, Name = "Q50", CarBrandId = 25, Category = "Sedan", StartYear = 2013 },
        new CarModel { Id = 230, Name = "Q60", CarBrandId = 25, Category = "Coupe", StartYear = 2016 },
        new CarModel { Id = 231, Name = "QX50", CarBrandId = 25, Category = "SUV", StartYear = 2008 },
        new CarModel { Id = 232, Name = "QX60", CarBrandId = 25, Category = "SUV", StartYear = 2012 },
        new CarModel { Id = 233, Name = "QX80", CarBrandId = 25, Category = "SUV", StartYear = 2010 },

        // Jaguar Models (Brand ID: 28)
        new CarModel { Id = 234, Name = "XE", CarBrandId = 28, Category = "Sedan", StartYear = 2015 },
        new CarModel { Id = 235, Name = "XF", CarBrandId = 28, Category = "Sedan", StartYear = 2007 },
        new CarModel { Id = 236, Name = "XJ", CarBrandId = 28, Category = "Sedan", StartYear = 1968, EndYear = 2019 },
        new CarModel { Id = 237, Name = "F-PACE", CarBrandId = 28, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 238, Name = "E-PACE", CarBrandId = 28, Category = "SUV", StartYear = 2017 },
        new CarModel { Id = 239, Name = "I-PACE", CarBrandId = 28, Category = "SUV", StartYear = 2018 },
        new CarModel { Id = 240, Name = "F-TYPE", CarBrandId = 28, Category = "Coupe", StartYear = 2013 },

        // Lamborghini Models (Brand ID: 29)
        new CarModel { Id = 241, Name = "Huracán", CarBrandId = 29, Category = "Coupe", StartYear = 2014 },
        new CarModel { Id = 242, Name = "Aventador", CarBrandId = 29, Category = "Coupe", StartYear = 2011 },
        new CarModel { Id = 243, Name = "Urus", CarBrandId = 29, Category = "SUV", StartYear = 2017 },
        new CarModel { Id = 244, Name = "Gallardo", CarBrandId = 29, Category = "Coupe", StartYear = 2003, EndYear = 2013 },

        // Land Rover Models (Brand ID: 32)
        new CarModel { Id = 245, Name = "Range Rover", CarBrandId = 32, Category = "SUV", StartYear = 1970 },
        new CarModel { Id = 246, Name = "Range Rover Sport", CarBrandId = 32, Category = "SUV", StartYear = 2005 },
        new CarModel { Id = 247, Name = "Range Rover Evoque", CarBrandId = 32, Category = "SUV", StartYear = 2011 },
        new CarModel { Id = 248, Name = "Discovery", CarBrandId = 32, Category = "SUV", StartYear = 1989 },
        new CarModel { Id = 249, Name = "Discovery Sport", CarBrandId = 32, Category = "SUV", StartYear = 2014 },
        new CarModel { Id = 250, Name = "Defender", CarBrandId = 32, Category = "SUV", StartYear = 1983 },

        // Lincoln Models (Brand ID: 33)
        new CarModel { Id = 251, Name = "Navigator", CarBrandId = 33, Category = "SUV", StartYear = 1997 },
        new CarModel { Id = 252, Name = "Aviator", CarBrandId = 33, Category = "SUV", StartYear = 2019 },
        new CarModel { Id = 253, Name = "Corsair", CarBrandId = 33, Category = "SUV", StartYear = 2019 },
        new CarModel { Id = 254, Name = "Nautilus", CarBrandId = 33, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 255, Name = "Continental", CarBrandId = 33, Category = "Sedan", StartYear = 1939 },

        // Lotus Models (Brand ID: 34)
        new CarModel { Id = 256, Name = "Evora", CarBrandId = 34, Category = "Coupe", StartYear = 2009 },
        new CarModel { Id = 257, Name = "Elise", CarBrandId = 34, Category = "Convertible", StartYear = 1996, EndYear = 2021 },
        new CarModel { Id = 258, Name = "Exige", CarBrandId = 34, Category = "Coupe", StartYear = 2000, EndYear = 2021 },
        new CarModel { Id = 259, Name = "Emira", CarBrandId = 34, Category = "Coupe", StartYear = 2021 },

        // Maserati Models (Brand ID: 35)
        new CarModel { Id = 260, Name = "Ghibli", CarBrandId = 35, Category = "Sedan", StartYear = 2013 },
        new CarModel { Id = 261, Name = "Quattroporte", CarBrandId = 35, Category = "Sedan", StartYear = 2003 },
        new CarModel { Id = 262, Name = "Levante", CarBrandId = 35, Category = "SUV", StartYear = 2016 },
        new CarModel { Id = 263, Name = "GranTurismo", CarBrandId = 35, Category = "Coupe", StartYear = 2007 },

        // McLaren Models (Brand ID: 36)
        new CarModel { Id = 264, Name = "720S", CarBrandId = 36, Category = "Coupe", StartYear = 2017 },
        new CarModel { Id = 265, Name = "570S", CarBrandId = 36, Category = "Coupe", StartYear = 2015, EndYear = 2021 },
        new CarModel { Id = 266, Name = "600LT", CarBrandId = 36, Category = "Coupe", StartYear = 2018, EndYear = 2020 },
        new CarModel { Id = 267, Name = "GT", CarBrandId = 36, Category = "Coupe", StartYear = 2019 },

        // Mini Models (Brand ID: 37)
        new CarModel { Id = 268, Name = "Cooper", CarBrandId = 37, Category = "Hatchback", StartYear = 2001 },
        new CarModel { Id = 269, Name = "Countryman", CarBrandId = 37, Category = "SUV", StartYear = 2010 },
        new CarModel { Id = 270, Name = "Clubman", CarBrandId = 37, Category = "Hatchback", StartYear = 2007 },
        new CarModel { Id = 271, Name = "Convertible", CarBrandId = 37, Category = "Convertible", StartYear = 2004 },

        // Mitsubishi Models (Brand ID: 38)
        new CarModel { Id = 272, Name = "Outlander", CarBrandId = 38, Category = "SUV", StartYear = 2001 },
        new CarModel { Id = 273, Name = "Eclipse Cross", CarBrandId = 38, Category = "SUV", StartYear = 2017 },
        new CarModel { Id = 274, Name = "Mirage", CarBrandId = 38, Category = "Hatchback", StartYear = 1978 },
        new CarModel { Id = 275, Name = "Lancer", CarBrandId = 38, Category = "Sedan", StartYear = 1973, EndYear = 2017 },

        // Ram Models (Brand ID: 39)
        new CarModel { Id = 276, Name = "1500", CarBrandId = 39, Category = "Truck", StartYear = 2010 },
        new CarModel { Id = 277, Name = "2500", CarBrandId = 39, Category = "Truck", StartYear = 2010 },
        new CarModel { Id = 278, Name = "3500", CarBrandId = 39, Category = "Truck", StartYear = 2010 },
        new CarModel { Id = 279, Name = "ProMaster", CarBrandId = 39, Category = "Van", StartYear = 2013 },

        // Rolls-Royce Models (Brand ID: 40)
        new CarModel { Id = 280, Name = "Phantom", CarBrandId = 40, Category = "Sedan", StartYear = 2003 },
        new CarModel { Id = 281, Name = "Ghost", CarBrandId = 40, Category = "Sedan", StartYear = 2009 },
        new CarModel { Id = 282, Name = "Wraith", CarBrandId = 40, Category = "Coupe", StartYear = 2013 },
        new CarModel { Id = 283, Name = "Dawn", CarBrandId = 40, Category = "Convertible", StartYear = 2015 },
        new CarModel { Id = 284, Name = "Cullinan", CarBrandId = 40, Category = "SUV", StartYear = 2018 },

        // Smart Models (Brand ID: 41)
        new CarModel { Id = 285, Name = "fortwo", CarBrandId = 41, Category = "Hatchback", StartYear = 1998 },
        new CarModel { Id = 286, Name = "forfour", CarBrandId = 41, Category = "Hatchback", StartYear = 2004 },

        // Volvo Models (Brand ID: 42)
        new CarModel { Id = 287, Name = "XC90", CarBrandId = 42, Category = "SUV", StartYear = 2002 },
        new CarModel { Id = 288, Name = "XC60", CarBrandId = 42, Category = "SUV", StartYear = 2008 },
        new CarModel { Id = 289, Name = "XC40", CarBrandId = 42, Category = "SUV", StartYear = 2017 },
        new CarModel { Id = 290, Name = "S90", CarBrandId = 42, Category = "Sedan", StartYear = 2016 },
        new CarModel { Id = 291, Name = "S60", CarBrandId = 42, Category = "Sedan", StartYear = 2000 },
        new CarModel { Id = 292, Name = "V90", CarBrandId = 42, Category = "Wagon", StartYear = 2016 },
        new CarModel { Id = 293, Name = "V60", CarBrandId = 42, Category = "Wagon", StartYear = 2010 },

        // Additional popular international brands
        // Dacia Models (Brand ID: 43)
        new CarModel { Id = 294, Name = "Sandero", CarBrandId = 43, Category = "Hatchback", StartYear = 2007 },
        new CarModel { Id = 295, Name = "Duster", CarBrandId = 43, Category = "SUV", StartYear = 2009 },
        new CarModel { Id = 296, Name = "Logan", CarBrandId = 43, Category = "Sedan", StartYear = 2004 },

        // Lada Models (Brand ID: 44)
        new CarModel { Id = 297, Name = "Vesta", CarBrandId = 44, Category = "Sedan", StartYear = 2015 },
        new CarModel { Id = 298, Name = "Granta", CarBrandId = 44, Category = "Sedan", StartYear = 2011 },
        new CarModel { Id = 299, Name = "Niva", CarBrandId = 44, Category = "SUV", StartYear = 1977 },

        // Peugeot Models (Brand ID: 45)
        new CarModel { Id = 300, Name = "208", CarBrandId = 45, Category = "Hatchback", StartYear = 2012 },
        new CarModel { Id = 301, Name = "308", CarBrandId = 45, Category = "Hatchback", StartYear = 2007 },
        new CarModel { Id = 302, Name = "3008", CarBrandId = 45, Category = "SUV", StartYear = 2008 },
        new CarModel { Id = 303, Name = "5008", CarBrandId = 45, Category = "SUV", StartYear = 2009 },

        // Renault Models (Brand ID: 46)
        new CarModel { Id = 304, Name = "Clio", CarBrandId = 46, Category = "Hatchback", StartYear = 1990 },
        new CarModel { Id = 305, Name = "Megane", CarBrandId = 46, Category = "Hatchback", StartYear = 1995 },
        new CarModel { Id = 306, Name = "Captur", CarBrandId = 46, Category = "SUV", StartYear = 2013 },
        new CarModel { Id = 307, Name = "Kadjar", CarBrandId = 46, Category = "SUV", StartYear = 2015 },

        // Citroën Models (Brand ID: 47)
        new CarModel { Id = 308, Name = "C3", CarBrandId = 47, Category = "Hatchback", StartYear = 2002 },
        new CarModel { Id = 309, Name = "C4", CarBrandId = 47, Category = "Hatchback", StartYear = 2004 },
        new CarModel { Id = 310, Name = "C5 Aircross", CarBrandId = 47, Category = "SUV", StartYear = 2017 },

        // Skoda Models (Brand ID: 48)
        new CarModel { Id = 311, Name = "Octavia", CarBrandId = 48, Category = "Sedan", StartYear = 1996 },
        new CarModel { Id = 312, Name = "Superb", CarBrandId = 48, Category = "Sedan", StartYear = 2001 },
        new CarModel { Id = 313, Name = "Kodiaq", CarBrandId = 48, Category = "SUV", StartYear = 2016 },
        new CarModel { Id = 314, Name = "Karoq", CarBrandId = 48, Category = "SUV", StartYear = 2017 },

        // SEAT Models (Brand ID: 49)
        new CarModel { Id = 315, Name = "Leon", CarBrandId = 49, Category = "Hatchback", StartYear = 1999 },
        new CarModel { Id = 316, Name = "Ibiza", CarBrandId = 49, Category = "Hatchback", StartYear = 1984 },
        new CarModel { Id = 317, Name = "Ateca", CarBrandId = 49, Category = "SUV", StartYear = 2016 },

        // Opel Models (Brand ID: 50)
        new CarModel { Id = 318, Name = "Astra", CarBrandId = 50, Category = "Hatchback", StartYear = 1991 },
        new CarModel { Id = 319, Name = "Corsa", CarBrandId = 50, Category = "Hatchback", StartYear = 1982 },
        new CarModel { Id = 320, Name = "Crossland", CarBrandId = 50, Category = "SUV", StartYear = 2017 },

        // Additional Asian brands
        // Suzuki Models (Brand ID: 51)
        new CarModel { Id = 321, Name = "Swift", CarBrandId = 51, Category = "Hatchback", StartYear = 1983 },
        new CarModel { Id = 322, Name = "Vitara", CarBrandId = 51, Category = "SUV", StartYear = 1988 },
        new CarModel { Id = 323, Name = "Jimny", CarBrandId = 51, Category = "SUV", StartYear = 1970 },

        // Isuzu Models (Brand ID: 52)
        new CarModel { Id = 324, Name = "D-Max", CarBrandId = 52, Category = "Truck", StartYear = 2002 },
        new CarModel { Id = 325, Name = "MU-X", CarBrandId = 52, Category = "SUV", StartYear = 2013 },

        // Great Wall Models (Brand ID: 53)
        new CarModel { Id = 326, Name = "Wingle", CarBrandId = 53, Category = "Truck", StartYear = 2006 },
        new CarModel { Id = 327, Name = "Haval H6", CarBrandId = 53, Category = "SUV", StartYear = 2011 },

        // BYD Models (Brand ID: 54)
        new CarModel { Id = 328, Name = "Tang", CarBrandId = 54, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 329, Name = "Han", CarBrandId = 54, Category = "Sedan", StartYear = 2020 },
        new CarModel { Id = 330, Name = "Qin", CarBrandId = 54, Category = "Sedan", StartYear = 2012 },

        // Geely Models (Brand ID: 55)
        new CarModel { Id = 331, Name = "Coolray", CarBrandId = 55, Category = "SUV", StartYear = 2018 },
        new CarModel { Id = 332, Name = "Emgrand", CarBrandId = 55, Category = "Sedan", StartYear = 2009 },

        // Chery Models (Brand ID: 56)
        new CarModel { Id = 333, Name = "Tiggo", CarBrandId = 56, Category = "SUV", StartYear = 2005 },
        new CarModel { Id = 334, Name = "Arrizo", CarBrandId = 56, Category = "Sedan", StartYear = 2013 },

        // JAC Models (Brand ID: 57)
        new CarModel { Id = 335, Name = "S3", CarBrandId = 57, Category = "SUV", StartYear = 2014 },
        new CarModel { Id = 336, Name = "S4", CarBrandId = 57, Category = "SUV", StartYear = 2017 },

        // Hongqi Models (Brand ID: 58)
        new CarModel { Id = 337, Name = "H9", CarBrandId = 58, Category = "Sedan", StartYear = 2020 },
        new CarModel { Id = 338, Name = "HS7", CarBrandId = 58, Category = "SUV", StartYear = 2019 },

        // Dongfeng Models (Brand ID: 59)
        new CarModel { Id = 339, Name = "AX7", CarBrandId = 59, Category = "SUV", StartYear = 2014 },
        new CarModel { Id = 340, Name = "A9", CarBrandId = 59, Category = "Sedan", StartYear = 2016 },

        // BAIC Models (Brand ID: 60)
        new CarModel { Id = 341, Name = "X25", CarBrandId = 60, Category = "SUV", StartYear = 2015 },
        new CarModel { Id = 342, Name = "X55", CarBrandId = 60, Category = "SUV", StartYear = 2020 },

        // Indian brands
        // Tata Models (Brand ID: 61)
        new CarModel { Id = 343, Name = "Nexon", CarBrandId = 61, Category = "SUV", StartYear = 2017 },
        new CarModel { Id = 344, Name = "Harrier", CarBrandId = 61, Category = "SUV", StartYear = 2019 },
        new CarModel { Id = 345, Name = "Safari", CarBrandId = 61, Category = "SUV", StartYear = 1998 },

        // Mahindra Models (Brand ID: 62)
        new CarModel { Id = 346, Name = "Scorpio", CarBrandId = 62, Category = "SUV", StartYear = 2002 },
        new CarModel { Id = 347, Name = "XUV500", CarBrandId = 62, Category = "SUV", StartYear = 2011 },
        new CarModel { Id = 348, Name = "Thar", CarBrandId = 62, Category = "SUV", StartYear = 2010 },

        // Maruti Suzuki Models (Brand ID: 63)
        new CarModel { Id = 349, Name = "Alto", CarBrandId = 63, Category = "Hatchback", StartYear = 2000 },
        new CarModel { Id = 350, Name = "Swift", CarBrandId = 63, Category = "Hatchback", StartYear = 2005 },
        new CarModel { Id = 351, Name = "Baleno", CarBrandId = 63, Category = "Hatchback", StartYear = 2015 },

        // Additional luxury and specialty brands
        // Koenigsegg Models (Brand ID: 64)
        new CarModel { Id = 352, Name = "Jesko", CarBrandId = 64, Category = "Coupe", StartYear = 2019 },
        new CarModel { Id = 353, Name = "Regera", CarBrandId = 64, Category = "Coupe", StartYear = 2016 },

        // Pagani Models (Brand ID: 65)
        new CarModel { Id = 354, Name = "Huayra", CarBrandId = 65, Category = "Coupe", StartYear = 2011 },
        new CarModel { Id = 355, Name = "Zonda", CarBrandId = 65, Category = "Coupe", StartYear = 1999, EndYear = 2017 },

        // More Asian brands
        // Proton Models (Brand ID: 66)
        new CarModel { Id = 356, Name = "X70", CarBrandId = 66, Category = "SUV", StartYear = 2018 },
        new CarModel { Id = 357, Name = "Saga", CarBrandId = 66, Category = "Sedan", StartYear = 1985 },

        // Perodua Models (Brand ID: 67)
        new CarModel { Id = 358, Name = "Myvi", CarBrandId = 67, Category = "Hatchback", StartYear = 2005 },
        new CarModel { Id = 359, Name = "Aruz", CarBrandId = 67, Category = "SUV", StartYear = 2019 },

        // Haval Models (Brand ID: 68)
        new CarModel { Id = 360, Name = "H6", CarBrandId = 68, Category = "SUV", StartYear = 2011 },
        new CarModel { Id = 361, Name = "H9", CarBrandId = 68, Category = "SUV", StartYear = 2014 },

        // MG Models (Brand ID: 69)
        new CarModel { Id = 362, Name = "HS", CarBrandId = 69, Category = "SUV", StartYear = 2018 },
        new CarModel { Id = 363, Name = "ZS", CarBrandId = 69, Category = "SUV", StartYear = 2017 },

        // Electric/New Energy brands
        // Rivian Models (Brand ID: 70)
        new CarModel { Id = 364, Name = "R1T", CarBrandId = 70, Category = "Truck", StartYear = 2021 },
        new CarModel { Id = 365, Name = "R1S", CarBrandId = 70, Category = "SUV", StartYear = 2021 },

        // Lucid Models (Brand ID: 71)
        new CarModel { Id = 366, Name = "Air", CarBrandId = 71, Category = "Sedan", StartYear = 2021 },

        // Fisker Models (Brand ID: 72)
        new CarModel { Id = 367, Name = "Ocean", CarBrandId = 72, Category = "SUV", StartYear = 2022 },

        // Polestar Models (Brand ID: 73)
        new CarModel { Id = 368, Name = "2", CarBrandId = 73, Category = "Sedan", StartYear = 2019 },
        new CarModel { Id = 369, Name = "3", CarBrandId = 73, Category = "SUV", StartYear = 2022 },

        // NIO Models (Brand ID: 74)
        new CarModel { Id = 370, Name = "ES8", CarBrandId = 74, Category = "SUV", StartYear = 2018 },
        new CarModel { Id = 371, Name = "ES6", CarBrandId = 74, Category = "SUV", StartYear = 2019 },

        // Xpeng Models (Brand ID: 75)
        new CarModel { Id = 372, Name = "P7", CarBrandId = 75, Category = "Sedan", StartYear = 2020 },
        new CarModel { Id = 373, Name = "G3", CarBrandId = 75, Category = "SUV", StartYear = 2018 },

        // Li Auto Models (Brand ID: 76)
        new CarModel { Id = 374, Name = "ONE", CarBrandId = 76, Category = "SUV", StartYear = 2019 },
        new CarModel { Id = 375, Name = "L9", CarBrandId = 76, Category = "SUV", StartYear = 2022 },

        // Additional specialty and rare brands
        // Spyker Models (Brand ID: 77)
        new CarModel { Id = 376, Name = "C8", CarBrandId = 77, Category = "Coupe", StartYear = 2000 },

        // Morgan Models (Brand ID: 78)
        new CarModel { Id = 377, Name = "Plus Four", CarBrandId = 78, Category = "Convertible", StartYear = 1950 },
        new CarModel { Id = 378, Name = "Aero 8", CarBrandId = 78, Category = "Convertible", StartYear = 2001 },

        // Caterham Models (Brand ID: 79)
        new CarModel { Id = 379, Name = "Seven", CarBrandId = 79, Category = "Convertible", StartYear = 1973 },

        // Noble Models (Brand ID: 80)
        new CarModel { Id = 380, Name = "M600", CarBrandId = 80, Category = "Coupe", StartYear = 2009 },

        // Ariel Models (Brand ID: 81)
        new CarModel { Id = 381, Name = "Atom", CarBrandId = 81, Category = "Convertible", StartYear = 1999 },

        // BAC Models (Brand ID: 82)
        new CarModel { Id = 382, Name = "Mono", CarBrandId = 82, Category = "Convertible", StartYear = 2011 },

        // Ginetta Models (Brand ID: 83)
        new CarModel { Id = 383, Name = "G40", CarBrandId = 83, Category = "Coupe", StartYear = 2010 },

        // TVR Models (Brand ID: 84)
        new CarModel { Id = 384, Name = "Griffith", CarBrandId = 84, Category = "Convertible", StartYear = 1991 },

        // Radical Models (Brand ID: 85)
        new CarModel { Id = 385, Name = "SR3", CarBrandId = 85, Category = "Coupe", StartYear = 2001 },

        // Donkervoort Models (Brand ID: 86)
        new CarModel { Id = 386, Name = "D8 GTO", CarBrandId = 86, Category = "Convertible", StartYear = 2013 },

        // Westfield Models (Brand ID: 87)
        new CarModel { Id = 387, Name = "Seven", CarBrandId = 87, Category = "Convertible", StartYear = 1982 },

        // Ultima Models (Brand ID: 88)
        new CarModel { Id = 388, Name = "GTR", CarBrandId = 88, Category = "Coupe", StartYear = 1999 },

        // Caparo Models (Brand ID: 89)
        new CarModel { Id = 389, Name = "T1", CarBrandId = 89, Category = "Coupe", StartYear = 2006 }
    };
}

// Comprehensive list of model generations
public static class ModelGenerations
{
    public static readonly List<ModelGeneration> AllGenerations = new()
    {
        // Toyota Camry Generations (Model ID: 1)
        new ModelGeneration { Id = 1, Name = "XV10", CarModelId = 1, StartYear = 1991, EndYear = 1996, Description = "Third generation" },
        new ModelGeneration { Id = 2, Name = "XV20", CarModelId = 1, StartYear = 1996, EndYear = 2001, Description = "Fourth generation" },
        new ModelGeneration { Id = 3, Name = "XV30", CarModelId = 1, StartYear = 2001, EndYear = 2006, Description = "Fifth generation" },
        new ModelGeneration { Id = 4, Name = "XV40", CarModelId = 1, StartYear = 2006, EndYear = 2011, Description = "Sixth generation" },
        new ModelGeneration { Id = 5, Name = "XV50", CarModelId = 1, StartYear = 2011, EndYear = 2017, Description = "Seventh generation" },
        new ModelGeneration { Id = 6, Name = "XV70", CarModelId = 1, StartYear = 2017, EndYear = null, Description = "Eighth generation (current)" },

        // Toyota Corolla Generations (Model ID: 2)
        new ModelGeneration { Id = 7, Name = "E100", CarModelId = 2, StartYear = 1991, EndYear = 1995, Description = "Seventh generation" },
        new ModelGeneration { Id = 8, Name = "E110", CarModelId = 2, StartYear = 1995, EndYear = 2000, Description = "Eighth generation" },
        new ModelGeneration { Id = 9, Name = "E120/E130", CarModelId = 2, StartYear = 2000, EndYear = 2006, Description = "Ninth generation" },
        new ModelGeneration { Id = 10, Name = "E140/E150", CarModelId = 2, StartYear = 2006, EndYear = 2013, Description = "Tenth generation" },
        new ModelGeneration { Id = 11, Name = "E160/E170", CarModelId = 2, StartYear = 2013, EndYear = 2019, Description = "Eleventh generation" },
        new ModelGeneration { Id = 12, Name = "E210", CarModelId = 2, StartYear = 2019, EndYear = null, Description = "Twelfth generation (current)" },

        // Toyota Prius Generations (Model ID: 3)
        new ModelGeneration { Id = 13, Name = "XW10", CarModelId = 3, StartYear = 1997, EndYear = 2003, Description = "First generation" },
        new ModelGeneration { Id = 14, Name = "XW20", CarModelId = 3, StartYear = 2003, EndYear = 2009, Description = "Second generation" },
        new ModelGeneration { Id = 15, Name = "XW30", CarModelId = 3, StartYear = 2009, EndYear = 2015, Description = "Third generation" },
        new ModelGeneration { Id = 16, Name = "XW50", CarModelId = 3, StartYear = 2015, EndYear = 2023, Description = "Fourth generation" },
        new ModelGeneration { Id = 17, Name = "XW60", CarModelId = 3, StartYear = 2023, EndYear = null, Description = "Fifth generation (current)" },

        // Toyota RAV4 Generations (Model ID: 4)
        new ModelGeneration { Id = 18, Name = "XA10", CarModelId = 4, StartYear = 1994, EndYear = 2000, Description = "First generation" },
        new ModelGeneration { Id = 19, Name = "XA20", CarModelId = 4, StartYear = 2000, EndYear = 2005, Description = "Second generation" },
        new ModelGeneration { Id = 20, Name = "XA30", CarModelId = 4, StartYear = 2005, EndYear = 2012, Description = "Third generation" },
        new ModelGeneration { Id = 21, Name = "XA40", CarModelId = 4, StartYear = 2012, EndYear = 2018, Description = "Fourth generation" },
        new ModelGeneration { Id = 22, Name = "XA50", CarModelId = 4, StartYear = 2018, EndYear = null, Description = "Fifth generation (current)" },

        // Honda Accord Generations (Model ID: 12)
        new ModelGeneration { Id = 23, Name = "CD5/CD7", CarModelId = 12, StartYear = 1993, EndYear = 1997, Description = "Fifth generation" },
        new ModelGeneration { Id = 24, Name = "CG/CH", CarModelId = 12, StartYear = 1997, EndYear = 2002, Description = "Sixth generation" },
        new ModelGeneration { Id = 25, Name = "CL7/CL8/CL9", CarModelId = 12, StartYear = 2002, EndYear = 2007, Description = "Seventh generation" },
        new ModelGeneration { Id = 26, Name = "CU1/CU2", CarModelId = 12, StartYear = 2007, EndYear = 2012, Description = "Eighth generation" },
        new ModelGeneration { Id = 27, Name = "CR2/CR6", CarModelId = 12, StartYear = 2012, EndYear = 2017, Description = "Ninth generation" },
        new ModelGeneration { Id = 28, Name = "CV1/CV3", CarModelId = 12, StartYear = 2017, EndYear = 2022, Description = "Tenth generation" },
        new ModelGeneration { Id = 29, Name = "CV4", CarModelId = 12, StartYear = 2022, EndYear = null, Description = "Eleventh generation (current)" },

        // Honda Civic Generations (Model ID: 13)
        new ModelGeneration { Id = 30, Name = "EG/EH/EJ", CarModelId = 13, StartYear = 1991, EndYear = 1995, Description = "Fifth generation" },
        new ModelGeneration { Id = 31, Name = "EK/EM", CarModelId = 13, StartYear = 1995, EndYear = 2000, Description = "Sixth generation" },
        new ModelGeneration { Id = 32, Name = "ES/EM2/EP3", CarModelId = 13, StartYear = 2000, EndYear = 2005, Description = "Seventh generation" },
        new ModelGeneration { Id = 33, Name = "FA/FD/FN/FG", CarModelId = 13, StartYear = 2005, EndYear = 2011, Description = "Eighth generation" },
        new ModelGeneration { Id = 34, Name = "FB/FC", CarModelId = 13, StartYear = 2011, EndYear = 2015, Description = "Ninth generation" },
        new ModelGeneration { Id = 35, Name = "FC1/FC3", CarModelId = 13, StartYear = 2015, EndYear = 2021, Description = "Tenth generation" },
        new ModelGeneration { Id = 36, Name = "FL1/FL4", CarModelId = 13, StartYear = 2021, EndYear = null, Description = "Eleventh generation (current)" },

        // Honda CR-V Generations (Model ID: 14)
        new ModelGeneration { Id = 37, Name = "RD1/RD3", CarModelId = 14, StartYear = 1995, EndYear = 2001, Description = "First generation" },
        new ModelGeneration { Id = 38, Name = "RD4/RD5/RD7", CarModelId = 14, StartYear = 2001, EndYear = 2006, Description = "Second generation" },
        new ModelGeneration { Id = 39, Name = "RE1/RE2/RE4", CarModelId = 14, StartYear = 2006, EndYear = 2011, Description = "Third generation" },
        new ModelGeneration { Id = 40, Name = "RM1/RM3/RM4", CarModelId = 14, StartYear = 2011, EndYear = 2016, Description = "Fourth generation" },
        new ModelGeneration { Id = 41, Name = "RW1/RW2", CarModelId = 14, StartYear = 2016, EndYear = 2022, Description = "Fifth generation" },
        new ModelGeneration { Id = 42, Name = "RT1/RT6", CarModelId = 14, StartYear = 2022, EndYear = null, Description = "Sixth generation (current)" },

        // Ford F-150 Generations (Model ID: 22)
        new ModelGeneration { Id = 43, Name = "Ninth Generation", CarModelId = 22, StartYear = 1992, EndYear = 1996, Description = "Major redesign" },
        new ModelGeneration { Id = 44, Name = "Tenth Generation", CarModelId = 22, StartYear = 1997, EndYear = 2003, Description = "Aerodynamic redesign" },
        new ModelGeneration { Id = 45, Name = "Eleventh Generation", CarModelId = 22, StartYear = 2004, EndYear = 2008, Description = "P2 platform" },
        new ModelGeneration { Id = 46, Name = "Twelfth Generation", CarModelId = 22, StartYear = 2009, EndYear = 2014, Description = "SVT Raptor introduced" },
        new ModelGeneration { Id = 47, Name = "Thirteenth Generation", CarModelId = 22, StartYear = 2015, EndYear = 2020, Description = "Aluminum body" },
        new ModelGeneration { Id = 48, Name = "Fourteenth Generation", CarModelId = 22, StartYear = 2021, EndYear = null, Description = "T6 platform (current)" },

        // Ford Mustang Generations (Model ID: 23)
        new ModelGeneration { Id = 49, Name = "SN95", CarModelId = 23, StartYear = 1994, EndYear = 2004, Description = "Fourth generation" },
        new ModelGeneration { Id = 50, Name = "S197", CarModelId = 23, StartYear = 2005, EndYear = 2014, Description = "Fifth generation" },
        new ModelGeneration { Id = 51, Name = "S550", CarModelId = 23, StartYear = 2015, EndYear = 2023, Description = "Sixth generation" },
        new ModelGeneration { Id = 52, Name = "S650", CarModelId = 23, StartYear = 2024, EndYear = null, Description = "Seventh generation (current)" },

        // Chevrolet Silverado Generations (Model ID: 32)
        new ModelGeneration { Id = 53, Name = "GMT800", CarModelId = 32, StartYear = 1999, EndYear = 2006, Description = "First generation" },
        new ModelGeneration { Id = 54, Name = "GMT900", CarModelId = 32, StartYear = 2007, EndYear = 2013, Description = "Second generation" },
        new ModelGeneration { Id = 55, Name = "GMT K2XX", CarModelId = 32, StartYear = 2014, EndYear = 2018, Description = "Third generation" },
        new ModelGeneration { Id = 56, Name = "GMT T1XX", CarModelId = 32, StartYear = 2019, EndYear = null, Description = "Fourth generation (current)" },

        // Chevrolet Camaro Generations (Model ID: 37)
        new ModelGeneration { Id = 57, Name = "Fourth Generation", CarModelId = 37, StartYear = 1993, EndYear = 2002, Description = "F-body platform" },
        new ModelGeneration { Id = 58, Name = "Fifth Generation", CarModelId = 37, StartYear = 2010, EndYear = 2015, Description = "Zeta platform" },
        new ModelGeneration { Id = 59, Name = "Sixth Generation", CarModelId = 37, StartYear = 2016, EndYear = null, Description = "Alpha platform (current)" },

        // BMW 3 Series Generations (Model ID: 44)
        new ModelGeneration { Id = 60, Name = "E36", CarModelId = 44, StartYear = 1990, EndYear = 1998, Description = "Third generation" },
        new ModelGeneration { Id = 61, Name = "E46", CarModelId = 44, StartYear = 1998, EndYear = 2006, Description = "Fourth generation" },
        new ModelGeneration { Id = 62, Name = "E90/E91/E92/E93", CarModelId = 44, StartYear = 2005, EndYear = 2013, Description = "Fifth generation" },
        new ModelGeneration { Id = 63, Name = "F30/F31/F34/F35", CarModelId = 44, StartYear = 2012, EndYear = 2019, Description = "Sixth generation" },
        new ModelGeneration { Id = 64, Name = "G20/G21", CarModelId = 44, StartYear = 2019, EndYear = null, Description = "Seventh generation (current)" },

        // BMW 5 Series Generations (Model ID: 45)
        new ModelGeneration { Id = 65, Name = "E34", CarModelId = 45, StartYear = 1988, EndYear = 1996, Description = "Third generation" },
        new ModelGeneration { Id = 66, Name = "E39", CarModelId = 45, StartYear = 1995, EndYear = 2003, Description = "Fourth generation" },
        new ModelGeneration { Id = 67, Name = "E60/E61", CarModelId = 45, StartYear = 2003, EndYear = 2010, Description = "Fifth generation" },
        new ModelGeneration { Id = 68, Name = "F10/F11/F07", CarModelId = 45, StartYear = 2009, EndYear = 2017, Description = "Sixth generation" },
        new ModelGeneration { Id = 69, Name = "G30/G31", CarModelId = 45, StartYear = 2016, EndYear = null, Description = "Seventh generation (current)" },

        // Mercedes-Benz C-Class Generations (Model ID: 48)
        new ModelGeneration { Id = 70, Name = "W202", CarModelId = 48, StartYear = 1993, EndYear = 2000, Description = "First generation" },
        new ModelGeneration { Id = 71, Name = "W203", CarModelId = 48, StartYear = 2000, EndYear = 2007, Description = "Second generation" },
        new ModelGeneration { Id = 72, Name = "W204", CarModelId = 48, StartYear = 2007, EndYear = 2014, Description = "Third generation" },
        new ModelGeneration { Id = 73, Name = "W205", CarModelId = 48, StartYear = 2014, EndYear = 2021, Description = "Fourth generation" },
        new ModelGeneration { Id = 74, Name = "W206", CarModelId = 48, StartYear = 2021, EndYear = null, Description = "Fifth generation (current)" },

        // Mercedes-Benz E-Class Generations (Model ID: 49)
        new ModelGeneration { Id = 75, Name = "W124", CarModelId = 49, StartYear = 1984, EndYear = 1995, Description = "Second generation" },
        new ModelGeneration { Id = 76, Name = "W210", CarModelId = 49, StartYear = 1995, EndYear = 2002, Description = "Third generation" },
        new ModelGeneration { Id = 77, Name = "W211", CarModelId = 49, StartYear = 2002, EndYear = 2009, Description = "Fourth generation" },
        new ModelGeneration { Id = 78, Name = "W212", CarModelId = 49, StartYear = 2009, EndYear = 2016, Description = "Fifth generation" },
        new ModelGeneration { Id = 79, Name = "W213", CarModelId = 49, StartYear = 2016, EndYear = null, Description = "Sixth generation (current)" },

        // Audi A4 Generations (Model ID: 51)
        new ModelGeneration { Id = 80, Name = "B5", CarModelId = 51, StartYear = 1994, EndYear = 2001, Description = "First generation" },
        new ModelGeneration { Id = 81, Name = "B6", CarModelId = 51, StartYear = 2000, EndYear = 2004, Description = "Second generation" },
        new ModelGeneration { Id = 82, Name = "B7", CarModelId = 51, StartYear = 2004, EndYear = 2008, Description = "Third generation" },
        new ModelGeneration { Id = 83, Name = "B8", CarModelId = 51, StartYear = 2007, EndYear = 2015, Description = "Fourth generation" },
        new ModelGeneration { Id = 84, Name = "B9", CarModelId = 51, StartYear = 2015, EndYear = null, Description = "Fifth generation (current)" },

        // Tesla Model 3 Generations (Model ID: 129)
        new ModelGeneration { Id = 85, Name = "Original", CarModelId = 129, StartYear = 2017, EndYear = 2023, Description = "Original design" },
        new ModelGeneration { Id = 86, Name = "Highland", CarModelId = 129, StartYear = 2023, EndYear = null, Description = "Refreshed design (current)" },

        // Tesla Model S Generations (Model ID: 128)
        new ModelGeneration { Id = 87, Name = "Original", CarModelId = 128, StartYear = 2012, EndYear = 2021, Description = "Original design" },
        new ModelGeneration { Id = 88, Name = "Refresh", CarModelId = 128, StartYear = 2021, EndYear = null, Description = "Plaid refresh (current)" },

        // Porsche 911 Generations (Model ID: 76)
        new ModelGeneration { Id = 89, Name = "993", CarModelId = 76, StartYear = 1993, EndYear = 1998, Description = "Fourth generation" },
        new ModelGeneration { Id = 90, Name = "996", CarModelId = 76, StartYear = 1997, EndYear = 2005, Description = "Fifth generation" },
        new ModelGeneration { Id = 91, Name = "997", CarModelId = 76, StartYear = 2004, EndYear = 2012, Description = "Sixth generation" },
        new ModelGeneration { Id = 92, Name = "991", CarModelId = 76, StartYear = 2011, EndYear = 2019, Description = "Seventh generation" },
        new ModelGeneration { Id = 93, Name = "992", CarModelId = 76, StartYear = 2019, EndYear = null, Description = "Eighth generation (current)" }
    };
}