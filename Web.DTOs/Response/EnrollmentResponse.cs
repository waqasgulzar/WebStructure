using System.ComponentModel.DataAnnotations.Schema;
using Web.DTOs.Response.Base;
using Web.Identity;

namespace Web.DTOs.Response
{
    public class EnrollmentResponse : BaseEntity<int>
    {
        public int ClassId { get; set; }
        public string UserId { get; set; }
        public ClassResponse  Class { get; set; }
        public WebUser WebUser { get; set; }
    }
}
