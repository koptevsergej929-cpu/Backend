using lesson_23.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace lesson_23.Json
{
    public class JsonScheduleRepository : IScheduleRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _opts = new() { PropertyNameCaseInsensitive = true };

        public JsonScheduleRepository(string path)
        {
            _path = path;
            if (!File.Exists(_path))
            {
                var sample = new ScheduleFile
                {
                    Groups = new List<GroupSchedule>
                    {
                   new GroupSchedule
                   {
                       Group = "9А",
                       Days = new List<DaySchedule>
                       {
                           new DaySchedule { Day = "Monday", Lessons = new List<Lesson>{ new Lesson("09:00", "Physics") } },
                           new DaySchedule { Day = "Tuesday", Lessons = new List<Lesson>{ new Lesson("09:00", "Math") } },
                           new DaySchedule { Day = "Wednesday", Lessons = new List<Lesson>{ new Lesson("09:00", "Biology") }  },
                           new DaySchedule { Day = "Thursday", Lessons = new List<Lesson>{ new Lesson("09:00", "Geografaphy") }  },
                           new DaySchedule { Day = "Friday", Lessons = new List<Lesson>{ new Lesson("09:00", "Literature") } }
                       }
                   }

                    }
                };
                File.WriteAllText(_path, JsonSerializer.Serialize(sample, new JsonSerializerOptions { WriteIndented = true }));
            }
        }

        public ScheduleFile Load()
        {
            using var s = File.OpenRead(_path);
            return JsonSerializer.Deserialize<ScheduleFile>(s, _opts) ?? new ScheduleFile();
        }
    }
}
