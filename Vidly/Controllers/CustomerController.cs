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
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).Include(mov => mov.Movie)
                                             .SingleOrDefault(cust => cust.CustomerId == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}