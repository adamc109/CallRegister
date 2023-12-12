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
    public class TeamsRepository : Repository<Teams>, ITeamsRepository
    {
        private ApplicationDbContext _db;
        public TeamsRepository(ApplicationDbContext db) : base(db) //pass to base class
        { 
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Teams obj)
        {
            _db.Teams.Update(obj);
        }
    }
}
