using System;

namespace alpha.personal.XMLEngine.CustomizeException
{
    public class RecordInfoNotEnoughException : ApplicationException
    {
        public RecordInfoNotEnoughException() : base() { }

        public RecordInfoNotEnoughException(string message) : base(message) { }

        public RecordInfoNotEnoughException(string message, Exception ex) : base(message, ex) { }
    }
}
