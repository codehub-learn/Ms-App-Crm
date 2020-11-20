using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft_Azure_Academy.Models;
using ModelCrm.Models;
using ModelCrm.Options;
using ModelCrm.Services;

namespace Microsoft_Azure_Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IWebHostEnvironment hostingEnvironment;


        public CustomerController(ICustomerService customerService, IWebHostEnvironment environment)
        {
            this.customerService = customerService;
            hostingEnvironment = environment;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }



        [HttpPost]
        public CustomerOptions AddCustomer([FromForm] CustomerWithFileModel customerOptWithFileModel)
        {

            if (customerOptWithFileModel == null) return null;
            var formFile = customerOptWithFileModel.Picture  ;

            var filename = customerOptWithFileModel.Picture.FileName;

            if (formFile.Length > 0)
            {
        
                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploadedimages", filename);


                using (var stream = System.IO.File.Create(filePath))
                {
                      formFile.CopyTo(stream);
                }
            }

            CustomerOptions customerOpt = new CustomerOptions {  FirstName = customerOptWithFileModel.FirstName, 
            LastName= customerOptWithFileModel.LastName,
             Address = customerOptWithFileModel.Address,
              Dob = customerOptWithFileModel.Dob, Email = customerOptWithFileModel.Email, 
                Phone= customerOptWithFileModel.Phone, VatNumber= customerOptWithFileModel.VatNumber
            };

            /// we save the picture path in the Phone field
            customerOpt.Phone = filename;

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
