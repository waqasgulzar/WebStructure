using Microsoft.AspNetCore.Identity;
using Web.DataAccess.Context;
using Web.DataAccess.Implementation.Repository;
using Web.DataAccess.Interfaces;
using Web.DataAccess.Interfaces.IRepository;
using Web.Identity;

namespace Web.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IClassRepository _classRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IClassRepository ClassRepository => _classRepository ?? new ClassRepository(_context);
        public IEnrollmentRepository EnrollmentRepository => _enrollmentRepository ?? new EnrollmentRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
