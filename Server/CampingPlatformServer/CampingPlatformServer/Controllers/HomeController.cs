using CampingPlatformServer.Model;
using Microsoft.AspNetCore.Mvc;

namespace CampingPlatformServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly CampingPlatformContext _context;

        public HomeController(CampingPlatformContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
