using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUser()
    {
        var users = await _context.Users.ToListAsync();
        if (users == null || !users.Any())
            return NotFound("No users found.");
        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }
}
