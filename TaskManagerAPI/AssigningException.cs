using System;

namespace TaskManagerAPI
{
    public class AssigningException : Exception
    {
        public override string Message => "Cannot assign this user.";
    }
}