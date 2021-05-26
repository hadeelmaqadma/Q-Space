using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.ViewModels
{
    public class QuizViewModel
    {
        public string Name { get; set; }
        public List<MCQuestionViewModel> Questions { get; set; }
    }
}
