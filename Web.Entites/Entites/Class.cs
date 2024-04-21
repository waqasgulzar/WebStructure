using Web.Entites.Entites.Base;

namespace Web.Entites.Entites
{
    public class Class : BaseEntity<int>
    {
        public String ClassName { get; set; }
        public String ClassDetails { get; set; }
        public String Grade { get; set; }
        public DateTimeOffset Timing { get; set; }
        public int MaxSize { get; set; }
    }
}
