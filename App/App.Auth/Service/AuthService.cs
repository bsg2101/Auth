using App.Auth.Data.Repositories;
using App.Auth.Model.DTOs;
using App.Auth.Model.Entities;

namespace App.Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);
            var user = new User
            {
                Username = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                PasswordHash = hashedPassword
            };
            return await _userRepository.AddUserAsync(user);
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
           var user = await _userRepository.GetUserByUsernameAsync(userLoginDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.PasswordHash))
            {
                return null;
            }
            return "JWT Token Here";
        }


    }
}
