using System.ComponentModel.DataAnnotations.Schema;
using Web.Entites.Entites.Base;
using Web.Identity;

namespace Web.Entites.Entites
{
    public class Enrollment: BaseEntity<int>
    {
        public int ClassId { get; set; }
        public string UserId { get; set; }
        public virtual Class Class { get; set; }
        public virtual WebUser WebUser { get; set; }
    }
}
