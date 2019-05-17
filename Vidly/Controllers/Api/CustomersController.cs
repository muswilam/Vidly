using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Get List /Api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // Get one /Api/Customers/1
        public Customer GetCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(cust => cust.CustomerId == id);

            //check id is exist in DB
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customerInDb;
        }

        // Post Customer /Api/Customer
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            //check model is valid
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        // Update Exist Customer /Api/Customer/id
        [HttpPut]
        public void UpdateCustomer(int id , Customer customer)
        {
            //get id from DB 
            var customerInDb = _context.Customers.SingleOrDefault(cust => cust.CustomerId == id);

            //check if the id is exist or not 
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //check if model is valid
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //update items
            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _context.SaveChanges();
        }

        // Delete Customer /Api/Customer/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(cust => cust.CustomerId == id);

            // id is exist in Db
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
