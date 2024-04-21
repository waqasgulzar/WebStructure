using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using Web.Entites.Entites;
using Web.Identity;

namespace Web.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<WebUser> AspNetUsers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Class)
                .WithMany()
                .HasForeignKey(e => e.ClassId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.WebUser)
                .WithMany()
                .HasForeignKey(e => e.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}