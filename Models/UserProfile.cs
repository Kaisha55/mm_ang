﻿using System;
using System.Collections.Generic;

namespace MM_Ang.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            EventUpdate = new HashSet<EventUpdate>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string PreferredContactMethod { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<EventUpdate> EventUpdate { get; set; }
    }
}
