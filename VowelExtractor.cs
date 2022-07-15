using System;

namespace ExerciseSix
{
    class VowelExtractor : IExtractor
    {
        public string Text{get; set;}

        public VowelExtractor(string input)
        {
            Text = input;
        }

        public int Extract()
        {
            int vowelCount = 0;
            char[] vowels = {'a','i','u','e', 'o'};

            for(int i = 0; i < Text.Length; i++)
            {
                if(Array.Exists(vowels, element => element == Text[i]))
                {
                    vowelCount++;
                }
            }

            return vowelCount;
        }
    }
}