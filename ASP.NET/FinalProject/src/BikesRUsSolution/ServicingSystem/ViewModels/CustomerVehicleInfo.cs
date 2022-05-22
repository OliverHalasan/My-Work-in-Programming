#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicingSystem.ViewModels
{
    public class CustomerVehicleInfo
    {
        public int CustomerId { get; set; }
        public string VehicleIdentification { get; set; }

        public string Vehicle { get; set; }
        public string CustomerName { get; set; }
    }
}
