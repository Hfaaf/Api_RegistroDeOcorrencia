namespace ANU.Models;

public class RegisterRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Cpf { get; set; }
    public string? Telephone { get; set; }
    public string? Password { get; set; }
}

public class LoginRequest
{
    public string? Identifier { get; set; }
    public string? Password { get; set; }
}