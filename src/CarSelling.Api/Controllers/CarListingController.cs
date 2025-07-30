using CarSelling.Api.Services;
using CarSelling.Shared.DTOs;
using CarSelling.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSelling.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarListingsController : ControllerBase
{
    private readonly ICarListingService _carListingService;

    public CarListingsController(ICarListingService carListingService)
    {
        _carListingService = carListingService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarListing>>> GetCarListings([FromQuery] CarListingSearchDto search)
    {
        var listings = await _carListingService.SearchListingsAsync(search);
        return Ok(listings);
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<CarListing>>> GetAllCarListings()
    {
        var search = new CarListingSearchDto { Page = 1, PageSize = 100 };
        var listings = await _carListingService.SearchListingsAsync(search);
        return Ok(listings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CarListing>> GetCarListing(int id)
    {
        var listing = await _carListingService.GetListingByIdAsync(id);
        if (listing == null)
            return NotFound();

        return Ok(listing);
    }

    [HttpPost]
    public async Task<ActionResult<CarListing>> CreateCarListing(CreateCarListingDto createDto)
    {
        var listing = await _carListingService.CreateListingAsync(createDto);
        return CreatedAtAction(nameof(GetCarListing), new { id = listing.Id }, listing);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCarListing(int id, CreateCarListingDto updateDto)
    {
        var updated = await _carListingService.UpdateListingAsync(id, updateDto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarListing(int id)
    {
        var deleted = await _carListingService.DeleteListingAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}