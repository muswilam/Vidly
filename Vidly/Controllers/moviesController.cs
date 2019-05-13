using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Custom_ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class moviesController : Controller
    {
        private ApplicationDbContext _context;

        public moviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(cust => cust.CustomerId == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { CustomerId = 1 , Name = "Jack David"},
        //        new Customer { CustomerId = 2 , Name = "Mary William"}
        //    };
        //}
    }
}