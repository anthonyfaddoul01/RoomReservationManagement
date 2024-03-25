using RoomManagement2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllWithCompany();
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetUsersByCompanyId(int companyId);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User userToBeUpdated, User user);
        Task DeleteUser(User user);
        Task<int> GetUserIdByEmailAsync(string userEmail);
    }
}
