using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DTOs.Request;
using Web.DTOs.Response;

namespace Web.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<EnrollmentResponse> Get(int id);
        Task<EnrollmentResponse> UserEnrollmentDetails(string userId);
        Task<IEnumerable<EnrollmentResponse>> Get();
        Task<EnrollmentResponse> Save(string userId, EnrollmentRequest enrollmentRequest);
        Task<bool> Delete(int id);
    }
}
