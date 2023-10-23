using Microsoft.AspNetCore.Mvc;

namespace CallRegisterWeb.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
