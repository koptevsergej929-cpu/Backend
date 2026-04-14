using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_23.Model
{
     public record Lesson(string Time, string Subject, string Teacher = "")
    {
    }
}
