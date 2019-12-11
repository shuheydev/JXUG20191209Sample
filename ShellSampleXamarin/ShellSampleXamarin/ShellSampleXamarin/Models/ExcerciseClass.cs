using System;
using System.Collections.Generic;
using System.Text;

namespace ShellSampleXamarin.Models
{
    public class ExerciseClass
    {
        public DateTime ClassTime { get; set; }
        public string ClassName { get; set; }
        public string Instructor { get; set; }

        public bool IsLast { get; set; } = false;
    }
}
