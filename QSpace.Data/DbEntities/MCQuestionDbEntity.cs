using Microsoft.AspNetCore.Http;
using QSpace.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QSpace.Data.DbEntities
{
    public class MCQuestionDbEntity : BaseDbEntity
    {
        [Required]
        public int Time { get; set; }
        [Required]
        public string Statement { get; set; }
        public string AttachmentURL { get; set; }
        public double Score { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public DifficultyLevel DifficultyLevel { get; set; }
        
        [Required]
        public string A { get; set; }
        [Required]
        public string B { get; set; }
        [Required]
        public string C { get; set; }
        [Required]
        public string D { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
        [ForeignKey("QuizId")]
        public QuizDbEntity Quiz { get; set; }
        public List<StudentQuestionsDbEntity> StudentsQuestions { get; set; }
        public MCQuestionDbEntity() {
            IsActive = true;
        }
    }
}