using CallRegisterWeb.Data;
using CallRegisterWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CallRegisterWeb.Controllers
{
    public class EmailController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmailController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            List<Agent> objAgentList = _db.Agents.ToList();
            return View(objAgentList);
        }
    }
}
