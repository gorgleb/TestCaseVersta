using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestCaseVersta.Data;
using TestCaseVersta.Data.Repository;
using TestCaseVersta.Data.Repository.IRepository;
using TestCaseVersta.Models;

namespace TestCaseVersta.Data.Repository;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private ApplicationDbContext _db;
    public OrderRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Order obj)
    {
        _db.Orders.Update(obj);
        var objFromDb = _db.Orders.FirstOrDefault(u => u.Id == obj.Id);
        if (objFromDb != null)
        {
            objFromDb.Number = obj.Number;
            objFromDb.SendersCity = obj.SendersCity;
            objFromDb.SendersAdress = obj.SendersAdress;
            objFromDb.RecipientsCity = obj.RecipientsCity;
            objFromDb.CargoWeight = obj.CargoWeight;
            objFromDb.PickupDate = obj.PickupDate;
        }
    }
}