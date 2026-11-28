using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetCare.Constants;

namespace VetCare.Controllers
{
    [Authorize(Roles = RoleNames.Veterinarian)]
    public class VeterinarianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}