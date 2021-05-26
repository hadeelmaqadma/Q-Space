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
        [Required]
        public int Time { get; set; }
        [Required]
        public string Statement { get; set; }
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
        public IFormFile AttachmentURL { get; set; }
        public double Score { get; set; }
        [Required]
        public DifficultyLevel DifficultyLevel { get; set; }

        public bool IsActive { get; set; }
        
        public int QuizId { get; set; }
    }
}
