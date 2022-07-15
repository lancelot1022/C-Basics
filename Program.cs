using System;

namespace ExerciseEight
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValidInput = true;
            while(isValidInput)
            {
                try
                {
                    ValidateInputAndAdd();
                    isValidInput = false;
                }
                catch (NonIntInputException ex1)
                {
                    Console.WriteLine(ex1.Message);
                }
                catch (NegativeNumberException ex2)
                {
                    Console.WriteLine(ex2);
                    isValidInput = false;
                }

            }            

        }

        static void ValidateInputAndAdd()
        {
            string userInput;
            int sum = 0;
            int[] convertedInput = new int[2];

            Console.Write("Input:\t");
            userInput = Console.ReadLine();
            string[] arrInput = new string[2];
            arrInput =  userInput.Split(' ');

            for (int i = 0; i < arrInput.Length; i++)
            {
                while (!int.TryParse(arrInput[i], out convertedInput[i]))
                {
                    string exceptionMsg = "Input not integer. Please try again.";
                    throw new NonIntInputException(exceptionMsg);
                }

                convertedInput[i] = Convert.ToInt32(arrInput[i]);
            }

            for (int i = 0; i < convertedInput.Length; i++)
            {
                if(convertedInput[i] < 0)
                {
                    throw new NegativeNumberException();
                }

                sum += convertedInput[i];
            }
            Console.WriteLine($"Output:\t{sum}");

        }
    }
}
