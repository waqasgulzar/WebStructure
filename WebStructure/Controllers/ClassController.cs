using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common.Constant;
using Web.Common.Enumerations;
using Web.Common.Logging;
using Web.DTOs.Request;
using Web.DTOs.Response;
using Web.Services.Interfaces;
using WebStructure.Admin.Controllers.Base;
using WebStructure.Admin.ViewModels;

namespace WebStructure.Admin.Controllers
{
    [Authorize(Roles = IdentityConstant.Admin)]
    public class ClassController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IClassService _classService;
        public ClassController(IMapper mapper,IClassService classService)
        {
            _mapper = mapper;
            _classService = classService;
        }
        public async Task<IActionResult> Index()
        {
            var vm = new ClassViewModel();

            try
            {
                vm.Classes = (await _classService.Get()).ToList();
            }
            catch (Exception ex)
            {
                WebLogging.LogException(ex.Message);
                vm.AddMessage(MessageType.Error, ex.Message, "", true);
            }
            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)

        {
            var vm = new ClassViewModel();
            try
            {
                if (id == 0)
                    vm.Class = new ClassResponse();
                else
                    vm.Class = await _classService.Get(id);
            }
            catch (Exception ex)
            {
                WebLogging.LogException(ex.Message);
                vm.AddMessage(MessageType.Error, ex.Message, "", true);
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClassViewModel viewmodel)
        {
            try
            {
                var classRequest = _mapper.Map<ClassRequest>(viewmodel.Class);
                viewmodel.Class = await _classService.Save(UserId, classRequest);
                viewmodel.AddMessage(MessageType.Info, "", "Class Saved.", false);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                WebLogging.LogException(ex.Message);
                viewmodel.AddMessage(MessageType.Error, ex.Message, "", true);
            }
            ModelState.Clear();
            return View(viewmodel);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var vm = new ClassViewModel();
            try
            {
                await _classService.Delete(id);
                vm.AddMessage(MessageType.Info, "", "Class Is Deleted", true);
            }
            catch (Exception ex)
            {
                WebLogging.LogException(ex.Message);
                vm.AddMessage(MessageType.Error, ex.Message, "", true);
            }
            finally
            {
                vm.Classes = (await _classService.Get()).ToList();
            }

            return View("Index",vm);
        }
    }
}
