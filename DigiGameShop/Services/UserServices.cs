using DigiGameShop.Database;
using DigiGameShop.Interfaces;
using DigiGameShop.Models;

using Microsoft.EntityFrameworkCore;

namespace DigiGameShop.Services
{
    public class UserServices(DigiGameShopDbContext db) : IUserServices
    {
        private readonly DigiGameShopDbContext _db = db;

        public async Task<List<User>> GetUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<User?> AddUserAsync(AddUpdateUser newUser)
        {
            var user = new User
            {
                Name = newUser.Name,
                Email = newUser.Email,
                Password = newUser.Password,
            };
            _db.Users.Add(user);
            var result = await _db.SaveChangesAsync();
            return result > 0 ? user : null;
        }
        public async Task<User?> UpdateUserAsync(int id, AddUpdateUser updatedUser)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                user.Password = updatedUser.Password;

                var result = await _db.SaveChangesAsync();
                return result > 0 ? user : null;
            }
            return null;
        }
        
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
