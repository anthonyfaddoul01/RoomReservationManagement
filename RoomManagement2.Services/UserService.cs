using Microsoft.EntityFrameworkCore;
using RoomManagement2.Core;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAllWithCompany()
        {
            return await _unitOfWork.Users
                .GetAllWithCompanyAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users
                .GetWithCompanyByIdAsync(id);
        }

        public async Task<int> GetUserIdByEmailAsync(string userEmail)
        {
            var user = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == userEmail);
            return user?.Id ?? 0;
        }

        public async Task<IEnumerable<User>> GetUsersByCompanyId(int companyId)
        {
            return await _unitOfWork.Users
                .GetAllWithCompanyByCompanyIdAsync(companyId);
        }

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.Name = user.Name;
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.Role = user.Role;
            userToBeUpdated.CompanyID = user.CompanyID;

            await _unitOfWork.CommitAsync();
        }
    }
}
