using System.ComponentModel.DataAnnotations;

namespace CarSelling.Shared.DTOs;

// Original DTO for backward compatibility
public class CreateCarListingDto
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Make { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Model { get; set; } = string.Empty;

    [Range(1900, 2030)]
    public int Year { get; set; }

    [Range(0.01, 999999.99)]
    public decimal Price { get; set; }

    [Range(0, 999999)]
    public int Mileage { get; set; }

    public string FuelType { get; set; } = string.Empty;
    public string Transmission { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> Images { get; set; } = new();

    [Required]
    [EmailAddress]
    public string ContactEmail { get; set; } = string.Empty;

    [Phone]
    public string ContactPhone { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;
}

// Original search DTO for backward compatibility
public class CarListingSearchDto
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int? YearFrom { get; set; }
    public int? YearTo { get; set; }
    public decimal? PriceFrom { get; set; }
    public decimal? PriceTo { get; set; }
    public string? FuelType { get; set; }
    public string? Location { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

// Extended DTO for the new CarMarket design
public class ExtendedCreateCarListingDto
{
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

    [Range(0.01, 999999.99)]
    public decimal Price { get; set; }

    [Range(0, 999999)]
    public int Mileage { get; set; }

    // Extended Vehicle Details
    public string ModelGeneration { get; set; } = string.Empty;
    public string BodyType { get; set; } = string.Empty;
    public string FuelType { get; set; } = string.Empty;
    public string Transmission { get; set; } = string.Empty;

    // Engine & Drive
    public string EngineSize { get; set; } = string.Empty;
    public int? Horsepower { get; set; }
    public string Drivetrain { get; set; } = string.Empty;
    public int? FuelEconomyCity { get; set; }
    public int? FuelEconomyHighway { get; set; }

    // Car Status
    public string Condition { get; set; } = string.Empty;
    public string DamageStatus { get; set; } = string.Empty;
    public string CarStatus { get; set; } = string.Empty;

    // Financial Options
    public string FinancingOptions { get; set; } = string.Empty;
    public bool TradeInAccepted { get; set; }
    public bool NegotiablePrice { get; set; }

    // Equipment/Features
    public List<string> Equipment { get; set; } = new();

    // Colors & Interior
    public string ExteriorColor { get; set; } = string.Empty;
    public string InteriorColor { get; set; } = string.Empty;
    public string InteriorMaterial { get; set; } = string.Empty;

    // Vehicle History
    public int? PreviousOwners { get; set; }
    public bool AccidentHistory { get; set; }
    public bool ServiceHistoryAvailable { get; set; }
    public string VIN { get; set; } = string.Empty;

    // Seller Information
    public string SellerType { get; set; } = string.Empty;

    // Media
    public List<string> Images { get; set; } = new();
    public string VideoUrl { get; set; } = string.Empty;
    public bool Has360View { get; set; }

    // Original fields
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
    public DateTime AvailableDate { get; set; } = DateTime.Now;
    public bool TestDriveAvailable { get; set; }
    public bool ViewingAppointmentRequired { get; set; }
}

// Extended search DTO for the new CarMarket design
public class ExtendedCarListingSearchDto
{
    // Basic filters
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? ModelGeneration { get; set; }
    public string? BodyType { get; set; }
    public string? Location { get; set; }

    // Price range
    public decimal? PriceFrom { get; set; }
    public decimal? PriceTo { get; set; }

    // Year range
    public int? YearFrom { get; set; }
    public int? YearTo { get; set; }

    // Mileage range
    public int? MileageFrom { get; set; }
    public int? MileageTo { get; set; }

    // Engine & Drive
    public string? FuelType { get; set; }
    public string? Transmission { get; set; }
    public string? Drivetrain { get; set; }

    // Car Status
    public string? Condition { get; set; }
    public string? DamageStatus { get; set; }
    public string? CarStatus { get; set; }

    // Seller
    public string? SellerType { get; set; }

    // Equipment
    public List<string> Equipment { get; set; } = new();

    // Financial
    public bool? FinancingAvailable { get; set; }
    public bool? TradeInAccepted { get; set; }
    public bool? NegotiablePrice { get; set; }

    // Features
    public bool? TestDriveAvailable { get; set; }
    public bool? Has360View { get; set; }

    // Pagination and sorting
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string SortBy { get; set; } = "CreatedAt";
    public string SortDirection { get; set; } = "desc";
}