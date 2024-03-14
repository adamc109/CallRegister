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
    public class CompleteEmailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompleteEmailController(IUnitOfWork unitOfWork)
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
            List<Email> callsFromDb = _unitOfWork.EmailRepository.GetIncomplete(u => u.Agent == id && u.Complete == false, includeProperties: "Products").ToList();
            if (callsFromDb == null)
            {
                return NotFound();
            }
            return View(callsFromDb);
            //Viewdata for reirect?
        }

        public IActionResult UpdateComplete(int? objid)
        {
            Email email = _unitOfWork.EmailRepository.Get(u => u.Id == objid);
            email.Complete = true;
            email.DateCompleted = DateTime.Now;
            _unitOfWork.EmailRepository.Update(email);
            _unitOfWork.Save();

            return RedirectToAction(actionName: "Index");
        }
    }
}




