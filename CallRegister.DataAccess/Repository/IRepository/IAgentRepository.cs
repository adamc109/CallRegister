using CallRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.DataAccess.Repository.IRepository
{
    public interface IAgentRepository : IRepository<Agent>
    {
        void Update(Agent obj);
        void Save();
    }
}
