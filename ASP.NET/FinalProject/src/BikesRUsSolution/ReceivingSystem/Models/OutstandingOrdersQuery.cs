using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceivingSystem.Models
{
    public class OutstandingOrdersQuery
    {
        public int PurchaseOrderID { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string VendorName { get; set; }
        public string Phone { get; set; }
        public string notes { get; set; }

        public List<OrderInfo> OutstandingOrderDetails { get; set; }

    }
}
