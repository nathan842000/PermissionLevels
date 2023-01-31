using Microsoft.AspNetCore.Mvc;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationController(ILogger<ApplicationController> logger, IApplicationRepository applicationRepository)
        {
            _logger = logger;
            _applicationRepository = applicationRepository;
        }

        public IActionResult Index()
        {
            var applications = _applicationRepository.GetAll();
            return View(applications);
        }
    }
}
