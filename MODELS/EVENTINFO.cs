using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.MODELS
{
    public class EVENTINFO
    {
        public string Flag { get; set; }
        public long EventId { get; set; }
        public string EventName { get; set; }
        public string EventDESC { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventImgPath { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public long AdminId { get; set; }
    }
}
