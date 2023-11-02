using CallRegisterWeb.Data;
using CallRegisterWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CallRegisterWeb.Controllers
{
    public class AgentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AgentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Agent> objAgentList = _db.Agents.ToList();
            return View(objAgentList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
