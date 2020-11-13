using System;
using System.Collections.Generic;
using System.Text;

namespace Crm_Core.Options
{
    public class OrderOption
    {
        public string CustomerName { get; set; }
        public int OrderId { get; set; }
        public List<int> Products { get; set; }
    }
}
