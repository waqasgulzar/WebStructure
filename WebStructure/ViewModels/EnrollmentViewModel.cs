using Microsoft.AspNetCore.Mvc;
using Web.DTOs.Response;
using WebStructure.Admin.ViewModels.Base;

namespace WebStructure.Admin.ViewModels
{
    public class EnrollmentViewModel : BaseViewModel
    {
        public EnrollmentResponse Enrollment { get; set; }
        public bool UserEnrolled { get; set; }
        public IEnumerable<EnrollmentResponse> Enrollments { get; set; }
        public IEnumerable<ClassResponse> ClassResponses { get; set; }
    }
}
