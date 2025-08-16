using CarSelling.Api.Data;
using CarSelling.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarBrandController : ControllerBase
{
    private readonly CarSellingContext _context;

    public CarBrandController(CarSellingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarBrand>>> GetCarBrands()
    {
        var brands = await _context.CarBrands
            .Where(b => b.IsActive)
            .OrderBy(b => b.Name)
            .ToListAsync();

        return Ok(brands);
    }

    [HttpGet("active")]
    public async Task<ActionResult<IEnumerable<string>>> GetActiveBrandNames()
    {
        var brandNames = await _context.CarBrands
            .Where(b => b.IsActive)
            .OrderBy(b => b.Name)
            .Select(b => b.Name)
            .ToListAsync();

        return Ok(brandNames);
    }

    [HttpGet("luxury")]
    public async Task<ActionResult<IEnumerable<CarBrand>>> GetLuxuryBrands()
    {
        var luxuryBrands = await _context.CarBrands
            .Where(b => b.IsActive && b.IsLuxury)
            .OrderBy(b => b.Name)
            .ToListAsync();

        return Ok(luxuryBrands);
    }

    [HttpGet("by-country/{country}")]
    public async Task<ActionResult<IEnumerable<CarBrand>>> GetBrandsByCountry(string country)
    {
        var brands = await _context.CarBrands
            .Where(b => b.IsActive && b.Country.ToLower() == country.ToLower())
            .OrderBy(b => b.Name)
            .ToListAsync();

        return Ok(brands);
    }
}