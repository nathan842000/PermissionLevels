using Microsoft.AspNetCore.Mvc;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Controllers
{
    public class ApplicationPermissionTypeDetailController : Controller
    {
        private readonly ILogger<ApplicationPermissionTypeDetailController> _logger;
        private readonly IApplicationPermissionTypeDetailRepository _applicationPermissionTypeDetailRepository;

        public ApplicationPermissionTypeDetailController(ILogger<ApplicationPermissionTypeDetailController> logger, IApplicationPermissionTypeDetailRepository applicationPermissionTypeDetailRepository)
        {
            _logger = logger;
            _applicationPermissionTypeDetailRepository = applicationPermissionTypeDetailRepository;
        }

        public IActionResult Index(int applicationPermissionTypeID = 0)
        {
            if (applicationPermissionTypeID <= 0)
                return RedirectToAction("Index", "Home");

            var applicationPermissionTypeDetails = _applicationPermissionTypeDetailRepository.GetByApplicationPermissionTypeID(applicationPermissionTypeID);
            if (applicationPermissionTypeDetails.Count <= 0)
                return View("NoRecords");

            return View(applicationPermissionTypeDetails);
        }
    }
}
