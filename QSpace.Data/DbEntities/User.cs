using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QSpace.Data.DbEntities
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string FCMToken { get; set; }
        public List<QuizDbEntity> Quizes { get; set; }
        public bool IsDelete { get; set; }
        public User() {
            CreatedAt = DateTime.Now;
        }
    }
}
