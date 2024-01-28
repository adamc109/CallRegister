using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Models.ViewModels;
using CallRegisterWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace CallRegisterWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AgentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Agent> objAgentList = _unitOfWork.AgentRepository.GetAll(includeProperties: "Teams").ToList();

            return View(objAgentList);
        }

        public IActionResult Upsert(int? id)
        {
            AgentVM agentVM = new()
            {
                TeamsList = _unitOfWork.TeamsRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                 Agent = new Agent()
            };

            if (id == null || id == 0)
            {
                //create
                return View(agentVM);
            }
            else
            {
                //update
                agentVM.Agent = _unitOfWork.AgentRepository.Get(u=>u.Id == id);
                return View(agentVM);
            }

        }
        [HttpPost]
        public IActionResult Upsert(AgentVM agentVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AgentRepository.Add(agentVM.Agent);
                _unitOfWork.Save();
                TempData["success"] = "Agent Created Successfully";
                return RedirectToAction("Index", "Agent");
            }

            return View();
        }




        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Agent> objAgentList = _unitOfWork.AgentRepository.GetAll(includeProperties: "Teams").ToList();
            return Json(new { data = objAgentList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var agentToDelete = _unitOfWork.AgentRepository.Get(u=>u.Id == id);
            if (agentToDelete == null)
            {
                return Json(new { success  = false , message = "Error while deletubg"});
            }

            _unitOfWork.AgentRepository.Remove(agentToDelete);
            _unitOfWork.Save();
            //TempData["success"] = "Agent Deleted Successfully";


            return Json(new { success = true, message = "Delete Successful" });
        }



        #endregion
    }


}
