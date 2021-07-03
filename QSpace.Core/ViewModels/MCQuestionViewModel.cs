using QSpace.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.ViewModels
{
    public class MCQuestionViewModel
    {
        public int Id { get; set; }
        public string Statement { get; set; }
        public int Time { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        // hidden when it's viewed
        public string CorrectAnswer { get; set; }
        public double Score { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public string AttachmentURL { get; set; }
        public bool IsActive { get; set; }
    }
}
