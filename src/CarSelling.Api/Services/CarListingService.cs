using CarSelling.Api.Data;
using CarSelling.Shared.DTOs;
using CarSelling.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Api.Services;

public interface ICarListingService
{
    Task<IEnumerable<CarListing>> SearchListingsAsync(CarListingSearchDto search);
    Task<CarListing?> GetListingByIdAsync(int id);
    Task<CarListing> CreateListingAsync(CreateCarListingDto createDto);
    Task<bool> UpdateListingAsync(int id, CreateCarListingDto updateDto);
    Task<bool> DeleteListingAsync(int id);
}

public interface IExtendedCarListingService
{
    Task<IEnumerable<CarListing>> SearchListingsAsync(ExtendedCarListingSearchDto search);
    Task<CarListing?> GetListingByIdAsync(int id);
    Task<CarListing> CreateListingAsync(ExtendedCreateCarListingDto createDto);
    Task<bool> UpdateListingAsync(int id, ExtendedCreateCarListingDto updateDto);
    Task<bool> DeleteListingAsync(int id);
    Task<IEnumerable<CarListing>> GetFeaturedListingsAsync(int count = 6);
    Task<IEnumerable<CarListing>> GetUserListingsAsync(string userId);
    Task<bool> ToggleFavoriteAsync(int listingId, string userId);
    Task<Dictionary<string, int>> GetStatisticsAsync();
}

public interface IUserService
{
    Task<User?> GetUserByIdAsync(string id);
    Task<User> CreateUserAsync(string name, string email, string phone);
    Task<bool> UpdateUserAsync(string id, User user);
    Task<bool> DeleteUserAsync(string id);
}

public class CarListingService : ICarListingService
{
    private readonly CarSellingContext _context;

