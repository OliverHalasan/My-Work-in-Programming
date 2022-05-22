using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchasingSystem.ViewModels
{
    public class PartsInfo
    {
        public int PartID { get; set; }
        public string Description { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }
        public int QuantityOnOrder { get; set; }
        public int QuantityToOrder { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Name
        {
            get
            {
                return Description;
            }
        }
    }
}
