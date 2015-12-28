using System;

namespace alpha.personal.XMLEngine.CustomizeException
{
    internal class FileException : ApplicationException
    {
        public FileException() : base() { }

        public FileException(string message) : base(message) { }

        public FileException(string message, Exception ex) : base(message, ex) { }
    }
}
