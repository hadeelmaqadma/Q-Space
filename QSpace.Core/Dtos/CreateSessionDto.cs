using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QSpace.Core.Dtos
{
    public class CreateSessionDto
    {
        [Required]
        public DateTime HeldAt { get; set; }
        [Required]
        public int QuizId { get; set; }
        
    }
}
