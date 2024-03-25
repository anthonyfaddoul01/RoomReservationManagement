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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(RoomManagement2DbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Company>> GetAllWithUsersAsync()
        {
            return await RoomManagement2DbContext.Companies
                .Include(a => a.Users)
                .ToListAsync();
        }

        public Task<Company> GetWithUsersByIdAsync(int id)
        {
            return RoomManagement2DbContext.Companies
                .Include(a => a.Users)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private RoomManagement2DbContext RoomManagement2DbContext
        {
            get { return Context as RoomManagement2DbContext; }
        }
    }
}
