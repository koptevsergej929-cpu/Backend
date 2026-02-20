using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_23.Model
{
    public class GroupSchedule
    {
        public string Group { get; set; } = string.Empty;
        public List<DaySchedule> Days { get; set; } = new();
    }
}
