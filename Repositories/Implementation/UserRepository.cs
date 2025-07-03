using System;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Dtos;
using ToDoListAPI.Models;
using ToDoListAPI.Services;

namespace ToDoListAPI.Repositories.Implementation;

public class UserRepository(AppDbContext context, IMapper mapper, ITokenService tokenService) : IUserRepository
{
    public async Task<UserDto> RegisterUserAsync(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) throw new Exception("User Already regsitered");

        var user = mapper.Map<User>(registerDto);

        user.Username = registerDto.Username.ToLower();

        // Encrypting the password in Base 64
        var passwordBytes = Encoding.UTF8.GetBytes(registerDto.Password);
        user.Password = Convert.ToBase64String(passwordBytes);

        context.Users.Add(user);
        await context.SaveChangesAsync();
        return new UserDto
        {
            Username = user.Username,
            Token = tokenService.GenerateToken(user)
        };
    }

    public async Task<UserDto> LoginUserAsync(LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Username == loginDto.Username.ToLower()) ?? throw new Exception("Invalid user Name");

        // Decrypting the password from Base 64
        var passwordBytes = Convert.FromBase64String(user.Password);
        var decryptedPassword = Encoding.UTF8.GetString(passwordBytes);

        if (loginDto.Password != decryptedPassword) throw new Exception("Incorrect username");

        return new UserDto
        {
            Username = user.Username,
            Token = tokenService.GenerateToken(user)
        };
    }

    public async Task<User> GetUSerByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUSerByUserNameAsync(string Username)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    private async Task<Boolean> UserExists(string username)
    {
        return await context.Users.AnyAsync(user => user.Username == username);
    }


}
