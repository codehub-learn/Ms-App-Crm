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
        OrderOption CreateOrder(int customerId);
        OrderOption AddProductToOrder(int orderId, int productId);
        OrderOption GetOrder(int orderId);
    }
}
