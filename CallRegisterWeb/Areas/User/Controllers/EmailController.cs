using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace CallRegisterWeb.Areas.User.Controllers
{
    [Area("User")]
    public class EmailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
           return View();
        }
    }
}
