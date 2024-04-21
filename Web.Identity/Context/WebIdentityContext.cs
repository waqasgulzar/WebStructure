using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web.Identity.Context
{
    public class WebIdentityContext : IdentityDbContext<WebUser>
    {
        public WebIdentityContext(DbContextOptions<WebIdentityContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }



}
