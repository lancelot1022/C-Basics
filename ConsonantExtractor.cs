using System;

namespace ExerciseSix
{
    class ConsonantExtractor : IExtractor
    {
        public string Text{get; set;}

        public ConsonantExtractor(string input)
        {
            Text = input;
        }

        public int Extract()
        {
            int textCount;
            int vowelCount = 0;
            int consonantCount;
            char[] vowels = {'a','i','u','e', 'o'};

            textCount = Text.Length;
            for(int i = 0; i < Text.Length; i++)
            {
                if(Array.Exists(vowels, element => element == Text[i]))
                {
                    vowelCount++;
                }
            }
            consonantCount = textCount - vowelCount;

            return consonantCount;
        }
    }
}