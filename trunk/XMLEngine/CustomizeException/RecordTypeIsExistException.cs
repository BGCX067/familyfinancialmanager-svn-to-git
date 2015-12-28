using System;

namespace alpha.personal.XMLEngine.CustomizeException
{
    public class RecordTypeIsExistException : ApplicationException
    {
        public RecordTypeIsExistException() : base() { }

        public RecordTypeIsExistException(string message) : base(message) { }

        public RecordTypeIsExistException(string message, Exception ex) : base(message, ex) { }
    }
}
