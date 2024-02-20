using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Utility;
using CallRegisterWeb.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallRegisterWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class OverdueController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OverdueController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult OverDuePhone() 
        {
            List<PhoneCall> objOverdueCalls = _unitOfWork.PhoneCallRepository.GetAll(includeProperties: "Products").ToList();
            return View(objOverdueCalls); 
        }

    }
}
