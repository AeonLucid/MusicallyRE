using System;
using System.Runtime.Serialization;

namespace MusicallyApi.Sign
{
    public class AeonLucidSignException : Exception
    {
        public AeonLucidSignException()
        {
        }

        protected AeonLucidSignException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public AeonLucidSignException(string message) : base(message)
        {
        }

        public AeonLucidSignException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
