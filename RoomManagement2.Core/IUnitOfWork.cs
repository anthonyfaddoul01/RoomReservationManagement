using RoomManagement2.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICompanyRepository Companies { get; }
        IRoomRepository Rooms { get; }
        IReserveRepository Reservations { get; }
        Task<int> CommitAsync();
    }
}
