using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Models.ViewModels;
using CallRegister.Utility;
using CallRegisterWeb.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace CallRegisterWeb.Areas.Admin.Controllers
{
    [Area("User")]
    public class PhoneLogUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhoneLogUserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult PhoneLogUserIndex()
        {
            List<PhoneCall> objProductsList = _unitOfWork.PhoneCallRepository.GetAll(includeProperties: "Products").ToList();
            return View(objProductsList);


        }




        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<PhoneCall> objPhoneList = _unitOfWork.PhoneCallRepository.GetAll(includeProperties: "Products").ToList();
            return Json(new { data = objPhoneList });
        }




        #endregion
    }
}
