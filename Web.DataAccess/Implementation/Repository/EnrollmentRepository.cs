using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Context;
using Web.DataAccess.Interfaces.IRepository;
using Web.Entites.Entites;

namespace Web.DataAccess.Implementation.Repository
{
    public class EnrollmentRepository : Repository<Enrollment, int>, IEnrollmentRepository
    {
        public EnrollmentRepository(AppDbContext context) : base(context)
        {
        }
        private AppDbContext AppDbContext => Context as AppDbContext;

        public async Task<IEnumerable<Enrollment>> GetAllWithUserDetails()
        {
            var enrollments = await AppDbContext.Enrollment
              .Include(e => e.Class)    
              .Include(e => e.WebUser)   
              .ToListAsync();
            return enrollments;
        }

        public async Task<int> GetUserCountByClassId(int classId)
        {
            var enrollment = await AppDbContext.Enrollment.CountAsync(x => x.ClassId == classId);
            return enrollment;
        }

        public async Task<Enrollment> UserEnrollmentDetailsRepo(string userId)
        {
            var enrollment = await AppDbContext.Enrollment.Where(x=>x.UserId==userId)
             .Include(e => e.Class)
             .Include(e => e.WebUser)
             .FirstOrDefaultAsync();
            return enrollment;
        }

        public bool UserExsist(int classId)
        {
            bool enrollmentExists = AppDbContext.Enrollment.Any(x => x.ClassId == classId);
            return enrollmentExists;
        }
    }
}
