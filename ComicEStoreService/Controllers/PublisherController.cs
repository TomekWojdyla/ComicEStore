using Microsoft.AspNetCore.Mvc;
using ComicEStoreDomain.Repositories;
using ComicEStoreDomain.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComicEStoreService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly ProductDataContext _context;
    public PublisherController(ProductDataContext context)
    {
        _context = context;
    }

    // POST api/<PublisherController>
    [HttpPost]
    public async Task<IActionResult> CreatePublisher([FromBody] Publisher publisher)
    {
        if (string.IsNullOrWhiteSpace(publisher.Name))
        {
            return BadRequest("Publisher name is required.");
        }

        _context.Publishers.Add(publisher);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPublisherById), new { id = publisher.Id }, publisher);
    }


    //GET api/<PublisherController>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPublisherById(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher == null)
        {
            return NotFound();
        }
        return Ok(publisher);
    }

    //DELETE api/<PublisherController>
    [HttpDelete("{id}")]
}
