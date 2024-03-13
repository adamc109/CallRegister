using CallRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.DataAccess.Repository.IRepository
{
    public interface IEmailRepository : IRepository<Email>
    {
        public void Update(Email obj);
      
    }
}
