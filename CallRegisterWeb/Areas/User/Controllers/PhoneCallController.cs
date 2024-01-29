using CallRegister.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CallRegisterWeb.Areas.User.Controllers
{
    [Area("User")]
    public class PhoneCallController : Controller
    {
        //dependency injection
        private readonly IUnitOfWork _unitOfWork;
        public PhoneCallController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
