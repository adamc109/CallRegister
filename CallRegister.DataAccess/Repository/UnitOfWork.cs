using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegisterWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IAgentRepository AgentRepository { get; private set; }
        public IProductsRepository ProductsRepository { get; private set; }
        public ITeamsRepository TeamsRepository { get; private set; }
        public IPhoneCallRepository PhoneCallRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AgentRepository = new AgentRepository(_db);
            ProductsRepository = new ProductsRepository(_db);
            TeamsRepository = new TeamsRepository(_db);
            PhoneCallRepository = new PhoneCallRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
