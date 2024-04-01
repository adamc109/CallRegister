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
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Products> objProductsList = _unitOfWork.ProductsRepository.GetAll().ToList();

            return View(objProductsList);
        }

        public IActionResult Upsert(int? id)
        {
             Products product = new();
            

            if (id == null || id == 0)
            {
                //create
                return View(product);
            }
            else
            {
                //update
                product = _unitOfWork.ProductsRepository.Get(u=>u.Id == id);
                return View(product);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Products obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductsRepository.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Products");
            }

            return View();
        }




        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Products> objProductsList = _unitOfWork.ProductsRepository.GetAll().ToList();
            return Json(new { data = objProductsList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var ProductsToDelete = _unitOfWork.ProductsRepository.Get(u=>u.Id == id);
            if (ProductsToDelete == null)
            {
                return Json(new { success  = false , message = "Error while deletubg"});
            }

            _unitOfWork.ProductsRepository.Remove(ProductsToDelete);
            _unitOfWork.Save();
            //TempData["success"] = "Products Deleted Successfully";


            return Json(new { success = true, message = "Delete Successful" });
        }



        #endregion
    }


}
//public IActionResult DeletePost(int? id)
//{
//    Products? obj = _unitOfWork.ProductsRepository.Get(u => u.Id == id);
//    if (obj == null)
//    {
//        return NotFound(id);
//    }
//    _unitOfWork.ProductsRepository.Remove(obj);
//    _unitOfWork.Save();
//    TempData["success"] = "Agent Deleted Successfully";
//    return RedirectToAction("Index");
//}
