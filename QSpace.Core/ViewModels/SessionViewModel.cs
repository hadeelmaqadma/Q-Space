using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.ViewModels
{
    public class SessionViewModel 
    {
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime HeldAt { get; set; }
        public double? AvgScore { get; set; }
        public double? MeanScore { get; set; }
        public int? StudentsCount { get; set; }
    }
}
