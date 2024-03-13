using CallRegister.DataAccess.Repository.IRepository;
using CallRegister.Models;
using CallRegisterWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.DataAccess.Repository
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        private ApplicationDbContext _db;
        public EmailRepository(ApplicationDbContext db) : base(db) //pass to base class
        { 
            _db = db;
        }


        public void Update(Email obj)
        {
            _db.Emails.Update(obj);
        }
    }
}


