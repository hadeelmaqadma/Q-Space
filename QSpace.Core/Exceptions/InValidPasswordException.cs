using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Core.Exceptions
{
    public class InValidPasswordException : Exception
    {
        public InValidPasswordException() : base("No further data to display")
        {

        }
    }
}
