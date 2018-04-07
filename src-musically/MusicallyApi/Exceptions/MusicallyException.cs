using System;
using System.Runtime.Serialization;

namespace MusicallyApi.Exceptions
{
    public class MusicallyException : Exception
    {
        public MusicallyException()
        {
        }

        public MusicallyException(string message) : base(message)
        {
        }

        public MusicallyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MusicallyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
