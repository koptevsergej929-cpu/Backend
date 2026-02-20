using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_23.Model
{
    public class DaySchedule
    {
        public string Day { get; set; } = string.Empty;
        public List<Lesson> Lessons { get; set; } = new();
    }
}
