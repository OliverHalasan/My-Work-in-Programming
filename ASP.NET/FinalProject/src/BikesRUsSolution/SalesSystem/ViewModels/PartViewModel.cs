using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.ViewModels
{
    public class PartViewModel
    {
        public int PartID { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
