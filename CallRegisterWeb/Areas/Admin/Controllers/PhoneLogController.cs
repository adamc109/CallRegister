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

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Products? productFromDb = _unitOfWork.ProductsRepository.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Products obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductsRepository.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction("Index", "Products");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Products? agentFromDb = _unitOfWork.ProductsRepository.Get(u => u.Id == id);
            if (agentFromDb == null)
            {
                return NotFound();
            }
            return View(agentFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Products? obj = _unitOfWork.ProductsRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound(id);
            }
            _unitOfWork.ProductsRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Agent Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
