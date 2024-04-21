using AutoMapper;
using Web.DTOs.Request;
using Web.DTOs.Response;
using Web.Entites.Entites;

namespace WebStructure.Admin.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Class, ClassResponse>().ReverseMap();
            CreateMap<Class, ClassRequest>().ReverseMap();
            CreateMap<ClassRequest, ClassResponse>().ReverseMap();


            CreateMap<Enrollment, EnrollmentResponse>().ReverseMap();
            CreateMap<Enrollment, EnrollmentRequest>().ReverseMap();
            CreateMap<EnrollmentRequest, EnrollmentResponse>().ReverseMap();
        }
    }

}
