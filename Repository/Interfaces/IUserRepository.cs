using API.Models;

namespace API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(UserModel user);
        Task<UserModel> GetUserById(int id);
        Task<List<UserModel>> GetAllUsers();
        Task UpdateUser(UserModel user, int id);
        Task DeleteUser(int id);
    }
}