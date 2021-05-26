using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSpace.Core.Exceptions
{
    public class EmptyResultException : Exception
    {
        public EmptyResultException() : base("No further data to display")
        {

        }
    }
}
