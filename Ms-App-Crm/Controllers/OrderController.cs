using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm_Core.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCrm.Options;
using ModelCrm.Services;

namespace CrmWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        public IOrderService orderService = new OrderService();

        [HttpGet("{id}")]
        public OrderOption getOrder(int id)
        {
            return orderService.GetOrder(id);
        }

        [HttpPost]
        public OrderOption createOrder(CustomerOptions customerOpt)
        {
            return orderService.CreateOrder(customerOpt);
        }

        [HttpPost("{ordedId}/product/{productId}")]
        public OrderOption AddProductToOrder(int ordedId, int productId)
        {
            return orderService.AddProductToOrder(ordedId, productId);
        }

    }
}
