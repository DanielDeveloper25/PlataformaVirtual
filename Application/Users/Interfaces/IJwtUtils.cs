using Domain.Entities;

namespace Application.Users.Interfaces
{
    public interface IJwtUtils
    {
        Task<string> GenerateJwtToken(User user);
        Task<int?> ValidateJwtToken(string token);
    }
}
