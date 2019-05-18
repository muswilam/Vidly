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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        // Get one /Api/Customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(cust => cust.CustomerId == id);

            //check id is exist in DB
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customerInDb);
        }

        // Post Customer /Api/Customer
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            //check model is valid
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer =  Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.CustomerId = customer.CustomerId;

            return customerDto;
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
