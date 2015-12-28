using System;

namespace alpha.personal.XMLEngine.CustomizeException
{
    internal class XMLEngineException : ApplicationException
    {
        public XMLEngineException() : base() { }

        public XMLEngineException(string message) : base(message) { }

        public XMLEngineException(string message, Exception ex) : base(message, ex) { }
    }
}
