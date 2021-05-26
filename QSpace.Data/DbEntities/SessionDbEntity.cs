using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QSpace.Data.DbEntities
{
    public class SessionDbEntity : BaseDbEntity
    {
        [Required]
        public string Code { get; set; }        
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime HeldAt { get; set; }
        public double? AvgScore { get; set; }
        public double? MeanScore { get; set; }
        public int? StudentsCount { get; set; }
        [ForeignKey("QuizId")]
        public QuizDbEntity Quiz { get; set; }
        public List<StudentDbEntity> Students { get; set; }

        public SessionDbEntity() {
            CreatedAt = DateTime.Now;
            Code = Guid.NewGuid().ToString().Trim().Replace("-", "").Substring(0, 8);
        }
    }
}
