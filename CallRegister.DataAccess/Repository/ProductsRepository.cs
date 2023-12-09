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
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        private ApplicationDbContext _db;
        public ProductsRepository(ApplicationDbContext db) : base(db) //pass to base class
        { 
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Products obj)
        {
            _db.Products.Update(obj);
        }
    }
}
