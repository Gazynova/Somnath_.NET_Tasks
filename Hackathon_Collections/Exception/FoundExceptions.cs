using System.Runtime.Serialization;

namespace Hackathon_Collections.Repository
{
    [Serializable]
    internal class FoundException : System.Exception
    {
        public FoundException()
        {
        }

        public FoundException(string? message) : base(message)
        {
        }

        public FoundException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected FoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}