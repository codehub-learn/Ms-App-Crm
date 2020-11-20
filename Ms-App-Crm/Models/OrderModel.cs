using Crm_Core.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ms_App_Crm.Models
{
    public class OrderModel
    {
        public List<ProductOptions> products { get; set; }
        public int orderId { get; set; }
    }
}
