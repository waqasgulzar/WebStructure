using Web.DTOs.Request.Base;

namespace Web.DTOs.Request
{
    public class EnrollmentRequest : BaseEntity<int>
    {
        public int ClassId { get; set; }
        public string UserId { get; set; }
    }
}
