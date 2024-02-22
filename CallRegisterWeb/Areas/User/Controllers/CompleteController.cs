using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallRegisterWeb.Areas.User.Controllers
{
    [Area("User")]
    
    public class CompleteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CompletePhone()
        {
            List<PhoneCall> objOverdueCalls = _unitOfWork.PhoneCallRepository.GetAll(includeProperties: "Products").ToList();
            return View(objOverdueCalls);
        }

    }
}
