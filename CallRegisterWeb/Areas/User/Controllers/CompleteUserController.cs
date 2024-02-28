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
        //    public IActionResult Edit(string? id)
        //    {
        //        r
        public IActionResult Edit(string? id)
        {
            //if (id == null || id == 0)
            //{
            //    return NotFound();
            //}

            List<PhoneCall> callsFromDb = _unitOfWork.PhoneCallRepository.GetIncomplete(u => u.Agent == id && u.Complete == false, includeProperties: "Products").ToList();
            if (callsFromDb == null)
            {
                return NotFound();
            }
            return View(callsFromDb);
        }

        //public IActionResult UpdateComplete(string? objId)
        //{
        //    //if (ModelState.IsValid)
        //    //{
       
        //    //phoneCall.Complete = true;
        //    //_unitOfWork.PhoneCallRepository.Update(phoneCall);
        //    //_unitOfWork.Save();
        //    //    //TempData["success"] = "Product Updated Successfully";
        //    //    return RedirectToAction("Index", "Products");
        //    //}
        //    return View();
        //}
        public IActionResult UpdateComplete(int? objid)
        {
            PhoneCall phoneCall = _unitOfWork.PhoneCallRepository.Get(u => u.Id == objid);
            phoneCall.Complete = true;
            _unitOfWork.PhoneCallRepository.Update(phoneCall);
            _unitOfWork.Save();

            return View();
        }
    }
}




