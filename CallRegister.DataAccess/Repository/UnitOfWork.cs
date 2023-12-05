﻿using CallRegister.DataAccess.Repository.IRepository;
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
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AgentRepository = new AgentRepository(_db);
        }


        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
