using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CallRegisterWeb.Areas.User.Controllers
{
    [Area("User")]
    public class EmailController : Controller
    {
        //dependency injection
        private readonly IUnitOfWork _unitOfWork;
        public EmailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult AddEmail()
        {
            EmailVM emailVM = new()
            {
                ProductList = _unitOfWork.ProductsRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
            };


            return View(emailVM);
        }
        [HttpPost]
        public IActionResult AddEmail(EmailVM obj)
        {

            obj.Email.AllocatedDate = DateTime.Now;
            obj.Email.DateDue = DateTime.Now.AddDays(3);
            if (ModelState.IsValid)
            {
                _unitOfWork.EmailRepository.Add(obj.Email);
                _unitOfWork.Save();
                TempData["success"] = "Email Created Successfully";
                return RedirectToAction("AddEmail");
            }

            return RedirectToAction("AddEmail");
        }
    }
}