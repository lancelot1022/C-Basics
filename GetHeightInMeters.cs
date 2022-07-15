using System;

namespace ExerciseFour
{
    class GetHeightInMeters
    {

        public float heightInCm{get; set;}

        public GetHeightInMeters(float height)
        {
            heightInCm = height;
        }

        public void ConvertToMeters()
        {
            float heightInM;
            heightInM = heightInCm / 100;
            Console.WriteLine($"Height: {heightInM}");
        }

    }
}