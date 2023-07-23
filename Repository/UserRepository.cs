using API.Data;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContex _dbcontex;

        public UserRepository(TaskSystemDBContex taskSystemDBContex)
        {
            _dbcontex = taskSystemDBContex;
        }
        
        public async Task CreateUser(UserModel user)
        {
            await _dbcontex.Users.AddAsync(user);
            await _dbcontex.SaveChangesAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            UserModel user = await _dbcontex.Users.FindAsync(id);
            return user;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            users = await _dbcontex.Users.ToListAsync();
            return users;
        }

        public async Task UpdateUser(UserModel user, int id)
        {
            UserModel userToUpdate = await GetUserById(id);
            
            if(userToUpdate == null)
                throw new Exception("User not found");

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;

            _dbcontex.Users.Update(userToUpdate);
            await _dbcontex.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            UserModel user = await GetUserById(id);
            
            if(user == null)
                throw new Exception("User not found");

            _dbcontex.Users.Remove(user);
            await _dbcontex.SaveChangesAsync();
        }
    }
}