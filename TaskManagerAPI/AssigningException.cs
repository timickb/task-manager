using System;

namespace TaskManagerAPI
{
    public class AssigningException : Exception
    {
        public AssigningException(string message)
        {
            Message = message;
        }
        public override string Message { get; }
    }
}