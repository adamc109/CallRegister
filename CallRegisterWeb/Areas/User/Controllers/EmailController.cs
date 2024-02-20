using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CallRegisterWeb.Areas.User.Controllers
{
    [Area("User")]
    public class EmailController : Controller
    {
        //dependency injection
        private readonly IUnitOfWork _unitOfWork;
        public EmailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
           return View();
        }
        [HttpPost]
        public IActionResult Index(EmailVM obj)
        {
            
            return View();
        }
    }
}
