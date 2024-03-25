using Microsoft.EntityFrameworkCore;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RoomManagement2DbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<User>> GetAllWithCompanyAsync()
        {
            return await RoomManagement2DbContext.Users
                .Include(m => m.Company)
                .ToListAsync();
        }

        public async Task<User> GetWithCompanyByIdAsync(int id)
        {
            return await RoomManagement2DbContext.Users
                .Include(m => m.Company)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllWithCompanyByCompanyIdAsync(int companyId)
        {
            return await RoomManagement2DbContext.Users
                .Include(m => m.Company)
                .Where(m => m.CompanyID == companyId)
                .ToListAsync();
        }

        private RoomManagement2DbContext RoomManagement2DbContext
        {
            get { return Context as RoomManagement2DbContext; }
        }
    }
}
