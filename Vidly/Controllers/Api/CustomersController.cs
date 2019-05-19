using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

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
        public IHttpActionResult GetCustomers()
        {
            var Customers = _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(Customers);
        }

        // Get one /Api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(cust => cust.CustomerId == id);

            //check id is exist in DB
            if (customerInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerInDb));
        }

        // Post Customer /Api/Customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            //check model is valid
            if (!ModelState.IsValid)
                return BadRequest("Something Went Wrong");

            var customer =  Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.CustomerId = customer.CustomerId;

            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customerDto);
        }

        // Update Exist Customer /Api/Customer/id
        [HttpPut]
        public void UpdateCustomer(int id , CustomerDto customerDto)
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
            // Mapper.Map(customerDto, customerInDb); 
            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb); //same thing

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
