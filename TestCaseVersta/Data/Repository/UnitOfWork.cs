using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseVersta.Data;
using TestCaseVersta.Data.Repository.IRepository;

namespace TestCaseVersta.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Order = new OrderRepository(_db);
        }

        public IOrderRepository Order { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
