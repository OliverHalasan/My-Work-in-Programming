#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicingSystem.ViewModels
{
    public class JobInfo
    {
        public int JobId { get; set; }
        public List<JobDetailInfo> JobDetailItems { get; set; }
    }
}
