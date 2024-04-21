using Web.DTOs.Request.Base;

namespace Web.DTOs.Request
{
    public class ClassRequest : BaseEntity<int>
    {
        public String ClassName { get; set; }
        public String ClassDetails { get; set; }
        public String Grade { get; set; }
        public DateTimeOffset Timing { get; set; }
        public int MaxSize { get; set; }
    }
}
