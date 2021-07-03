using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QSpace.Data.DbEntities
{
    public class QuizDbEntity : BaseDbEntity
    {
        [Required]
        public string Name { get; set; }    
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        [Required]
        public string InstructorId;
        public User Instructor { get; set; }
        public List<MCQuestionDbEntity> Questions { get; set; }
        public List<SessionDbEntity> Sessions { get; set; }
        public QuizDbEntity()
    {
            IsActive = false;
            IsCompleted = false;
            if (Instructor != null && InstructorId == null)
                InstructorId = Instructor.Id;
        }
    }
}