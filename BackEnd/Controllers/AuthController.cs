using System.Security.Cryptography;
using System.Text;
using ANU.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ANU.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMongoCollection<User> _users;
    private readonly IConfiguration _config;
    
    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    public AuthController(IMongoCollection<User> users ,IConfiguration config)
    {
        _users = users;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName) ||
            string.IsNullOrWhiteSpace(request.Email) ||
            string.IsNullOrWhiteSpace(request.Cpf) ||
            string.IsNullOrWhiteSpace(request.Telephone) ||
            string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new {message = "Por favor, preencha todos os campos. "});
        }

        var existingUser = await _users.Find(u => u.Email == request.Email || u.Cpf == request.Cpf).FirstOrDefaultAsync();
        if(existingUser != null)
            return Conflict(new {message = "Usuario já registrado. "});
        
        var hashedPassword = HashPassword(request.Password);
        var user = new User(request.FirstName, request.LastName, request.Email, request.Cpf, request.Telephone, hashedPassword);
        
        await _users.InsertOneAsync(user);
        return StatusCode(201, new {message = "Usuário registrado!"});
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Identifier) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new { message = "Por favor, preencha todos os campos." });
        }
        
        var user = await _users.FindAsync(u =>)
        {
            
        }
    }
    
    
    
}