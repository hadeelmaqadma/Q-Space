using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QSpace.Data.DbEntities
{
    public class StudentQuestionsDbEntity
    {       
        public int QuestionId { get; set; }
        public MCQuestionDbEntity Question{ get; set; }
        public int StudentId { get; set; }
        public StudentDbEntity Student { get; set; }
        public bool IsCorrect { get; set; }

        public StudentQuestionsDbEntity() {
            IsCorrect = false;
        }
    }

}
