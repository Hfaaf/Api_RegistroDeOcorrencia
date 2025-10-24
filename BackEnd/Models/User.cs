using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ANU.Models;

public enum Roles
{
    Admin,
    Chefe,
    User
}

public class User
{   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; private set; }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }
    public string Telephone { get; private set; }
    public string Password { get; private set; }

    [BsonRepresentation(BsonType.String)]
    public Roles Role { get; private set; } = Roles.User;

    public User(string firstName, string lastName, string email, string cpf, string telephone, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Cpf = cpf;
        Telephone = telephone;
        Password = password;
    }
}