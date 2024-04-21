using Microsoft.AspNetCore.Identity;

namespace Web.Identity
{
    public class WebUser : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? SurName { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }


    }
}