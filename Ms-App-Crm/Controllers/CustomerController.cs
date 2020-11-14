using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCrm.Models;
using ModelCrm.Options;
using ModelCrm.Services;

namespace Microsoft_Azure_Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService = new CustomerService();

        [HttpPost]
        public CustomerOptions AddCustomer(CustomerOptions customerOpt)
        {
             CustomerOptions customerOptions = customerService.CreateCustomer(customerOpt);
            return customerOptions;
        }



        [HttpPut("{id}")]
        public CustomerOptions UpdateCustomer(int id, CustomerOptions customerOpt)
        {
            return customerService.UpdateCustomer(customerOpt, id);

        }
        [HttpDelete("{id}")]
        public bool DeleteCustomer(int id)
        {
            return customerService.DeleteCustomer(id);
        }
    }
}
