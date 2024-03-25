using RoomManagement2.Core;
using RoomManagement2.Core.Repositories;
using RoomManagement2.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RoomManagement2DbContext _context;
        private UserRepository _userRepository;
        private CompanyRepository _companyRepository;
        private RoomRepository _roomRepository;
        private ReserveRepository _reserveRepository;

        public UnitOfWork(RoomManagement2DbContext context)
        {
            this._context = context;
        }

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);

        public IRoomRepository Rooms => _roomRepository = _roomRepository ?? new RoomRepository(_context);

        public IReserveRepository Reservations => _reserveRepository = _reserveRepository ?? new ReserveRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
