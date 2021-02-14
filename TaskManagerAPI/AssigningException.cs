using System;

namespace TaskManagerAPI
{
    public class AssigningException : Exception
    {
        public override string Message => "This task can have only one executor.";
    }
}