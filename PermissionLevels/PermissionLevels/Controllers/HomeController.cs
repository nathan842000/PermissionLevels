using Microsoft.AspNetCore.Mvc;
using PermissionLevels.Models;
using PermissionLevels.Repositories.Interfaces;
using System.Diagnostics;

namespace PermissionLevels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationPermissionTypeRepository _applicationPermissionTypeRepository;

        public HomeController(ILogger<HomeController> logger, IApplicationPermissionTypeRepository applicationPermissionTypeRepository)
        {
            _logger = logger;
            _applicationPermissionTypeRepository = applicationPermissionTypeRepository;
        }

        public IActionResult Index()
        {
            var applicationPermissionTypes = _applicationPermissionTypeRepository.GetAll();
            return View(applicationPermissionTypes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}