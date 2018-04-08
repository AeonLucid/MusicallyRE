using System;
using System.Runtime.Serialization;

namespace MusicallyApi.Sign
{
    public class SignatureHandlerException : Exception
    {
        public SignatureHandlerException()
        {
        }

        protected SignatureHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public SignatureHandlerException(string message) : base(message)
        {
        }

        public SignatureHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
