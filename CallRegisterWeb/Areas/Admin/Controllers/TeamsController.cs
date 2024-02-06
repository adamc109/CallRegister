using CallRegister.DataAccess.Repository;
using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Utility;
using CallRegisterWeb.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CallRegisterWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class TeamsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeamsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Teams> objTeamsList = _unitOfWork.TeamsRepository.GetAll().ToList();
            return View(objTeamsList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Teams obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TeamsRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index", "Teams");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Teams? productFromDb = _unitOfWork.TeamsRepository.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Teams obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TeamsRepository.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction("Index", "Teams");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Teams? agentFromDb = _unitOfWork.TeamsRepository.Get(u => u.Id == id);
            if (agentFromDb == null)
            {
                return NotFound();
            }
            return View(agentFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Teams? obj = _unitOfWork.TeamsRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound(id);
            }
            _unitOfWork.TeamsRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Agent Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
