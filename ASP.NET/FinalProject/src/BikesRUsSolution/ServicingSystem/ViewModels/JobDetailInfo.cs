#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicingSystem.ViewModels
{
    public class JobDetailInfo
    {
        public int JobDetailId { get; set; }
        public string Description { get; set; }
        public decimal Hrs { get; set; }
        public string Comment { get; set; }

    }
}
