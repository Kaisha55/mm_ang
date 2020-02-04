using System;
using System.Collections.Generic;

namespace MM_Ang.Models
{
    public partial class Event
    {
        public Event()
        {
            EventUpdate = new HashSet<EventUpdate>();
        }

        public int EventId { get; set; }
        public int? ReporterId { get; set; }
        public int? EventTypeId { get; set; }
        public int? CountryId { get; set; }
        public string EventShortDesc { get; set; }
        public string EventSourceLink { get; set; }
        public string EventNotes { get; set; }
        public DateTime? EventDate { get; set; }
        public decimal? EventLocationLat { get; set; }
        public decimal? EventLocationLong { get; set; }
        public string EventLocationDesc { get; set; }

        public virtual ICollection<EventUpdate> EventUpdate { get; set; }
    }
}
