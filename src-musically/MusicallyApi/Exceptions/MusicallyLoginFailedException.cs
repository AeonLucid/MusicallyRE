using System;
using System.Runtime.Serialization;

namespace MusicallyApi.Exceptions
{
    public class MusicallyLoginFailedException : MusicallyException
    {
        public MusicallyLoginFailedException()
        {
        }

        public MusicallyLoginFailedException(string message) : base(message)
        {
        }

        public MusicallyLoginFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MusicallyLoginFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
