using Web.DataAccess.Implementation;
using Web.DataAccess.Implementation.Repository;
using Web.DataAccess.Interfaces;
using Web.DataAccess.Interfaces.IRepository;
using Web.Services.Implementation;
using Web.Services.Interfaces;

namespace WebStructure.Admin.Extenstions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            RegisterBusinessLogic(services);
            RegisterRepos(services);
        }

        private static void RegisterRepos(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        }


        private static void RegisterBusinessLogic(IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
        }

    }
}
