using System;

namespace ExerciseTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            float firstNumber;
            float secondNumber;
            float sum;
            float diff;
            float product;
            float quotient;

            Console.Write("Enter first number: ");
            firstNumber = float.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            secondNumber = float.Parse(Console.ReadLine());

            Operators op = new Operators();
            sum = op.Add(firstNumber, secondNumber);
            diff = op.Subtract(firstNumber, secondNumber);
            product = op.Multiply(firstNumber, secondNumber);
            quotient = op.Divide(firstNumber, secondNumber);

            Console.WriteLine($"Sum: {String.Format("{0:0.00}", sum)}, Difference: {String.Format("{0:0.00}", diff)}, Product: {String.Format("{0:0.00}", product)}, Quotient: {String.Format("{0:0.00}", quotient)}");

        }
    }
}
