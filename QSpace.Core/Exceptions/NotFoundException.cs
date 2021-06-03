using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Core.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException():base("Not Found Message")
        {

        }

    }
}
