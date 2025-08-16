using CarSelling.Shared.Models;
using System.Text.Json;

namespace CarSelling.Web.Services;

public class CarBrandApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public CarBrandApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<CarBrand>> GetCarBrandsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/carbrand");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var brands = JsonSerializer.Deserialize<List<CarBrand>>(json, _jsonOptions);

            return brands ?? new List<CarBrand>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching car brands: {ex.Message}");
            return new List<CarBrand>();
        }
    }

    public async Task<List<string>> GetActiveBrandNamesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/carbrand/active");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var brandNames = JsonSerializer.Deserialize<List<string>>(json, _jsonOptions);

            return brandNames ?? new List<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching brand names: {ex.Message}");
            return new List<string>();
        }
    }

    public async Task<List<CarBrand>> GetLuxuryBrandsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/carbrand/luxury");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var brands = JsonSerializer.Deserialize<List<CarBrand>>(json, _jsonOptions);

            return brands ?? new List<CarBrand>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching luxury brands: {ex.Message}");
            return new List<CarBrand>();
        }
    }

    public async Task<List<CarBrand>> GetBrandsByCountryAsync(string country)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/carbrand/by-country/{Uri.EscapeDataString(country)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var brands = JsonSerializer.Deserialize<List<CarBrand>>(json, _jsonOptions);

            return brands ?? new List<CarBrand>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching brands by country: {ex.Message}");
            return new List<CarBrand>();
        }
    }
}