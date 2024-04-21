using Web.DTOs.Response.Base;

namespace Web.DTOs.Response
{
    public class ClassResponse :BaseEntity<int>
    {
        public String ClassName { get; set; }
        public String ClassDetails { get; set; }
        public String Grade { get; set; }
        public DateTimeOffset Timing { get; set; }
        public int MaxSize { get; set; }
    }
}
