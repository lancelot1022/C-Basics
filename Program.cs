using System;

namespace ExerciseFive
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int extractor;
            int vowelExtractor;
            int constExtractor;

            Console.Write("Input text:\t");
            input = Console.ReadLine().ToLower();

            Extractor ext = new Extractor();
            extractor = ext.Extract(input);
            Console.WriteLine($"Extractor:\t{extractor}");

            Extractor vowelExt = new VowelExtractor();
            vowelExtractor = vowelExt.Extract(input);
            Console.WriteLine($"VowelExtractor:\t{vowelExtractor}");

            Extractor constExt = new ConsonantExtractor();
            constExtractor = constExt.Extract(input);
            Console.WriteLine($"VowelExtractor:\t{constExtractor}");

        }
    }
}
