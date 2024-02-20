using Application.Users.Dtos;
using Application.Users.Helpers;
using Application.Users.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using BCrypt.Net;
using Application.Users.Exceptions;

namespace Application.Users.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UserService(
            IUserRepository userRepository,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }


        public  async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var user = users.SingleOrDefault(x => x.Email == model.Email);

                if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                {
                    throw new UserException("Username or password is incorrect");
                }

                var jwtToken = await _jwtUtils.GenerateJwtToken(user);

                return new AuthenticateResponse(user, jwtToken);
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task<User> CreateUser(CreateUserRequest model)
        {
            var existingUser = await _userRepository.GetAllAsync();
            if (existingUser.Any(u => u.Email == model.Email))
            {
                throw new UserException("Email is already registered");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var newUser = new User
            {
                Name = model.Name,
                Email = model.Email,
                PasswordHash = hashedPassword,
                Role = model.Role 
            };

            await _userRepository.AddAsync(newUser);

            return newUser;
        }
    }
}
