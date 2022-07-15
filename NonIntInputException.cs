using System;

namespace ExerciseEight
{
    class NonIntInputException : Exception
    {
        public NonIntInputException(string msg) : base(msg)
        {
                
        }
    }
}