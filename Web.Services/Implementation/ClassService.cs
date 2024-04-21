using AutoMapper;
using Web.Common.Exceptions;
using Web.DataAccess.Interfaces;
using Web.DTOs.Request;
using Web.DTOs.Response;
using Web.Entites.Entites;
using Web.Services.Interfaces;

namespace Web.Services.Implementation
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassService(IUnitOfWork unitOfWork,
          IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var classes = await _unitOfWork.ClassRepository.GetByIdAsync(id);
            if (classes == null)
            {
                throw new WebException("Classes cannot found.");
            }
            var checkUserEnrollment = _unitOfWork.EnrollmentRepository.UserExsist(classes.Id);
            if (checkUserEnrollment)
            {
                throw new WebException("Please Remove All Students From " + classes.ClassName + " Class Before Deleting.");
            }
            _unitOfWork.ClassRepository.Remove(classes);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<ClassResponse> Get(int id)
        {
            var city = await _unitOfWork.ClassRepository.GetByIdAsync(id);
            return _mapper.Map<ClassResponse>(city);
        }

        public async Task<IEnumerable<ClassResponse>> Get()
        {
            var listClass = await _unitOfWork.ClassRepository.GetAllAsync();
            return _mapper.Map<List<ClassResponse>>(listClass);
        }
  

        public async Task<ClassResponse> Save(string userId, ClassRequest classRequest)
        {
            var mappedClass = _mapper.Map<Class>(classRequest);
            if (mappedClass.Id > 0)
            {
                mappedClass.ModifiedBy = userId;
                mappedClass.ModifiedOn = DateTime.UtcNow;
                _unitOfWork.ClassRepository.Update(mappedClass);
            }
            else
            {
                mappedClass.CreatedBy = userId;
                mappedClass.CreatedOn = DateTime.UtcNow;
                await _unitOfWork.ClassRepository.AddAsync(mappedClass);
            }
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ClassResponse>(mappedClass);
        }
    }
}
