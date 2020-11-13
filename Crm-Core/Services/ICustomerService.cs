using ModelCrm.Models;
using ModelCrm.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelCrm.Services
{
   public interface ICustomerService
    {
        CustomerOptions CreateCustomer(CustomerOptions customerOptions);
        CustomerOptions GetCustomerById(int id);
        List<CustomerOptions> GetAllCustomers();
        CustomerOptions UpdateCustomer(CustomerOptions customerOpt, int id);
        bool DeleteCustomer(int id);

    }


}
