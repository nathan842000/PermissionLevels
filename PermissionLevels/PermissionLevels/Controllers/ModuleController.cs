using Microsoft.AspNetCore.Mvc;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Controllers
{
    public class ModuleController : Controller
    {
        private readonly ILogger<ModuleController> _logger;
        private readonly IModuleRepository _moduleRepository;

        public ModuleController(ILogger<ModuleController> logger, IModuleRepository moduleRepository)
        {
            _logger = logger;
            _moduleRepository = moduleRepository;
        }

        public IActionResult Index()
        {
            var modules = _moduleRepository.GetAll();
            return View(modules);
        }
    }
}
