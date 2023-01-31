using Microsoft.AspNetCore.Mvc;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ILogger<CompanyController> logger, ICompanyRepository companyRepository)
        {
            _logger = logger;
            _companyRepository = companyRepository;
        }

        public IActionResult Index()
        {
            var companies = _companyRepository.GetAll();
            return View(companies);
        }
    }
}
