using Web.DataAccess.Context;
using Web.DataAccess.Interfaces.IRepository;
using Web.Entites.Entites;

namespace Web.DataAccess.Implementation.Repository
{
    public class ClassRepository : Repository<Class, int>, IClassRepository
    {
        public ClassRepository(AppDbContext context) : base(context)
        {
        }
        private AppDbContext AppDbContext => Context as AppDbContext;
    }
}
