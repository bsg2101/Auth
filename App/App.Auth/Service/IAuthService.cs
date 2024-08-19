using App.Auth.Model.DTOs;

namespace App.Auth.Service
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);
    }
}
