using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ms_App_Crm.Models
{

    public class AnOrderModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public  DateTime Date { get; set; }
    }

    public class AllOrdersModel
    {
        public List<AnOrderModel> orders { get; set; }
    }
}
