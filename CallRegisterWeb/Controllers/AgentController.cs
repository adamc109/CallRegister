using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegisterWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CallRegisterWeb.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentRepository _agentRepo;
        public AgentController(IAgentRepository db)
        {
            _agentRepo = db;
        }
        public IActionResult Index()
        {
            List<Agent> objAgentList = _agentRepo.GetAll().ToList();
            return View(objAgentList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Agent obj)
        {
            if (ModelState.IsValid)
            {
                _agentRepo.Add(obj);
                _agentRepo.Save();
                TempData["success"] = "Agent Created Successfully";
                return RedirectToAction("Index", "Agent");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }

            Agent? agentFromDb = _agentRepo.Get(u=>u.Id==id);
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
                _agentRepo.Update(obj);
                _agentRepo.Save();
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

            Agent? agentFromDb = _agentRepo.Get(u => u.Id == id);
            if (agentFromDb == null)
            {
                return NotFound();
            }
            return View(agentFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Agent? obj = _agentRepo.Get(u => u.Id == id); 
            if (obj == null)
            {
                return NotFound(id);
            }
            _agentRepo.Remove(obj);
            _agentRepo.Save();
            TempData["success"] = "Agent Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
