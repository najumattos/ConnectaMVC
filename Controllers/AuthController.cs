using Microsoft.AspNetCore.Mvc;

namespace ConnectaMVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
