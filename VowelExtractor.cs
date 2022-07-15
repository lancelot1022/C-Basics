using System;

namespace ExerciseFive
{
    class VowelExtractor : Extractor
    {
        public override int Extract(string text)
        {
            int vowelCount = 0;
            char[] vowels = {'a','i','u','e', 'o'};

            for(int i = 0; i < text.Length; i++)
            {
                if(Array.Exists(vowels, element => element == text[i]))
                {
                    vowelCount++;
                }
            }

            return vowelCount;
        }
    }
}