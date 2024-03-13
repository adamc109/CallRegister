using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Utility;
using CallRegisterWeb.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            //IEnumerable<PhoneCall> objOverdueCalls = _unitOfWork.PhoneCallRepository.GetIncomplete();
            //return View(objOverdueCalls); 
            List<PhoneCall> overdue = _unitOfWork.PhoneCallRepository.GetIncomplete(x => x.Complete == false && DateTime.Now > x.DateDue, includeProperties: "Products").ToList();
            return View(overdue);

        }

        public IActionResult OverDueEmail()
        {
            //IEnumerable<PhoneCall> objOverdueCalls = _unitOfWork.PhoneCallRepository.GetIncomplete();
            //return View(objOverdueCalls); 
            List<Email> overdueEmail = _unitOfWork.EmailRepository.GetIncomplete(x => x.Complete == false && DateTime.Now > x.DateDue, includeProperties: "Products").ToList();
            return View(overdueEmail);

        }

    }
}
