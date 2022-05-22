using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceivingSystem.Models
{
    public class ReceivedItem
    {
        public int PurchaseOrderDetailId { get; set; }
        public int PartID { get; set; }
        public int ReceivedQty { get; set; }
        public int Return { get; set; }
        public string? Reason { get; set; }
    }
}
