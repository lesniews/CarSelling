using CarSelling.Shared.DTOs;
using CarSelling.Shared.Models;

namespace CarSelling.Api.Services;

// Adapter to maintain backward compatibility with existing ICarListingService interface
public class CarListingServiceAdapter : ICarListingService
{
    private readonly IExtendedCarListingService _extendedService;

    public CarListingServiceAdapter(IExtendedCarListingService extendedService)
    {
        _extendedService = extendedService;
    }

    public async Task<IEnumerable<CarListing>> SearchListingsAsync(CarListingSearchDto search)
    {
        // Convert old DTO to new DTO
        var extendedSearch = new ExtendedCarListingSearchDto
        {
            Make = search.Make,
            Model = search.Model,
            YearFrom = search.YearFrom,
            YearTo = search.YearTo,
            PriceFrom = search.PriceFrom,
            PriceTo = search.PriceTo,
            FuelType = search.FuelType,
            Location = search.Location,
            Page = search.Page,
            PageSize = search.PageSize
        };

        return await _extendedService.SearchListingsAsync(extendedSearch);
    }

    public async Task<CarListing?> GetListingByIdAsync(int id)
    {
        return await _extendedService.GetListingByIdAsync(id);
    }

    public async Task<CarListing> CreateListingAsync(CreateCarListingDto createDto)
    {
        // Convert old DTO to new DTO
        var extendedDto = new ExtendedCreateCarListingDto
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
            Location = createDto.Location
        };

        return await _extendedService.CreateListingAsync(extendedDto);
    }

    public async Task<bool> UpdateListingAsync(int id, CreateCarListingDto updateDto)
    {
        // Convert old DTO to new DTO
        var extendedDto = new ExtendedCreateCarListingDto
        {
            Title = updateDto.Title,
            Make = updateDto.Make,
            Model = updateDto.Model,
            Year = updateDto.Year,
            Price = updateDto.Price,
            Mileage = updateDto.Mileage,
            FuelType = updateDto.FuelType,
            Transmission = updateDto.Transmission,
            Description = updateDto.Description,
            Images = updateDto.Images,
            ContactEmail = updateDto.ContactEmail,
            ContactPhone = updateDto.ContactPhone,
            Location = updateDto.Location
        };

        return await _extendedService.UpdateListingAsync(id, extendedDto);
    }

    public async Task<bool> DeleteListingAsync(int id)
    {
        return await _extendedService.DeleteListingAsync(id);
    }
}