using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseVersta.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IOrderRepository Order { get; }
        public void Save();
    }
}
