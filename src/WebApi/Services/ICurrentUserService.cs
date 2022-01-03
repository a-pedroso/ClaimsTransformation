using WebApi.Models;

namespace WebApi.Services;

public interface ICurrentUserService
{
    Task<User> GetByUserName(string value);
}
