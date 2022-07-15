using System;

namespace FinalProject
{
    class InvalidInputException : Exception
    {
        public InvalidInputException(string msg) : base(msg)
        {
            
        }
    }
}