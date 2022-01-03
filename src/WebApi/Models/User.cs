namespace WebApi.Models;

public record User(string Id, string Name, string Email, IEnumerable<Permission> Permissions);