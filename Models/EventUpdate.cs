using System;
using System.Collections.Generic;

namespace MM_Ang.Models
{
    public partial class EventUpdate
    {
        public int EventUpdateId { get; set; }
        public int EventId { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public string UpdateDesc { get; set; }
        public int EventStatusId { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventStatus EventStatus { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
