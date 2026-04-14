using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_23.Model
{
    public interface IScheduleRepository
    {
        ScheduleFile Load();
    }
}
