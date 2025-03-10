using System.Runtime.Serialization;

namespace Hackathon_SQL.Repository
{
    [Serializable]
    internal class FoundExceptionSql : System.Exception
    {
        public FoundExceptionSql()
        {
        }

        public FoundExceptionSql(string? message) : base(message)
        {
        }

        public FoundExceptionSql(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected FoundExceptionSql(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}