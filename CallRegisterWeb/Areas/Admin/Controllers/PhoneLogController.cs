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
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class PhoneLogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhoneLogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<PhoneCall> objProductsList = _unitOfWork.PhoneCallRepository.GetAll(includeProperties: "Products").ToList();
            return View(objProductsList);


        }

        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Products obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.ProductsRepository.Add(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product Created Successfully";
        //        return RedirectToAction("Index", "Products");
        //    }

        //    return View();
        //}

        public IActionResult EditPhone(int? id)
        {
            PhoneCallVM phoneCallVM = new()
            {
                ProductList = _unitOfWork.ProductsRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                PhoneCall = new PhoneCall()
            };

            phoneCallVM.PhoneCall = _unitOfWork.PhoneCallRepository.Get(u => u.Id == id);
            
            return View(phoneCallVM);
        }

        [HttpPost]
        public IActionResult EditPhone(PhoneCallVM phoneCallVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PhoneCallRepository.Update(phoneCallVM.PhoneCall);
                _unitOfWork.Save();                
                return RedirectToAction("Index");
            }

            return View();
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