    public CarListingService(CarSellingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CarListing>> SearchListingsAsync(CarListingSearchDto search)
    {
        var query = _context.CarListings.Where(c => c.IsActive);

        if (!string.IsNullOrEmpty(search.Make))
            query = query.Where(c => c.Make.Contains(search.Make));

        if (!string.IsNullOrEmpty(search.Model))
            query = query.Where(c => c.Model.Contains(search.Model));

        if (search.YearFrom.HasValue)
            query = query.Where(c => c.Year >= search.YearFrom.Value);

        if (search.YearTo.HasValue)
            query = query.Where(c => c.Year <= search.YearTo.Value);

        if (search.PriceFrom.HasValue)
            query = query.Where(c => c.Price >= search.PriceFrom.Value);

        if (search.PriceTo.HasValue)
            query = query.Where(c => c.Price <= search.PriceTo.Value);

        if (!string.IsNullOrEmpty(search.FuelType))
            query = query.Where(c => c.FuelType == search.FuelType);

        if (!string.IsNullOrEmpty(search.Location))
            query = query.Where(c => c.Location.Contains(search.Location));

        return await query
            .OrderByDescending(c => c.CreatedAt)
            .Skip((search.Page - 1) * search.PageSize)
            .Take(search.PageSize)
            .ToListAsync();
    }

    public async Task<CarListing?> GetListingByIdAsync(int id)
    {
        return await _context.CarListings.FindAsync(id);
    }

    public async Task<CarListing> CreateListingAsync(CreateCarListingDto createDto)
    {
        var listing = new CarListing
        {
            Title = createDto.Title,
            Make = createDto.Make,
            Model = createDto.Model,
            Year = createDto.Year,
            Price = createDto.Price,
            Mileage = createDto.Mileage,
            FuelType = createDto.FuelType,
            Transmission = createDto.Transmission,
            Description = createDto.Description,
            Images = createDto.Images,
            ContactEmail = createDto.ContactEmail,
            ContactPhone = createDto.ContactPhone,
            Location = createDto.Location,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UserId = "temp-user" // TODO: Get from authentication
        };

        _context.CarListings.Add(listing);
        await _context.SaveChangesAsync();
        return listing;
    }

    public async Task<bool> UpdateListingAsync(int id, CreateCarListingDto updateDto)
    {
        var listing = await _context.CarListings.FindAsync(id);
        if (listing == null) return false;

        listing.Title = updateDto.Title;
        listing.Make = updateDto.Make;
        listing.Model = updateDto.Model;
        listing.Year = updateDto.Year;
        listing.Price = updateDto.Price;
        listing.Mileage = updateDto.Mileage;
        listing.FuelType = updateDto.FuelType;
        listing.Transmission = updateDto.Transmission;
        listing.Description = updateDto.Description;
        listing.Images = updateDto.Images;
        listing.ContactEmail = updateDto.ContactEmail;
        listing.ContactPhone = updateDto.ContactPhone;
        listing.Location = updateDto.Location;
        listing.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteListingAsync(int id)
    {
        var listing = await _context.CarListings.FindAsync(id);
        if (listing == null) return false;

        listing.IsActive = false; // Soft delete
        listing.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
}

public class ExtendedCarListingService : IExtendedCarListingService
{
    private readonly CarSellingContext _context;

    public ExtendedCarListingService(CarSellingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CarListing>> SearchListingsAsync(ExtendedCarListingSearchDto search)
    {
        var query = _context.CarListings.Where(c => c.IsActive);

        // Basic filters
        if (!string.IsNullOrEmpty(search.Make))
            query = query.Where(c => c.Make.Contains(search.Make));

        if (!string.IsNullOrEmpty(search.Model))
            query = query.Where(c => c.Model.Contains(search.Model));

        if (!string.IsNullOrEmpty(search.ModelGeneration))
            query = query.Where(c => c.ModelGeneration.Contains(search.ModelGeneration));

        if (!string.IsNullOrEmpty(search.BodyType))
            query = query.Where(c => c.BodyType == search.BodyType);

        if (!string.IsNullOrEmpty(search.Location))
            query = query.Where(c => c.Location.Contains(search.Location) ||
                                   c.City.Contains(search.Location) ||
                                   c.State.Contains(search.Location));

        // Price range
        if (search.PriceFrom.HasValue)
            query = query.Where(c => c.Price >= search.PriceFrom.Value);

        if (search.PriceTo.HasValue)
            query = query.Where(c => c.Price <= search.PriceTo.Value);

        // Year range
        if (search.YearFrom.HasValue)
            query = query.Where(c => c.Year >= search.YearFrom.Value);

        if (search.YearTo.HasValue)
            query = query.Where(c => c.Year <= search.YearTo.Value);

        // Mileage range
        if (search.MileageFrom.HasValue)
            query = query.Where(c => c.Mileage >= search.MileageFrom.Value);

        if (search.MileageTo.HasValue)
            query = query.Where(c => c.Mileage <= search.MileageTo.Value);

        // Engine & Drive
        if (!string.IsNullOrEmpty(search.FuelType))
            query = query.Where(c => c.FuelType == search.FuelType);

        if (!string.IsNullOrEmpty(search.Transmission))
            query = query.Where(c => c.Transmission == search.Transmission);

        if (!string.IsNullOrEmpty(search.Drivetrain))
            query = query.Where(c => c.Drivetrain == search.Drivetrain);

        // Car Status
        if (!string.IsNullOrEmpty(search.Condition))
            query = query.Where(c => c.Condition == search.Condition);

        if (!string.IsNullOrEmpty(search.DamageStatus))
            query = query.Where(c => c.DamageStatus == search.DamageStatus);

        if (!string.IsNullOrEmpty(search.CarStatus))
            query = query.Where(c => c.CarStatus == search.CarStatus);

        // Seller type
        if (!string.IsNullOrEmpty(search.SellerType))
            query = query.Where(c => c.SellerType == search.SellerType);

        // Financial options
        if (search.TradeInAccepted.HasValue)
            query = query.Where(c => c.TradeInAccepted == search.TradeInAccepted.Value);

        if (search.NegotiablePrice.HasValue)
            query = query.Where(c => c.NegotiablePrice == search.NegotiablePrice.Value);

        // Features
        if (search.TestDriveAvailable.HasValue)
            query = query.Where(c => c.TestDriveAvailable == search.TestDriveAvailable.Value);

        if (search.Has360View.HasValue)
            query = query.Where(c => c.Has360View == search.Has360View.Value);

        // Equipment filtering (if any equipment is specified)
        if (search.Equipment.Any())
        {
            foreach (var equipment in search.Equipment)
            {
                query = query.Where(c => c.Equipment.Any(e => e.Contains(equipment)));
            }
        }

        // Sorting
        query = search.SortBy.ToLower() switch
        {
            "price" => search.SortDirection == "asc" ?
                query.OrderBy(c => c.Price) : query.OrderByDescending(c => c.Price),
            "year" => search.SortDirection == "asc" ?
                query.OrderBy(c => c.Year) : query.OrderByDescending(c => c.Year),
            "mileage" => search.SortDirection == "asc" ?
                query.OrderBy(c => c.Mileage) : query.OrderByDescending(c => c.Mileage),
            "views" => query.OrderByDescending(c => c.ViewCount),
            _ => query.OrderByDescending(c => c.CreatedAt)
        };

        return await query
            .Skip((search.Page - 1) * search.PageSize)
            .Take(search.PageSize)
            .ToListAsync();
    }

    public async Task<CarListing?> GetListingByIdAsync(int id)
    {
        var listing = await _context.CarListings.FindAsync(id);

        if (listing != null)
        {
            // Increment view count
            listing.ViewCount++;
            listing.LastViewedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        return listing;
    }

    public async Task<CarListing> CreateListingAsync(ExtendedCreateCarListingDto createDto)
    {
        var listing = new CarListing
        {
            // Basic info
            Title = createDto.Title,
            Make = createDto.Make,
            Model = createDto.Model,
            Year = createDto.Year,
            Price = createDto.Price,
            Mileage = createDto.Mileage,

            // Extended details
            ModelGeneration = createDto.ModelGeneration,
            BodyType = createDto.BodyType,
            FuelType = createDto.FuelType,
            Transmission = createDto.Transmission,

            // Engine & Drive
            EngineSize = createDto.EngineSize,
            Horsepower = createDto.Horsepower,
            Drivetrain = createDto.Drivetrain,
            FuelEconomyCity = createDto.FuelEconomyCity,
            FuelEconomyHighway = createDto.FuelEconomyHighway,

            // Car Status
            Condition = createDto.Condition,
            DamageStatus = createDto.DamageStatus,
            CarStatus = createDto.CarStatus,

            // Financial
            FinancingOptions = createDto.FinancingOptions,
            TradeInAccepted = createDto.TradeInAccepted,
            NegotiablePrice = createDto.NegotiablePrice,

            // Equipment
            Equipment = createDto.Equipment,

            // Colors & Interior
            ExteriorColor = createDto.ExteriorColor,
            InteriorColor = createDto.InteriorColor,
            InteriorMaterial = createDto.InteriorMaterial,

            // Vehicle History
            PreviousOwners = createDto.PreviousOwners,
            AccidentHistory = createDto.AccidentHistory,
            ServiceHistoryAvailable = createDto.ServiceHistoryAvailable,
            VIN = createDto.VIN,

            // Seller
            SellerType = createDto.SellerType,

            // Media
            Images = createDto.Images,
            VideoUrl = createDto.VideoUrl,
            Has360View = createDto.Has360View,

            // Original fields
            Description = createDto.Description,
            ContactEmail = createDto.ContactEmail,
            ContactPhone = createDto.ContactPhone,
            Location = createDto.Location,
            City = createDto.City,
            State = createDto.State,
            ZipCode = createDto.ZipCode,

            // Availability
            AvailableDate = createDto.AvailableDate,
            TestDriveAvailable = createDto.TestDriveAvailable,
            ViewingAppointmentRequired = createDto.ViewingAppointmentRequired,

            // System fields
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UserId = "temp-user" // TODO: Get from authentication
        };

        _context.CarListings.Add(listing);
        await _context.SaveChangesAsync();
        return listing;
    }

    public async Task<bool> UpdateListingAsync(int id, ExtendedCreateCarListingDto updateDto)
    {
        var listing = await _context.CarListings.FindAsync(id);
        if (listing == null) return false;

        // Update all fields from DTO
        listing.Title = updateDto.Title;
        listing.Make = updateDto.Make;
        listing.Model = updateDto.Model;
        listing.Year = updateDto.Year;
        listing.Price = updateDto.Price;
        listing.Mileage = updateDto.Mileage;
        listing.ModelGeneration = updateDto.ModelGeneration;
        listing.BodyType = updateDto.BodyType;
        listing.FuelType = updateDto.FuelType;
        listing.Transmission = updateDto.Transmission;
        listing.EngineSize = updateDto.EngineSize;
        listing.Horsepower = updateDto.Horsepower;
        listing.Drivetrain = updateDto.Drivetrain;
        listing.FuelEconomyCity = updateDto.FuelEconomyCity;
        listing.FuelEconomyHighway = updateDto.FuelEconomyHighway;
        listing.Condition = updateDto.Condition;
        listing.DamageStatus = updateDto.DamageStatus;
        listing.CarStatus = updateDto.CarStatus;
        listing.FinancingOptions = updateDto.FinancingOptions;
        listing.TradeInAccepted = updateDto.TradeInAccepted;
        listing.NegotiablePrice = updateDto.NegotiablePrice;
        listing.Equipment = updateDto.Equipment;
        listing.ExteriorColor = updateDto.ExteriorColor;
        listing.InteriorColor = updateDto.InteriorColor;
        listing.InteriorMaterial = updateDto.InteriorMaterial;
        listing.PreviousOwners = updateDto.PreviousOwners;
        listing.AccidentHistory = updateDto.AccidentHistory;
        listing.ServiceHistoryAvailable = updateDto.ServiceHistoryAvailable;
        listing.VIN = updateDto.VIN;
        listing.SellerType = updateDto.SellerType;
        listing.Images = updateDto.Images;
        listing.VideoUrl = updateDto.VideoUrl;
        listing.Has360View = updateDto.Has360View;
        listing.Description = updateDto.Description;
        listing.ContactEmail = updateDto.ContactEmail;
        listing.ContactPhone = updateDto.ContactPhone;
        listing.Location = updateDto.Location;
        listing.City = updateDto.City;
        listing.State = updateDto.State;
        listing.ZipCode = updateDto.ZipCode;
        listing.AvailableDate = updateDto.AvailableDate;
        listing.TestDriveAvailable = updateDto.TestDriveAvailable;
        listing.ViewingAppointmentRequired = updateDto.ViewingAppointmentRequired;
        listing.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteListingAsync(int id)
    {
        var listing = await _context.CarListings.FindAsync(id);
        if (listing == null) return false;

        listing.IsActive = false; // Soft delete
        listing.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CarListing>> GetFeaturedListingsAsync(int count = 6)
    {
        return await _context.CarListings
            .Where(c => c.IsActive && c.IsFeatured)
            .OrderByDescending(c => c.ViewCount)
            .Take(count)
            .ToListAsync();
    }

    public async Task<IEnumerable<CarListing>> GetUserListingsAsync(string userId)
    {
        return await _context.CarListings
            .Where(c => c.UserId == userId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<bool> ToggleFavoriteAsync(int listingId, string userId)
    {
        // Implementation for favorites (would need a separate Favorites table)
        // For now, just increment the favorite count
        var listing = await _context.CarListings.FindAsync(listingId);
        if (listing == null) return false;

        listing.FavoriteCount++;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Dictionary<string, int>> GetStatisticsAsync()
    {
        var totalCars = await _context.CarListings.CountAsync(c => c.IsActive);
        var totalUsers = await _context.Users.CountAsync(u => u.IsActive);
        var totalTransactions = await _context.CarListings.CountAsync(c => !c.IsActive); // Assuming sold cars are inactive

        return new Dictionary<string, int>
        {
            ["TotalCars"] = totalCars,
            ["TotalUsers"] = totalUsers,
            ["TotalTransactions"] = totalTransactions,
            ["SuccessRate"] = totalTransactions > 0 ? (totalTransactions * 100 / (totalCars + totalTransactions)) : 98
        };
    }
}

public class UserService : IUserService
{
    private readonly CarSellingContext _context;

    public UserService(CarSellingContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByIdAsync(string id)
    {
        return await _context.Users
            .Include(u => u.Listings)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> CreateUserAsync(string name, string email, string phone)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Email = email,
            Phone = phone,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateUserAsync(string id, User user)
    {
        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser == null) return false;

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        existingUser.Phone = user.Phone;
        existingUser.PreferredLocation = user.PreferredLocation;
        existingUser.UserType = user.UserType;
        existingUser.CompanyName = user.CompanyName;
        existingUser.LicenseNumber = user.LicenseNumber;
        existingUser.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        user.IsActive = false;
        user.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
}