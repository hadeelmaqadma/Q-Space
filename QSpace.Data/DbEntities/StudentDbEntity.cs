using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QSpace.Data.DbEntities
{
    public class StudentDbEntity : BaseDbEntity
    {
        [Required]
        public string Name { get; set; }
        public double Score { get; set; }
        [Required]
        public int SessionId { get; set; }
        public SessionDbEntity Session { get; set; }
        public List<StudentQuestionsDbEntity> StudentsQuestions { get; set; }
        public StudentDbEntity()
        {
            Score = 0;
        }
    }
}
