using Microsoft.AspNetCore.Mvc;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Controllers
{
    public class PermissionTypeController : Controller
    {
        private readonly ILogger<PermissionTypeController> _logger;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public PermissionTypeController(ILogger<PermissionTypeController> logger, IPermissionTypeRepository permissionTypeRepository)
        {
            _logger = logger;
            _permissionTypeRepository= permissionTypeRepository;
        }

        public IActionResult Index()
        {
            var permissionTypes = _permissionTypeRepository.GetAll();
            return View(permissionTypes);
        }
    }
}
