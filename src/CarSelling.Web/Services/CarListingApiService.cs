using CarSelling.Shared.DTOs;
using CarSelling.Shared.Models;
using System.Text.Json;
using System.Text;

namespace CarSelling.Web.Services;

public interface ICarListingApiService
{
    Task<IEnumerable<CarListing>> SearchCarsAsync(CarListingSearchDto search);
    Task<CarListing?> GetCarByIdAsync(int id);
    Task<CarListing> CreateCarListingAsync(CreateCarListingDto createDto);
    Task<bool> UpdateCarListingAsync(int id, CreateCarListingDto updateDto);
    Task<bool> DeleteCarListingAsync(int id);
}

public class CarListingApiService : ICarListingApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public CarListingApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<IEnumerable<CarListing>> SearchCarsAsync(CarListingSearchDto search)
    {
        var queryParams = new List<string>();

        if (!string.IsNullOrEmpty(search.Make))
            queryParams.Add($"make={Uri.EscapeDataString(search.Make)}");
        if (!string.IsNullOrEmpty(search.Model))
            queryParams.Add($"model={Uri.EscapeDataString(search.Model)}");
        if (search.YearFrom.HasValue)
            queryParams.Add($"yearFrom={search.YearFrom}");
        if (search.YearTo.HasValue)
            queryParams.Add($"yearTo={search.YearTo}");
        if (search.PriceFrom.HasValue)
            queryParams.Add($"priceFrom={search.PriceFrom}");
        if (search.PriceTo.HasValue)
            queryParams.Add($"priceTo={search.PriceTo}");
        if (!string.IsNullOrEmpty(search.FuelType))
            queryParams.Add($"fuelType={Uri.EscapeDataString(search.FuelType)}");
        if (!string.IsNullOrEmpty(search.Location))
            queryParams.Add($"location={Uri.EscapeDataString(search.Location)}");

        queryParams.Add($"page={search.Page}");
        queryParams.Add($"pageSize={search.PageSize}");

        var queryString = string.Join("&", queryParams);
        var response = await _httpClient.GetAsync($"/api/carlistings?{queryString}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<CarListing>>(json, _jsonOptions) ?? new List<CarListing>();
        }

        return new List<CarListing>();
    }

    public async Task<CarListing?> GetCarByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/carlistings/{id}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CarListing>(json, _jsonOptions);
        }

        return null;
    }

    public async Task<CarListing> CreateCarListingAsync(CreateCarListingDto createDto)
    {
        var json = JsonSerializer.Serialize(createDto, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/api/carlistings", content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CarListing>(responseJson, _jsonOptions)!;
    }

    public async Task<bool> UpdateCarListingAsync(int id, CreateCarListingDto updateDto)
    {
        var json = JsonSerializer.Serialize(updateDto, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"/api/carlistings/{id}", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCarListingAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/api/carlistings/{id}");
        return response.IsSuccessStatusCode;
    }
}