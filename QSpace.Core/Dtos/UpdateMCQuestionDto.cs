using Microsoft.AspNetCore.Http;
using QSpace.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QSpace.Core.Dtos
{
    public class UpdateMCQuestionDto
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public string Statement { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string CorrectAnswer { get; set; }
        public IFormFile AttachmentURL { get; set; }
        public double Score { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }

        public bool IsActive { get; set; }      
        public int QuizId { get; set; }
    }
}
