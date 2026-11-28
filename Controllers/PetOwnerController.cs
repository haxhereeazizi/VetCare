using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetCare.Constants;

namespace VetCare.Controllers
{
    [Authorize(Roles = RoleNames.PetOwner)]
    public class PetOwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}