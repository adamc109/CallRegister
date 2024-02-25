using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegister.Models.ViewModels;
using CallRegister.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CallRegisterWeb.Areas.User.Controllers
{
    [Area("Admin")]

    public class CompleteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompleteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Agent> objAgentsList = _unitOfWork.AgentRepository.GetAll().ToList();
            return View(objAgentsList);

        }
        //    public IActionResult Edit(string? id)
        //    {
        //        r
        public IActionResult Edit(string? id)
        {
            //if (id == null || id == 0)
            //{
            //    return NotFound();
            //}

            Agent? productFromDb = _unitOfWork.AgentRepository.Get(u => u.Name == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
    }
}


    

