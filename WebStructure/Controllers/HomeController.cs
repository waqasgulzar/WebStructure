using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Web.Common.Constant;
using WebStructure.Admin.Controllers.Base;
using WebStructure.Models;

namespace WebStructure.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;

        }
        [HttpPost]
        public async Task<IActionResult> AddRole([Required] string name)
        {
            if (ModelState.IsValid)
            {
                var Roles = await _roleManager.RoleExistsAsync(name);
                if (!Roles)
                {
                    IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                    if (result.Succeeded)
                        return RedirectToAction(nameof(Index));
                }
            }
            return View(name);
        }
        [Authorize(Roles = IdentityConstant.Admin)]
        public IActionResult AddRole()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
