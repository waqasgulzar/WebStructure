using AutoMapper;
using Web.Common.Exceptions;
using Web.DataAccess.Interfaces;
using Web.DTOs.Request;
using Web.DTOs.Response;
using Web.Entites.Entites;
using Web.Services.Interfaces;

namespace Web.Services.Implementation
{
    public class EnrollmentService: IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EnrollmentService(IUnitOfWork unitOfWork,
          IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var enrollment = await _unitOfWork.EnrollmentRepository.GetByIdAsync(id);
            if (enrollment == null)
            {
                throw new WebException("Enrollment cannot found.");
            }
            _unitOfWork.EnrollmentRepository.Remove(enrollment);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<EnrollmentResponse> Get(int id)
        {
            var enrollment = await _unitOfWork.EnrollmentRepository.GetByIdAsync(id);
            return _mapper.Map<EnrollmentResponse>(enrollment);
        }

        public async Task<IEnumerable<EnrollmentResponse>> Get()
        {
            var listEnrollment = await _unitOfWork.EnrollmentRepository.GetAllWithUserDetails();
            return _mapper.Map<List<EnrollmentResponse>>(listEnrollment);
        }


        public async Task<EnrollmentResponse> Save(string userId, EnrollmentRequest enrollmentRequest)
        {
            var classLimit = (await _unitOfWork.ClassRepository.GetByIdAsync(enrollmentRequest.ClassId)).MaxSize;
            var enrolledUserCount = await _unitOfWork.EnrollmentRepository.GetUserCountByClassId(enrollmentRequest.ClassId);
            if(classLimit<= enrolledUserCount)
            {
                throw new WebException("Cannot Add Class Limit Exceed.");
            }
            var mappedEnrollment = _mapper.Map<Enrollment>(enrollmentRequest);
            if (mappedEnrollment.Id > 0)
            {
                mappedEnrollment.UserId = userId;
                mappedEnrollment.ModifiedBy = userId;
                mappedEnrollment.ModifiedOn = DateTime.UtcNow;
                _unitOfWork.EnrollmentRepository.Update(mappedEnrollment);
            }
            else
            {
                mappedEnrollment.UserId = userId;
                mappedEnrollment.CreatedBy = userId;
                mappedEnrollment.CreatedOn = DateTime.UtcNow;
                await _unitOfWork.EnrollmentRepository.AddAsync(mappedEnrollment);
            }
            await _unitOfWork.CommitAsync();
            return _mapper.Map<EnrollmentResponse>(mappedEnrollment);
        }

        public async Task<EnrollmentResponse> UserEnrollmentDetails(string userId)
        {
            var enrollment = await _unitOfWork.EnrollmentRepository.UserEnrollmentDetailsRepo(userId);
            return _mapper.Map<EnrollmentResponse>(enrollment);
        }
    }
}
