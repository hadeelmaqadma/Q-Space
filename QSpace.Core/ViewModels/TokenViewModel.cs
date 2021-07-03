using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.ViewModels
{
    public class TokenViewModel
    {
        public string AcessToken { get; set; }

        public DateTime ExpireAt { get; set; }
    }
}
