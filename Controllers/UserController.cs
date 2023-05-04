using Entitytest.Data;
using Entitytest.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entitytest.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly MyDbContext _MyDbContext;
    public UserController(MyDbContext MyDbContext)
    {
        _MyDbContext = MyDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var Users = await _MyDbContext.User.ToListAsync();
        return Ok(Users);
    }

    [HttpGet]
    [Route("get-User-by-id")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var User = await _MyDbContext.User.FindAsync(id);
        return Ok(User);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(User User)
    {
        _MyDbContext.User.Add(User);
        await _MyDbContext.SaveChangesAsync();
        return Created($"/get-User-by-id?id={User.Id}", User);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(User UserToUpdate)
    {
        _MyDbContext.User.Update(UserToUpdate);
        await _MyDbContext.SaveChangesAsync();
        return NoContent();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var UserToDelete = await _MyDbContext.User.FindAsync(id);
        if (UserToDelete == null)
        {
            return NotFound();
        }
        _MyDbContext.User.Remove(UserToDelete);
        await _MyDbContext.SaveChangesAsync();
        return NoContent();
    }
}