using System;

namespace ExerciseTwo
{
    class Operators
    {
        public float Add(float x, float y)
        {
            float sum;

            sum = x + y;

            return sum;
        }

        public float Subtract(float x, float y)
        {
            float diff;

            diff = x - y;

            return diff;
        }

        public float Multiply(float x, float y)
        {
            float product;

            product = x * y;

            return product;
        }

        public float Divide(float x, float y)
        {
            float quotient;

            quotient = x / y;

            return quotient;
        }
    }
}