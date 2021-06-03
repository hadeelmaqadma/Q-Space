using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.Dtos
{
    public class UpdateSessionDto
    {
        public int Id { get; set; }
        public DateTime HeldAt { get; set; }
        public double AvgScore { get; set; }
        public double MeanScore { get; set; }
        public int StudentsCount { get; set; }
    }
}
