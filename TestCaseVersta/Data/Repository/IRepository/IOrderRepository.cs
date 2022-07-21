using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseVersta.Models;

namespace TestCaseVersta.Data.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order obj);
    }
}
