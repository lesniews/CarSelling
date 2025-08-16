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
        new CarModel { Id = 149, Name = "Taycan", CarBrandId = 4, Category = "Sedan", StartYear = 2019 }
    };
}