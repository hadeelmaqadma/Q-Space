using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.ViewModels
{
    public class LoginResponseViewModel
    {
        public UserViewModel User { get; set; }

        public TokenViewModel Token { get; set; }

    }
}
