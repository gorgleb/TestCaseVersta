using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCaseVersta.Data;
using TestCaseVersta.Data.Repository.IRepository;
using TestCaseVersta.Models;

namespace TestCaseVersta.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Upsert(int? id)
        {
            Order order = new Order();  
            if (id == 0 || id == null)
            {

                return View(order);
            }
            else
            {
                order = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);
                return View(order);
            }


        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Order obj)
        {

            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                    _unitOfWork.Order.Add(obj);
                    TempData["success"] = "Product  created sucessfully";
                }
                else
                {
                    _unitOfWork.Order.Update(obj);
                    TempData["success"] = "Product  updated sucessfully";
                }
                _unitOfWork.Save();
                return RedirectPermanent("/Home/Index");
            }
            return View(obj);

        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var orderFromDbFirst = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);
            if (orderFromDbFirst == null)
            {
                return NotFound();
            }
            return View(orderFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Order.Remove(obj);
            _unitOfWork.Save();
            return RedirectPermanent("/Home/Index");


        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {

            IEnumerable<Order> orders;

            orders = _unitOfWork.Order.GetAll();




            return new JsonResult(new { data = orders });
        }
        #endregion
    }
}
