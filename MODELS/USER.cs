using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.MODELS
{
    public class USER
    {
        public string Flag { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserMobile { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
