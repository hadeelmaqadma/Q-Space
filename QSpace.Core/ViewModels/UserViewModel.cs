using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<QuizViewModel> Quizes { get; set; }
        public string FCMToken { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
