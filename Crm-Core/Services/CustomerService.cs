﻿using ModelCrm.CrmDbContext;
using ModelCrm.Models;
using ModelCrm.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCrm.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CrmAppDbContext dbContext;

        public CustomerService(CrmAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public CustomerOptions CreateCustomer(CustomerOptions customerOptions)
        {
            //validation

            Customer customer = new Customer  { 
                FirstName = customerOptions.FirstName,
                LastName = customerOptions.LastName,
                Phone = customerOptions.Phone,
                Email= customerOptions.Email,
                VatNumber= customerOptions.VatNumber,
                Address =customerOptions.Address,
                Dob = customerOptions.Dob,
                CreatedDate = DateTime.Now,
                IsActive = true,
                TotalGross =0m
            };
            
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            return new CustomerOptions
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                VatNumber = customer.VatNumber,
                Address = customer.Address,
                Dob = customer.Dob,
            };
        }

        public List<CustomerOptions> GetAllCustomers()
        {
            using CrmAppDbContext dbContext = new CrmAppDbContext();
            List<Customer> customers = dbContext.Customers.ToList();
            List<CustomerOptions> customersOpt = new List<CustomerOptions>();
            customers.ForEach(customer => customersOpt.Add(new CustomerOptions
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                VatNumber = customer.VatNumber,
                Address = customer.Address,
                Dob = customer.Dob,
                Id = customer.Id +""
            }));

            return customersOpt;
        }

        public CustomerOptions UpdateCustomer(CustomerOptions customerOpt, int id)
        {

            Customer customer = dbContext.Customers.Find(id);
            customerOptToCustomer(customerOpt, customer);
            dbContext.SaveChanges();

            return new CustomerOptions
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                VatNumber = customer.VatNumber,
                Address = customer.Address,
                Dob = customer.Dob,
            };
        }

        private static void customerOptToCustomer(CustomerOptions customerOpt, Customer customer)
        {
            customer.FirstName = customerOpt.FirstName;
            customer.LastName = customerOpt.LastName;
            customer.Dob = customerOpt.Dob;
            customer.VatNumber = customerOpt.VatNumber;
            customer.Address = customerOpt.Address;
            customer.Email = customerOpt.Email;
        }

        public bool DeleteCustomer(int id)
        {
             Customer customer = dbContext.Customers.Find(id);
            if (customer == null) return false;
            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
            return true;

        }

        public CustomerOptions GetCustomerById(int id)
        {
             Customer customer = dbContext.Customers.Find(id);
            return new CustomerOptions
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                VatNumber = customer.VatNumber,
                Address = customer.Address,
                Dob = customer.Dob,
                Id = customer.Id + ""
            };
        }

        public List<CustomerOptions> GetAllCustomers(string searchCriteria)
        {
            using CrmAppDbContext dbContext = new CrmAppDbContext();
            List<Customer> customers = dbContext.Customers
                .Where( customer => customer.FirstName.Contains(searchCriteria)
                || customer.LastName.Contains(searchCriteria)
                )
                .ToList();

            List<CustomerOptions> customersOpt = new List<CustomerOptions>();
            customers.ForEach(customer => customersOpt.Add(new CustomerOptions
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                VatNumber = customer.VatNumber,
                Address = customer.Address,
                Dob = customer.Dob,
                Id = customer.Id + ""
            }));

            return customersOpt;
        }
    }
}
