using CarSelling.Api.Data;
using CarSelling.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarModelController : ControllerBase
{
    private readonly CarSellingContext _context;

    public CarModelController(CarSellingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModels()
    {
        var models = await _context.CarModels
            .Include(m => m.CarBrand)
            .Where(m => m.IsActive)
            .OrderBy(m => m.CarBrand.Name)
            .ThenBy(m => m.Name)
            .ToListAsync();

        return Ok(models);
    }

    [HttpGet("by-brand/{brandName}")]
    public async Task<ActionResult<IEnumerable<CarModel>>> GetModelsByBrand(string brandName)
    {
        var models = await _context.CarModels
            .Include(m => m.CarBrand)
            .Where(m => m.IsActive && m.CarBrand.Name.ToLower() == brandName.ToLower())
            .OrderBy(m => m.Name)
            .ToListAsync();

        return Ok(models);
    }

    [HttpGet("by-brand-id/{brandId}")]
    public async Task<ActionResult<IEnumerable<CarModel>>> GetModelsByBrandId(int brandId)
    {
        var models = await _context.CarModels
            .Where(m => m.IsActive && m.CarBrandId == brandId)
            .OrderBy(m => m.Name)
            .ToListAsync();

        return Ok(models);
    }

    [HttpGet("names-by-brand/{brandName}")]
    public async Task<ActionResult<IEnumerable<string>>> GetModelNamesByBrand(string brandName)
    {
        var modelNames = await _context.CarModels
            .Include(m => m.CarBrand)
            .Where(m => m.IsActive && m.CarBrand.Name.ToLower() == brandName.ToLower())
            .OrderBy(m => m.Name)
            .Select(m => m.Name)
            .ToListAsync();

        return Ok(modelNames);
    }

    [HttpGet("names-by-brand-id/{brandId}")]
    public async Task<ActionResult<IEnumerable<string>>> GetModelNamesByBrandId(int brandId)
    {
        var modelNames = await _context.CarModels
            .Where(m => m.IsActive && m.CarBrandId == brandId)
            .OrderBy(m => m.Name)
            .Select(m => m.Name)
            .ToListAsync();

        return Ok(modelNames);
    }

    [HttpGet("by-category/{category}")]
    public async Task<ActionResult<IEnumerable<CarModel>>> GetModelsByCategory(string category)
    {
        var models = await _context.CarModels
            .Include(m => m.CarBrand)
            .Where(m => m.IsActive && m.Category.ToLower() == category.ToLower())
            .OrderBy(m => m.CarBrand.Name)
            .ThenBy(m => m.Name)
            .ToListAsync();

        return Ok(models);
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<string>>> GetCategories()
    {
        var categories = await _context.CarModels
            .Where(m => m.IsActive && !string.IsNullOrEmpty(m.Category))
            .Select(m => m.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToListAsync();

        return Ok(categories);
    }

    [HttpGet("by-year-range/{startYear}/{endYear}")]
    public async Task<ActionResult<IEnumerable<CarModel>>> GetModelsByYearRange(int startYear, int endYear)
    {
        var models = await _context.CarModels
            .Include(m => m.CarBrand)
            .Where(m => m.IsActive && 
                        m.StartYear <= endYear && 
                        (m.EndYear == null || m.EndYear >= startYear))
            .OrderBy(m => m.CarBrand.Name)
            .ThenBy(m => m.Name)
            .ToListAsync();

        return Ok(models);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<CarModel>>> SearchModels(
        [FromQuery] string? brandName = null,
        [FromQuery] string? category = null,
        [FromQuery] int? yearFrom = null,
        [FromQuery] int? yearTo = null,
        [FromQuery] string? searchTerm = null)
    {
        var query = _context.CarModels
            .Include(m => m.CarBrand)
            .Where(m => m.IsActive);

        if (!string.IsNullOrEmpty(brandName))
        {
            query = query.Where(m => m.CarBrand.Name.ToLower() == brandName.ToLower());
        }

        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(m => m.Category.ToLower() == category.ToLower());
        }

        if (yearFrom.HasValue)
        {
            query = query.Where(m => m.EndYear == null || m.EndYear >= yearFrom.Value);
        }

        if (yearTo.HasValue)
        {
            query = query.Where(m => m.StartYear <= yearTo.Value);
        }

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(m => m.Name.ToLower().Contains(searchTerm.ToLower()) ||
                                     m.CarBrand.Name.ToLower().Contains(searchTerm.ToLower()));
        }

        var models = await query
            .OrderBy(m => m.CarBrand.Name)
            .ThenBy(m => m.Name)
            .ToListAsync();

        return Ok(models);
    }
}