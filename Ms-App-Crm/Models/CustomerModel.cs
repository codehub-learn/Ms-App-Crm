using Microsoft.AspNetCore.Http;
using ModelCrm.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft_Azure_Academy.Models
{
    public class CustomerModel
    {
        public List<CustomerOptions> Customers { get; set; }
    }


    public class CustomerOptionModel
    {
        public CustomerOptions customer { get; set; }
    }

    public class CustomerWithFileModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string Phone { get; set; }
        public DateTime Dob { get; set; }

        public IFormFile Picture { get; set; }
    }

}
