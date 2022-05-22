using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceivingSystem.Models
{
    public class OrderInfo
    {
        public int PurchaseOrderDetailId { get; set; } 
        public int PartID { get; set; }
        public string Description { get; set; }
        public int OriginalQty { get; set; }
        public int OutstandingQty { get; set; }
    }
}
