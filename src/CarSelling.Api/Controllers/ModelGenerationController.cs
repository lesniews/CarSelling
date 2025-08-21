using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSelling.Api.Data;
using CarSelling.Shared.Models;

namespace CarSelling.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModelGenerationController : ControllerBase
{
    private readonly CarSellingContext _context;
    private readonly ILogger<ModelGenerationController> _logger;

    public ModelGenerationController(CarSellingContext context, ILogger<ModelGenerationController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Get all model generations
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ModelGeneration>>> GetModelGenerations()
    {
        try
        {
            var generations = await _context.ModelGenerations
                .Include(g => g.CarModel)
                .ThenInclude(m => m.CarBrand)
                .Where(g => g.IsActive)
                .OrderBy(g => g.CarModel.CarBrand.Name)
                .ThenBy(g => g.CarModel.Name)
                .ThenBy(g => g.StartYear)
                .ToListAsync();

            return Ok(generations);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching model generations");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get model generations by model ID
    /// </summary>
    [HttpGet("by-model-id/{modelId}")]
    public async Task<ActionResult<IEnumerable<ModelGeneration>>> GetGenerationsByModelId(int modelId)
    {
        try
        {
            var generations = await _context.ModelGenerations
                .Include(g => g.CarModel)
                .ThenInclude(m => m.CarBrand)
                .Where(g => g.CarModelId == modelId && g.IsActive)
                .OrderBy(g => g.StartYear)
                .ToListAsync();

            if (!generations.Any())
            {
                return NotFound($"No generations found for model ID {modelId}");
            }

            return Ok(generations);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching generations for model ID {ModelId}", modelId);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get model generation names by model ID
    /// </summary>
    [HttpGet("names-by-model-id/{modelId}")]
    public async Task<ActionResult<IEnumerable<string>>> GetGenerationNamesByModelId(int modelId)
    {
        try
        {
            var generationNames = await _context.ModelGenerations
                .Where(g => g.CarModelId == modelId && g.IsActive)
                .OrderBy(g => g.StartYear)
                .Select(g => g.Name)
                .ToListAsync();

            return Ok(generationNames);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching generation names for model ID {ModelId}", modelId);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get model generations by model name
    /// </summary>
    [HttpGet("by-model/{modelName}")]
    public async Task<ActionResult<IEnumerable<ModelGeneration>>> GetGenerationsByModel(string modelName)
    {
        try
        {
            var generations = await _context.ModelGenerations
                .Include(g => g.CarModel)
                .ThenInclude(m => m.CarBrand)
                .Where(g => g.CarModel.Name.ToLower() == modelName.ToLower() && g.IsActive)
                .OrderBy(g => g.CarModel.CarBrand.Name)
                .ThenBy(g => g.StartYear)
                .ToListAsync();

            if (!generations.Any())
            {
                return NotFound($"No generations found for model '{modelName}'");
            }

            return Ok(generations);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching generations for model {ModelName}", modelName);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get model generation names by model name
    /// </summary>
    [HttpGet("names-by-model/{modelName}")]
    public async Task<ActionResult<IEnumerable<string>>> GetGenerationNamesByModel(string modelName)
    {
        try
        {
            var generationNames = await _context.ModelGenerations
                .Include(g => g.CarModel)
                .Where(g => g.CarModel.Name.ToLower() == modelName.ToLower() && g.IsActive)
                .OrderBy(g => g.StartYear)
                .Select(g => g.Name)
                .ToListAsync();

            if (!generationNames.Any())
            {
                return NotFound($"No generations found for model '{modelName}'");
            }

            return Ok(generationNames);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching generation names for model {ModelName}", modelName);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get model generations by brand and model name
    /// </summary>
    [HttpGet("by-brand-model/{brandName}/{modelName}")]
    public async Task<ActionResult<IEnumerable<ModelGeneration>>> GetGenerationsByBrandAndModel(string brandName, string modelName)
    {
        try
        {
            var generations = await _context.ModelGenerations
                .Include(g => g.CarModel)
                .ThenInclude(m => m.CarBrand)
                .Where(g => g.CarModel.CarBrand.Name.ToLower() == brandName.ToLower() 
                        && g.CarModel.Name.ToLower() == modelName.ToLower() 
                        && g.IsActive)
                .OrderBy(g => g.StartYear)
                .ToListAsync();

            if (!generations.Any())
            {
                return NotFound($"No generations found for {brandName} {modelName}");
            }

            return Ok(generations);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching generations for {BrandName} {ModelName}", brandName, modelName);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get model generation names by brand and model name
    /// </summary>
    [HttpGet("names-by-brand-model/{brandName}/{modelName}")]
    public async Task<ActionResult<IEnumerable<string>>> GetGenerationNamesByBrandAndModel(string brandName, string modelName)
    {
        try
        {
            var generationNames = await _context.ModelGenerations
                .Include(g => g.CarModel)
                .ThenInclude(m => m.CarBrand)
                .Where(g => g.CarModel.CarBrand.Name.ToLower() == brandName.ToLower() 
                        && g.CarModel.Name.ToLower() == modelName.ToLower() 
                        && g.IsActive)
                .OrderBy(g => g.StartYear)
                .Select(g => g.Name)
                .ToListAsync();

            if (!generationNames.Any())
            {
                return NotFound($"No generations found for {brandName} {modelName}");
            }

            return Ok(generationNames);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching generation names for {BrandName} {ModelName}", brandName, modelName);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get model generations by year range
    /// </summary>
    [HttpGet("by-year-range/{startYear}/{endYear}")]
    public async Task<ActionResult<IEnumerable<ModelGeneration>>> GetGenerationsByYearRange(int startYear, int endYear)
    {
        try
        {
            var generations = await _context.ModelGenerations
                .Include(g => g.CarModel)
                .ThenInclude(m => m.CarBrand)
                .Where(g => g.StartYear >= startYear && (g.EndYear == null || g.EndYear <= endYear) && g.IsActive)
                .OrderBy(g => g.CarModel.CarBrand.Name)
                .ThenBy(g => g.CarModel.Name)
                .ThenBy(g => g.StartYear)
                .ToListAsync();

            return Ok(generations);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching generations for year range {StartYear}-{EndYear}", startYear, endYear);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get specific model generation by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ModelGeneration>> GetModelGeneration(int id)
    {
        try
        {
            var generation = await _context.ModelGenerations
                .Include(g => g.CarModel)
                .ThenInclude(m => m.CarBrand)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (generation == null)
            {
                return NotFound($"Model generation with ID {id} not found");
            }

            return Ok(generation);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching generation with ID {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Search model generations with filters
    /// </summary>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ModelGeneration>>> SearchGenerations(
        string? brandName = null,
        string? modelName = null,
        int? yearFrom = null,
        int? yearTo = null,
        string? searchTerm = null)
    {
        try
        {
            var query = _context.ModelGenerations
                .Include(g => g.CarModel)
                .ThenInclude(m => m.CarBrand)
                .Where(g => g.IsActive);

            if (!string.IsNullOrEmpty(brandName))
                query = query.Where(g => g.CarModel.CarBrand.Name.ToLower().Contains(brandName.ToLower()));

            if (!string.IsNullOrEmpty(modelName))
                query = query.Where(g => g.CarModel.Name.ToLower().Contains(modelName.ToLower()));

            if (yearFrom.HasValue)
                query = query.Where(g => g.EndYear == null || g.EndYear >= yearFrom.Value);

            if (yearTo.HasValue)
                query = query.Where(g => g.StartYear <= yearTo.Value);

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(g => g.Name.ToLower().Contains(searchTerm.ToLower()) ||
                                        g.Description.ToLower().Contains(searchTerm.ToLower()));

            var generations = await query
                .OrderBy(g => g.CarModel.CarBrand.Name)
                .ThenBy(g => g.CarModel.Name)
                .ThenBy(g => g.StartYear)
                .ToListAsync();

            return Ok(generations);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching model generations");
            return StatusCode(500, "Internal server error");
        }
    }
}