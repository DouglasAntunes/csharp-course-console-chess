using System;

namespace TabuleiroNS.Exceptions
{
    class TabuleiroException : ApplicationException
    {
        public TabuleiroException(string message) : base(message)
        {
        }
    }
}
