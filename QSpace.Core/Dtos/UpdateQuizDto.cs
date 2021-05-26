using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.Dtos
{
    public class UpdateQuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
    }
}
