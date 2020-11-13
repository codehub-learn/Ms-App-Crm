using Crm_Core.Options;
using Microsoft.EntityFrameworkCore;
using ModelCrm.CrmDbContext;
using ModelCrm.Models;
using ModelCrm.Options;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ModelCrm.Services
{
    public class OrderService : IOrderService
    {
        private readonly CrmAppDbContext dbContext = new CrmAppDbContext();

        public OrderOption CreateOrder(CustomerOptions customerOpt)
        {
            if (customerOpt == null) return null;
            Customer customer = dbContext.Customers.Find(customerOpt.Id);
            if (customer == null) return null;
            Order order = new Order { Customer = customer };
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            OrderOption orderOption = new OrderOption
            {
                CustomerName = customer.FirstName + " " + customer.LastName,
                OrderId = order.Id
            };
            return orderOption;
        }

        public OrderOption GetOrder(int orderId)
        {
            Order order = dbContext.Orders.Include(o => o.Customer).FirstOrDefault(x => x.Id == orderId);
            Customer customer = dbContext.Customers.Find(order.Customer.Id);

            List<int> products = new List<int>();
            List<OrderProduct> orderProducts = dbContext.OrderProducts
                .Include(op => op.Product)
                .Where(op => op.Order.Equals(order)).ToList();

            orderProducts.ForEach(op => products.Add(op.Product.Id));

            OrderOption orderOption = new OrderOption
            {
                CustomerName = customer.FirstName + " " + customer.LastName,
                OrderId = order.Id,
                Products = products
            };

            return orderOption;
        }

        public OrderOption AddProductToOrder(int orderId, int productId)
        {
            Order order = dbContext.Orders.Find(orderId);
            Product product = dbContext.Products.Find(productId);
            OrderProduct orderProduct = new OrderProduct
            {
                Order = order,
                Product = product
            };
            dbContext.OrderProducts.Add(orderProduct);
            dbContext.SaveChanges();
            return GetOrder(orderId);
        }
    }
}
