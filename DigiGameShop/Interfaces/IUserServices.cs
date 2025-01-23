using DigiGameShop.Models;

namespace DigiGameShop.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> AddUserAsync(AddUpdateUser user);
        Task<User?> UpdateUserAsync(int id, AddUpdateUser updatedUser);
        Task<bool> DeleteUserAsync(int id);
    }
}
