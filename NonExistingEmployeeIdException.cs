using System;

namespace FinalProject
{
    class NonExistingEmployeeIdException : Exception
    {
        public NonExistingEmployeeIdException(string msg) : base(msg)
        {
            
        }
    }
}