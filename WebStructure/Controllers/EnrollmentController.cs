using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common.Constant;
using Web.Common.Enumerations;
using Web.Common.Logging;
using Web.DTOs.Request;
using Web.DTOs.Response;
using Web.Services.Implementation;
using Web.Services.Interfaces;
using WebStructure.Admin.Controllers.Base;
using WebStructure.Admin.ViewModels;

namespace WebStructure.Admin.Controllers
{
    [Authorize]
    public class EnrollmentController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IEnrollmentService _enrollmentService;
        private readonly IClassService _classService;
        public EnrollmentController(IMapper mapper, IEnrollmentService enrollmentService, IClassService classService)
        {
            _mapper = mapper;
            _enrollmentService = enrollmentService;
            _classService = classService;
        }
        [Authorize(Roles = IdentityConstant.Admin)]
        public async Task<IActionResult> Index()
        {
            var vm = new EnrollmentViewModel();

            try
            {
                vm.Enrollments = (await _enrollmentService.Get()).ToList();
            }
            catch (Exception ex)
            {
                WebLogging.LogException(ex.Message);
                vm.AddMessage(MessageType.Error, ex.Message, "", true);
            }
            return View(vm);
        }
        [Authorize(Roles = IdentityConstant.User)]
        public async Task<IActionResult> Edit()

        {
            var vm = new EnrollmentViewModel();
            try
            {
                var checkUserEnrollement = await _enrollmentService.UserEnrollmentDetails(UserId);
                if (checkUserEnrollement != null)
                {
                    vm.Enrollment = checkUserEnrollement;
                    vm.UserEnrolled = true;
                }
                else
                {
                    vm.ClassResponses = await _classService.Get();
                    vm.UserEnrolled = false;
                }
            }
            catch (Exception ex)
            {
                WebLogging.LogException(ex.Message);
                vm.AddMessage(MessageType.Error, ex.Message, "", true);
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EnrollmentViewModel viewmodel)
        {
            try
            {
                var enrollment = _mapper.Map<EnrollmentRequest>(viewmodel.Enrollment);
                viewmodel.Enrollment = await _enrollmentService.Save(UserId, enrollment);
                viewmodel.AddMessage(MessageType.Info, "", "Enrollment Saved.", false);
                return RedirectToAction(nameof(Edit));
            }
            catch (Exception ex)
            {
                WebLogging.LogException(ex.Message);
                viewmodel.AddMessage(MessageType.Error, ex.Message, "", true);
            }
            finally
            {
                viewmodel.ClassResponses = await _classService.Get();
            }
            ModelState.Clear();
            return View(viewmodel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vm = new EnrollmentViewModel();
            try
            {
                await _enrollmentService.Delete(id);
                vm.AddMessage(MessageType.Info, "", "Enrollment Is Deleted", true);
            }
            catch (Exception ex)
            {
                WebLogging.LogException(ex.Message);
                vm.AddMessage(MessageType.Error, ex.Message, "", true);
            }
            finally
            {
                vm.Enrollments = (await _enrollmentService.Get()).ToList();
            }

            return View("Index", vm);
        }
    }
}
