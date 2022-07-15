using System;

namespace ExerciseSix
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int output;
            Console.Write("Input text:\t");
            input = Console.ReadLine().ToLower();

            IExtractor extract = Execute(input);
            output = extract.Extract();
            Console.WriteLine($"Output:\t{output}");
        }

        private static IExtractor Execute(string text)
        {
            IExtractor output = null;
            if((text.Length % 2) != 0)
            {
                output = new VowelExtractor(text);
            } else {
                output = new ConsonantExtractor(text);
            }
            return output;
        }
    }
}
