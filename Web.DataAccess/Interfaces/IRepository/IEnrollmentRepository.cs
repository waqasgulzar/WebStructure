using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Implementation.Repository;
using Web.Entites.Entites;

namespace Web.DataAccess.Interfaces.IRepository
{
    public interface IEnrollmentRepository :IRepository<Enrollment,int>
    {
        Task<IEnumerable<Enrollment>> GetAllWithUserDetails();
        Task<int> GetUserCountByClassId(int classId);
        Task<Enrollment> UserEnrollmentDetailsRepo(string userId);
        bool UserExsist(int classId);
    }
}
