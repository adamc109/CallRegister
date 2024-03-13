using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Models.ViewModels;
using CallRegister.Utility;
using CallRegisterWeb.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CallRegisterWeb.Areas.Admin.Controllers
{
    [Area("User")]
    public class EmailLogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmailLogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult EmailLog()
        {
            List<Email> objProductsList = _unitOfWork.EmailRepository.GetAll(includeProperties: "Products").ToList();
            return View(objProductsList);


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
