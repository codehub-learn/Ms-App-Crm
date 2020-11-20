using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm_Core.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelCrm.Models;
using ModelCrm.Services;
using Ms_App_Crm.Models;

namespace Ms_App_Crm.Controllers
{


    public class CartController : Controller
    {

        private readonly ILogger<CartController> _logger;
        private readonly ICustomerService customerService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public CartController(ILogger<CartController> logger, ICustomerService _customerService,
           IProductService _productService, IOrderService _orderService)
        {
            _logger = logger;
            customerService = _customerService;
            productService = _productService;
            orderService = _orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateOrder()
        {
            int customerId = 15;

            OrderOption orderOption = orderService.CreateOrder(customerId);

            int orderId = orderOption.OrderId;

            List<ProductOptions> productsOpts = productService.GetAllProduct();
            OrderModel productModel = new OrderModel
            {
                products = productsOpts,
                orderId = orderId
            };
            return View(productModel);
        }
         
        public IActionResult ViewOrders()
        {

            AllOrdersModel allOrdersModel = new AllOrdersModel();
           //to do
           //get all orders from order service

            return View(allOrdersModel);
        }


    }
}
