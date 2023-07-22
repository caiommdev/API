using API.Models;

namespace API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user);
        Task<UserModel> DeleteUser(int id);
    }
}