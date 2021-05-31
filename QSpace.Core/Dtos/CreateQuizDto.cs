using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QSpace.Core.Dtos
{
    public class CreateQuizDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string InstructorId { get; set; }
    }
}
