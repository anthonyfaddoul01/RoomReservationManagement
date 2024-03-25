using RoomManagement2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithCompanyAsync();
        Task<User> GetWithCompanyByIdAsync(int id);
        Task<IEnumerable<User>> GetAllWithCompanyByCompanyIdAsync(int companyId);
    }
}
