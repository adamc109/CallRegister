using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Models.ViewModels;
using CallRegister.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace CallRegisterWeb.Areas.User.Controllers
{
    [Area("User")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompleteUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompleteUserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Agent> objAgentsList = _unitOfWork.AgentRepository.GetAll().ToList();
            return View(objAgentsList);

        }
 
        public IActionResult Edit(string? id)
        {
            List<PhoneCall> callsFromDb = _unitOfWork.PhoneCallRepository.GetIncomplete(u => u.Agent == id && u.Complete == false, includeProperties: "Products").ToList();
            if (callsFromDb == null)
            {
                return NotFound();
            }
            return View(callsFromDb);
            //Viewdata for reirect?
        }

        public IActionResult UpdateComplete(int? objid)
        {
            PhoneCall phoneCall = _unitOfWork.PhoneCallRepository.Get(u => u.Id == objid);
            phoneCall.Complete = true;
            phoneCall.DateCompleted = DateTime.Now;
            _unitOfWork.PhoneCallRepository.Update(phoneCall);
            TempData["success"] = "Phone Call Completed Successfully";
            _unitOfWork.Save();

            return RedirectToAction(actionName: "Index");
        }
    }
}




