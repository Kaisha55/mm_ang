﻿using System;
using System.Collections.Generic;

namespace MM_Ang.Models
{
    public partial class TimeZoneInfo
    {
        public int Id { get; set; }
        public double? RunHourUtc { get; set; }
        public string TimeZoneId { get; set; }
        public string DisplayName { get; set; }
    }
}
