using Microsoft.AspNetCore.Mvc;
using ComicEStoreDomain.Repositories;
using ComicEStoreDomain.Models;
using Microsoft.EntityFrameworkCore;
using ComicEStoreDomain.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComicEStoreService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductDataContext _context;
    public ProductController(ProductDataContext context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return BadRequest("Product name is required.");
        }

        // Sprawdzamy, czy Publisher istnieje
        var publisherExists = await _context.Publishers.AnyAsync(p => p.Id == dto.PublisherId);
        if (!publisherExists)
        {
            return BadRequest($"Publisher with Id {dto.PublisherId} does not exist.");
        }

        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock,
            PublisherId = dto.PublisherId
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _context.Products
            .Include(p => p.Publisher)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound();

        // Mapowanie encji na DTO
        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            PublisherId = product.PublisherId,
            PublisherName = product.Publisher?.Name ?? string.Empty
        };

        return Ok(productDto);
    }
}
