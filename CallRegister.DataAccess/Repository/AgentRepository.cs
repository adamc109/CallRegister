using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegisterWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.DataAccess.Repository
{
    public class AgentRepository : Repository<Agent>, IAgentRepository
    {
        private ApplicationDbContext _db;
        public AgentRepository(ApplicationDbContext db) : base(db) //pass to base class
        { 
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Agent obj)
        {
            _db.Agents.Update(obj);
        }
    }
}
