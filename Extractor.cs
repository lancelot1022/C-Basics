using System;

namespace ExerciseFive
{
    class Extractor
    {
        public virtual int Extract(string text)
        {
            int textCount;
            textCount = text.Length;

            return textCount;
        }

    }
}