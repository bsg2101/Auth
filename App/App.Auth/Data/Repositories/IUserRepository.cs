using App.Auth.Model.Entities;

namespace App.Auth.Data.Repositories
{
    public interface IUserRepository
    {
       Task<bool> AddUserAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
    }
}
