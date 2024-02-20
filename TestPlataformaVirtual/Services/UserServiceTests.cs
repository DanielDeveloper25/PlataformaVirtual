using Application.Users.Dtos;
using Application.Users.Exceptions;
using Application.Users.Helpers;
using Application.Users.Interfaces;
using Application.Users.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using Moq;

public class UserServiceTests
{
    [Fact]
    public async Task Authenticate_ValidCredentials_ReturnsAuthenticateResponse()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var jwtUtilsMock = new Mock<IJwtUtils>();
        var appSettingsMock = new Mock<IOptions<AppSettings>>();
        var userService = new UserService(userRepositoryMock.Object, jwtUtilsMock.Object, appSettingsMock.Object);

        var model = new AuthenticateRequest { Email = "test@example.com", Password = "password123" };
        var user = new User { Id = 1, Email = model.Email, PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123") };
        var jwtToken = "mockJwtToken";

        userRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<User> { user });
        jwtUtilsMock.Setup(utils => utils.GenerateJwtToken(It.IsAny<User>())).ReturnsAsync(jwtToken);

        // Act
        var result = await userService.Authenticate(model);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<AuthenticateResponse>(result);
        Assert.Equal(user.Id, result.Id);
        Assert.Equal(jwtToken, result.Token);
    }

    [Fact]
    public async Task Authenticate_InvalidCredentials_ThrowsUserException()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var jwtUtilsMock = new Mock<IJwtUtils>();
        var appSettingsMock = new Mock<IOptions<AppSettings>>();
        var userService = new UserService(userRepositoryMock.Object, jwtUtilsMock.Object, appSettingsMock.Object);

        var model = new AuthenticateRequest { Email = "test@example.com", Password = "incorrectPassword" };

        userRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<User>());

        // Act & Assert
        await Assert.ThrowsAsync<UserException>(() => userService.Authenticate(model));
    }
}