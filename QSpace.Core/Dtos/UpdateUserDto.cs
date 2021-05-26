using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.Dtos
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FCMToken { get; set; }
    }
}
