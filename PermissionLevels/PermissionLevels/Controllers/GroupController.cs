using Microsoft.AspNetCore.Mvc;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Controllers
{
    public class GroupController : Controller
    {
        private readonly ILogger<GroupController> _logger;
        private readonly IGroupRepository _groupRepository;

        public GroupController(ILogger<GroupController> logger, IGroupRepository groupRepository)
        {
            _logger = logger;
            _groupRepository = groupRepository;
        }

        public IActionResult Index()
        {
            var groups = _groupRepository.GetAll();
            return View(groups);
        }
    }
}
