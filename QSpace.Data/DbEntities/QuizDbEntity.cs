using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Data.DbEntities
{
    public class QuizDbEntity : BaseDbEntity
    {
        public string Name { get; set; }    
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }

        public int InstructorId { get; set; }

        public User Instructor { get; set; }
        public List<MCQuestionDbEntity> Questions { get; set; }
        public List<SessionDbEntity> Sessions { get; set; }
        public QuizDbEntity()
        {
            IsActive = false;
            IsCompleted = false;
        }
    }
}
