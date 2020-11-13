using Crm_Core.Options;
using ModelCrm.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelCrm.Services
{
    public interface IOrderService
    {
        OrderOption  CreateOrder(CustomerOptions customer);
        OrderOption AddProductToOrder(int orderId, int productId);
        OrderOption GetOrder(int orderId);
    }
}
