using CarSelling.Shared.Models;
using System.Text.Json;

namespace CarSelling.Web.Services;

public class ModelGenerationApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public ModelGenerationApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<ModelGeneration>> GetModelGenerationsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/modelgeneration");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generations = JsonSerializer.Deserialize<List<ModelGeneration>>(json, _jsonOptions);

            return generations ?? new List<ModelGeneration>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching model generations: {ex.Message}");
            return new List<ModelGeneration>();
        }
    }

    public async Task<List<ModelGeneration>> GetGenerationsByModelIdAsync(int modelId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/modelgeneration/by-model-id/{modelId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generations = JsonSerializer.Deserialize<List<ModelGeneration>>(json, _jsonOptions);

            return generations ?? new List<ModelGeneration>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching generations for model ID {modelId}: {ex.Message}");
            return new List<ModelGeneration>();
        }
    }

    public async Task<List<string>> GetGenerationNamesByModelIdAsync(int modelId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/modelgeneration/names-by-model-id/{modelId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generationNames = JsonSerializer.Deserialize<List<string>>(json, _jsonOptions);

            return generationNames ?? new List<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching generation names for model ID {modelId}: {ex.Message}");
            return new List<string>();
        }
    }

    public async Task<List<ModelGeneration>> GetGenerationsByModelAsync(string modelName)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/modelgeneration/by-model/{Uri.EscapeDataString(modelName)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generations = JsonSerializer.Deserialize<List<ModelGeneration>>(json, _jsonOptions);

            return generations ?? new List<ModelGeneration>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching generations for model {modelName}: {ex.Message}");
            return new List<ModelGeneration>();
        }
    }

    public async Task<List<string>> GetGenerationNamesByModelAsync(string modelName)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/modelgeneration/names-by-model/{Uri.EscapeDataString(modelName)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generationNames = JsonSerializer.Deserialize<List<string>>(json, _jsonOptions);

            return generationNames ?? new List<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching generation names for model {modelName}: {ex.Message}");
            return new List<string>();
        }
    }

    public async Task<List<ModelGeneration>> GetGenerationsByBrandAndModelAsync(string brandName, string modelName)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/modelgeneration/by-brand-model/{Uri.EscapeDataString(brandName)}/{Uri.EscapeDataString(modelName)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generations = JsonSerializer.Deserialize<List<ModelGeneration>>(json, _jsonOptions);

            return generations ?? new List<ModelGeneration>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching generations for {brandName} {modelName}: {ex.Message}");
            return new List<ModelGeneration>();
        }
    }

    public async Task<List<string>> GetGenerationNamesByBrandAndModelAsync(string brandName, string modelName)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/modelgeneration/names-by-brand-model/{Uri.EscapeDataString(brandName)}/{Uri.EscapeDataString(modelName)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generationNames = JsonSerializer.Deserialize<List<string>>(json, _jsonOptions);

            return generationNames ?? new List<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching generation names for {brandName} {modelName}: {ex.Message}");
            return new List<string>();
        }
    }

    public async Task<List<ModelGeneration>> GetGenerationsByYearRangeAsync(int startYear, int endYear)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/modelgeneration/by-year-range/{startYear}/{endYear}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generations = JsonSerializer.Deserialize<List<ModelGeneration>>(json, _jsonOptions);

            return generations ?? new List<ModelGeneration>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching generations for year range {startYear}-{endYear}: {ex.Message}");
            return new List<ModelGeneration>();
        }
    }

    public async Task<ModelGeneration?> GetModelGenerationAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/modelgeneration/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generation = JsonSerializer.Deserialize<ModelGeneration>(json, _jsonOptions);

            return generation;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching generation with ID {id}: {ex.Message}");
            return null;
        }
    }

    public async Task<List<ModelGeneration>> SearchGenerationsAsync(
        string? brandName = null,
        string? modelName = null,
        int? yearFrom = null,
        int? yearTo = null,
        string? searchTerm = null)
    {
        try
        {
            var queryParams = new List<string>();
            
            if (!string.IsNullOrEmpty(brandName))
                queryParams.Add($"brandName={Uri.EscapeDataString(brandName)}");
            
            if (!string.IsNullOrEmpty(modelName))
                queryParams.Add($"modelName={Uri.EscapeDataString(modelName)}");
            
            if (yearFrom.HasValue)
                queryParams.Add($"yearFrom={yearFrom.Value}");
            
            if (yearTo.HasValue)
                queryParams.Add($"yearTo={yearTo.Value}");
            
            if (!string.IsNullOrEmpty(searchTerm))
                queryParams.Add($"searchTerm={Uri.EscapeDataString(searchTerm)}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
            var response = await _httpClient.GetAsync($"api/modelgeneration/search{queryString}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var generations = JsonSerializer.Deserialize<List<ModelGeneration>>(json, _jsonOptions);

            return generations ?? new List<ModelGeneration>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error searching model generations: {ex.Message}");
            return new List<ModelGeneration>();
        }
    }
}