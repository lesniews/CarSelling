using CarSelling.Shared.Models;
using System.Text.Json;

namespace CarSelling.Web.Services;

public class CarModelApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public CarModelApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<CarModel>> GetCarModelsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/carmodel");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var models = JsonSerializer.Deserialize<List<CarModel>>(json, _jsonOptions);

            return models ?? new List<CarModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching car models: {ex.Message}");
            return new List<CarModel>();
        }
    }

    public async Task<List<CarModel>> GetModelsByBrandAsync(string brandName)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/carmodel/by-brand/{Uri.EscapeDataString(brandName)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var models = JsonSerializer.Deserialize<List<CarModel>>(json, _jsonOptions);

            return models ?? new List<CarModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching models for brand {brandName}: {ex.Message}");
            return new List<CarModel>();
        }
    }

    public async Task<List<CarModel>> GetModelsByBrandIdAsync(int brandId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/carmodel/by-brand-id/{brandId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var models = JsonSerializer.Deserialize<List<CarModel>>(json, _jsonOptions);

            return models ?? new List<CarModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching models for brand ID {brandId}: {ex.Message}");
            return new List<CarModel>();
        }
    }

    public async Task<List<string>> GetModelNamesByBrandAsync(string brandName)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/carmodel/names-by-brand/{Uri.EscapeDataString(brandName)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var modelNames = JsonSerializer.Deserialize<List<string>>(json, _jsonOptions);

            return modelNames ?? new List<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching model names for brand {brandName}: {ex.Message}");
            return new List<string>();
        }
    }

    public async Task<List<string>> GetModelNamesByBrandIdAsync(int brandId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/carmodel/names-by-brand-id/{brandId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var modelNames = JsonSerializer.Deserialize<List<string>>(json, _jsonOptions);

            return modelNames ?? new List<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching model names for brand ID {brandId}: {ex.Message}");
            return new List<string>();
        }
    }

    public async Task<List<CarModel>> GetModelsByCategoryAsync(string category)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/carmodel/by-category/{Uri.EscapeDataString(category)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var models = JsonSerializer.Deserialize<List<CarModel>>(json, _jsonOptions);

            return models ?? new List<CarModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching models for category {category}: {ex.Message}");
            return new List<CarModel>();
        }
    }

    public async Task<List<string>> GetCategoriesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/carmodel/categories");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<List<string>>(json, _jsonOptions);

            return categories ?? new List<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching categories: {ex.Message}");
            return new List<string>();
        }
    }

    public async Task<List<CarModel>> GetModelsByYearRangeAsync(int startYear, int endYear)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/carmodel/by-year-range/{startYear}/{endYear}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var models = JsonSerializer.Deserialize<List<CarModel>>(json, _jsonOptions);

            return models ?? new List<CarModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching models for year range {startYear}-{endYear}: {ex.Message}");
            return new List<CarModel>();
        }
    }

    public async Task<List<CarModel>> SearchModelsAsync(
        string? brandName = null,
        string? category = null,
        int? yearFrom = null,
        int? yearTo = null,
        string? searchTerm = null)
    {
        try
        {
            var queryParams = new List<string>();
            
            if (!string.IsNullOrEmpty(brandName))
                queryParams.Add($"brandName={Uri.EscapeDataString(brandName)}");
            
            if (!string.IsNullOrEmpty(category))
                queryParams.Add($"category={Uri.EscapeDataString(category)}");
            
            if (yearFrom.HasValue)
                queryParams.Add($"yearFrom={yearFrom.Value}");
            
            if (yearTo.HasValue)
                queryParams.Add($"yearTo={yearTo.Value}");
            
            if (!string.IsNullOrEmpty(searchTerm))
                queryParams.Add($"searchTerm={Uri.EscapeDataString(searchTerm)}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
            var response = await _httpClient.GetAsync($"api/carmodel/search{queryString}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var models = JsonSerializer.Deserialize<List<CarModel>>(json, _jsonOptions);

            return models ?? new List<CarModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error searching models: {ex.Message}");
            return new List<CarModel>();
        }
    }
}