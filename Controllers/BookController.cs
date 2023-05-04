using Entitytest.Data;
using Entitytest.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entitytest.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly MyDbContext _MyDbContext;
    public BookController(MyDbContext MyDbContext)
    {
        _MyDbContext = MyDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var Books = await _MyDbContext.Book.ToListAsync();
        return Ok(Books);
    }

    [HttpGet]
    [Route("get-Book-by-Id_book")]
    public async Task<IActionResult> GetBookByIdAsync(int id)
    {
        var Book = await _MyDbContext.Book.FindAsync(id);
        return Ok(Book);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Book Book)
    {
        _MyDbContext.Book.Add(Book);
        await _MyDbContext.SaveChangesAsync();
        return Created($"/get-Book-by-id?id={Book.Id}", Book);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Book BookToUpdate)
    {
        _MyDbContext.Book.Update(BookToUpdate);
        await _MyDbContext.SaveChangesAsync();
        return NoContent();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var BookToDelete = await _MyDbContext.Book.FindAsync(id);
        if (BookToDelete == null)
        {
            return NotFound();
        }
        _MyDbContext.Book.Remove(BookToDelete);
        await _MyDbContext.SaveChangesAsync();
        return NoContent();
    }
}