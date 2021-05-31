using Microsoft.AspNetCore.Http;
using QSpace.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QSpace.Core.Dtos
{
    public class CreateMCQuestionDto
    {
        [Required]
        public string Statement { get; set; }
        [Required]
        public int Time { get; set; }   

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
        [Required]
        public double Score { get; set; }
        [Required]
        public DifficultyLevel DifficultyLevel { get; set; }
        public IFormFile AttachmentURL { get; set; }
        [Required]
        public int QuizId { get; set;}
    }
}
