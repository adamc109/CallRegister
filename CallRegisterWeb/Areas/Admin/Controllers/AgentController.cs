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
            List<Agent> objAgentList = _unitOfWork.AgentRepository.GetAll().ToList();

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


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Agent? agentFromDb = _unitOfWork.AgentRepository.Get(u => u.Id == id);
            if (agentFromDb == null)
            {
                return NotFound();
            }
            return View(agentFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Agent? obj = _unitOfWork.AgentRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound(id);
            }
            _unitOfWork.AgentRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Agent Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
