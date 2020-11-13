using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
     

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        public IActionResult UpdateCustomer()
        {
            return View();
        }

        public IActionResult DeleteCustomer()
        {
            return View();
        }

        public IActionResult Customers()
        {
            ICustomerService customerService = new CustomerService();
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
