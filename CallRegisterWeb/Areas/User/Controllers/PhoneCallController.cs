using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CallRegisterWeb.Areas.User.Controllers
{
    [Area("User")]
    public class PhoneCallController : Controller
    {
        //dependency injection
        private readonly IUnitOfWork _unitOfWork;
        public PhoneCallController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            PhoneCallVM phoneVM = new()
            {
                ProductList = _unitOfWork.ProductsRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),                         
        };
          

            return View(phoneVM);
        }
        [HttpPost]
        public IActionResult Index(PhoneCallVM obj) 
        {

            obj.PhoneCall.AllocatedDate = DateTime.Now;
            obj.PhoneCall.DateDue = DateTime.Now.AddDays(3);
            obj.PhoneCall.DateCompleted = DateTime.Now.AddDays(3);
            //add completed date
            if (ModelState.IsValid)
            {
                _unitOfWork.PhoneCallRepository.Add(obj.PhoneCall);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

//public IActionResult Upsert(int? id)
//{
//    AgentVM agentVM = new()
//    {
//        TeamsList = _unitOfWork.TeamsRepository.GetAll().Select(u => new SelectListItem
//        {
//            Text = u.Name,
//            Value = u.Id.ToString()
//        }),
//        Agent = new Agent()
//    };

//    if (id == null || id == 0)
//    {
//        //create
//        return View(agentVM);
//    }
//    else
//    {
//        //update
//        agentVM.Agent = _unitOfWork.AgentRepository.Get(u => u.Id == id);
//        return View(agentVM);
//    }