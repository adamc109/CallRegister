using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegister.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAgentRepository AgentRepository { get; }
        IProductsRepository ProductsRepository { get; }

        void Save();
    }
}
