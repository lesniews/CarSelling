using System.ComponentModel.DataAnnotations;

namespace CarSelling.Shared.Models;

public class User
{
    public string Id { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string Phone { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    // User preferences
    public string PreferredLocation { get; set; } = string.Empty;
    public string UserType { get; set; } = "Individual"; // Individual, Dealer
    public string CompanyName { get; set; } = string.Empty; // For dealers
    public string LicenseNumber { get; set; } = string.Empty; // For dealers

    // Statistics
    public int TotalListings { get; set; }
    public int SoldCars { get; set; }
    public decimal AverageRating { get; set; }
    public int ReviewCount { get; set; }

    // Navigation property
    public List<CarListing> Listings { get; set; } = new();
}