using Web.DTOs.Response;
using WebStructure.Admin.ViewModels.Base;

namespace WebStructure.Admin.ViewModels
{
    public class ClassViewModel : BaseViewModel
    {
        public ClassResponse Class { get; set; }
        public IEnumerable<ClassResponse> Classes { get; set; }
    }
}
