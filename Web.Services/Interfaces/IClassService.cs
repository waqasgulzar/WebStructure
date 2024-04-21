using Web.DTOs.Request;
using Web.DTOs.Response;

namespace Web.Services.Interfaces
{
    public interface IClassService
    {
        Task<ClassResponse> Get(int id);
        Task<IEnumerable<ClassResponse>> Get();
        Task<ClassResponse> Save(string userId, ClassRequest classRequest);
        Task<bool> Delete(int id);
    }
}
