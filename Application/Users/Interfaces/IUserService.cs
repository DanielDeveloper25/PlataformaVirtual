using Application.Users.Dtos;
using Domain.Entities;

namespace Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> CreateUser(CreateUserRequest model);
    }
}
