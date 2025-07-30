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