using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchasingSystem.ViewModels
{
    public class PurchaseInfo
    {
        public int PurchaseOrderID { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount
        {
            get
            {
                return SubTotal * (decimal)0.05;
            }
        }
        public decimal Total
        {
            get
            {
                return SubTotal + TaxAmount;
            }
        }

    }
}
