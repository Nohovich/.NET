using System;
using System.Runtime.Serialization;

namespace OOP___Summary_project
{
    [Serializable]
    internal class ThisCustomerIsAlreadyInTheSystemException : Exception
    {
        public ThisCustomerIsAlreadyInTheSystemException()
        {
        }

        public ThisCustomerIsAlreadyInTheSystemException(string message) : base(message)
        {
        }

        public ThisCustomerIsAlreadyInTheSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ThisCustomerIsAlreadyInTheSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}