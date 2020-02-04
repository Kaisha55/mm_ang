using System;
using System.Collections.Generic;

namespace MM_Ang.Models
{
    public partial class EventStatus
    {
        public EventStatus()
        {
            EventUpdate = new HashSet<EventUpdate>();
        }

        public int EventStatusId { get; set; }
        public string StatusDesc { get; set; }

        public virtual ICollection<EventUpdate> EventUpdate { get; set; }
    }
}
