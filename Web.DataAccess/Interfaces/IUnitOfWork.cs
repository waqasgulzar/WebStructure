using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Interfaces.IRepository;

namespace Web.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClassRepository ClassRepository { get; }
        IEnrollmentRepository EnrollmentRepository { get; }
        Task<int> CommitAsync();
        Task CommitTransactionAsync();
        Task BeginTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
