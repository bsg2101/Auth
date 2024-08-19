using App.Auth.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Auth.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUserAsync(User user)
        {
           await _context.Users.AddAsync(user);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
