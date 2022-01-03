using WebApi.Authorization;
using WebApi.Models;

namespace WebApi.Services;

public class CurrentUserService : ICurrentUserService
{
    public Task<User> GetByUserName(string value)
    {
        return Task.FromResult(
            new User(value, "aaaa", "aaa@aaa.aa", new List<Permission>() 
            { 
                new Permission(1, nameof(PermissionType.GetWeatherForecast)), 
                new Permission(2, "bbb") 
            }));
    }
}