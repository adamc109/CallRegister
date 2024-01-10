using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
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

        public IActionResult Create()
        {
            //converts team to select list item
            IEnumerable<SelectListItem> TeamsList = _unitOfWork.TeamsRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewData["TeamsList"] = TeamsList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Agent obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AgentRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Agent Created Successfully";
                return RedirectToAction("Index", "Agent");
            }

            return View();
        }

        public IActionResult Edit(int? id)
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
        [HttpPost]
        public IActionResult Edit(Agent obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AgentRepository.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Agent Updated Successfully";
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
