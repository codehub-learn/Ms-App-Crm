using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Crm_Core.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft_Azure_Academy.Models;
using ModelCrm.Options;
using ModelCrm.Services;
using Ms_App_Crm.Models;

namespace Microsoft_Azure_Academy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService customerService ;
        private readonly IProductService productService  ;


        public HomeController(ILogger<HomeController> logger,ICustomerService _customerService ,
           IProductService _productService  )
        {
            _logger = logger;
            customerService = _customerService;
            productService = _productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        // 

        public IActionResult Products()
        {
            List<ProductOptions> productsOpts = productService.GetAllProduct();
            ProductModel productModel = new ProductModel
            {
                 products = productsOpts
            };

            return View(productModel);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        public IActionResult UpdateCustomer()
        {
            return View();
        }

        public IActionResult UpdateCustomerWithDetails([FromRoute] int id)
        {
            CustomerOptions customerOptions = customerService.GetCustomerById(id);
            CustomerOptionModel model = new CustomerOptionModel { customer = customerOptions };

            return View(model);
        }

        public IActionResult DeleteCustomerFromView([FromRoute] int id)
        {
            customerService.DeleteCustomer(id);

            return Redirect("/Home/Customers");
        }

        public IActionResult SearchCustomer( )
        {
              return View();
        }

     
       
        public IActionResult SearchCustomersDisplay([FromQuery] string text)
        {
            List<CustomerOptions> customers = customerService.GetAllCustomers(text );
            CustomerModel customersModel = new CustomerModel
            {
                Customers = customers
            };
 
            return View("Customers", customersModel);

        }


        public IActionResult DeleteCustomer()
        {
            return View();
        }

        public IActionResult Customers()
        {
            
            List<CustomerOptions> customers = customerService.GetAllCustomers();
            CustomerModel customersModel = new CustomerModel { 
                Customers= customers 
            };
            return View(customersModel);
        }


        public IActionResult Info()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
