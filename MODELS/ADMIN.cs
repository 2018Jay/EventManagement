using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.MODELS
{
    public class ADMIN
    {
        public string Flag { get; set; }
        public long AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminAddress { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string AdminMobile { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

    }
}
