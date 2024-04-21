using System.ComponentModel.DataAnnotations;

namespace Web.DTOs.Email
{
    public class EmailModel
    {
        [Required]
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}
