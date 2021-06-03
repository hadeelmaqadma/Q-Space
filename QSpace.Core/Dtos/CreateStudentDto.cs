using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QSpace.Core.Dtos
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; }
        public string email { get; set; }

        public int SessionId { get; set; }
    }
}
