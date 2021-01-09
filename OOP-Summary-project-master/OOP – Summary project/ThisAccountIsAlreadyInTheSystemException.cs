using System;
using System.Runtime.Serialization;

namespace OOP___Summary_project
{
    [Serializable]
    internal class ThisAccountIsAlreadyInTheSystemException : Exception
    {
        public ThisAccountIsAlreadyInTheSystemException()
        {
        }

        public ThisAccountIsAlreadyInTheSystemException(string message) : base(message)
        {
        }

        public ThisAccountIsAlreadyInTheSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ThisAccountIsAlreadyInTheSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}