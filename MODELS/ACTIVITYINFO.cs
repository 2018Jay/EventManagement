using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.MODELS
{
    public class ACTIVITYINFO
    {


        public long ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDESC { get; set; }
        public DateTime ActivityStartDateTime { get; set; }
        public DateTime ActivityEndDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool EventId { get; set; }
    }
}