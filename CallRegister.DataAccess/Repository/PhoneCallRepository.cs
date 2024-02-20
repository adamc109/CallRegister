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
    public class PhoneCallRepository : Repository<PhoneCall>, IPhoneCallRepository
    {
        private ApplicationDbContext _db;
        public PhoneCallRepository(ApplicationDbContext db) : base(db) //pass to base class
        { 
            _db = db;
        }


        public void Update(PhoneCall obj)
        {
            _db.PhoneCalls.Update(obj);
        }
    }
}
