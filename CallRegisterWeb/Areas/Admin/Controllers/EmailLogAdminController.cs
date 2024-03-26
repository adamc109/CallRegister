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
    public class EmailLogAdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmailLogAdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Email> objList = _unitOfWork.EmailRepository.GetAll(includeProperties: "Products").ToList();
            return View(objList);


        }


        public IActionResult EditEmail(int? id)
        {
            EmailVM emailVM = new()
            {
                ProductList = _unitOfWork.ProductsRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Email = new Email()
            };

            emailVM.Email = _unitOfWork.EmailRepository.Get(u => u.Id == id);
            
            return View(emailVM);
        }

        [HttpPost]
        public IActionResult EditEmail(EmailVM emailVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EmailRepository.Update(emailVM.Email);
                _unitOfWork.Save();
                TempData["success"] = "Email Updated Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Email> objEmailList = _unitOfWork.EmailRepository.GetAll(includeProperties: "Products").ToList();
            return Json(new { data = objEmailList });
        }




        #endregion
    }
}
