using System;
using System.Collections.Generic;
using System.Text;

namespace TabuleiroNS.Exceptions
{
    class TabuleiroException : ApplicationException
    {
        public TabuleiroException(string message) : base(message)
        {
        }
    }
}
