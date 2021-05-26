using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.Dtos
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FCMToken { get; set; }

    }
}
