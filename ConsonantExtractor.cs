using System;

namespace ExerciseFive
{
    class ConsonantExtractor : Extractor
    {
        public override int Extract(string text)
        {
            int textCount;
            int vowelCount = 0;
            int consonantCount;
            char[] vowels = {'a','i','u','e', 'o'};

            textCount = text.Length;
            for(int i = 0; i < text.Length; i++)
            {
                if(Array.Exists(vowels, element => element == text[i]))
                {
                    vowelCount++;
                }
            }
            consonantCount = textCount - vowelCount;

            return consonantCount;
        }
    }
}