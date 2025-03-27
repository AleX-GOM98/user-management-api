using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
    }
}
