using System;

namespace ExerciseFour
{
    class GetWeightInPounds
    {
        public float weightInKg{get; set;}

        public GetWeightInPounds(float weight)
        {
            weightInKg = weight;
        }

        public void convertToPounds()
        {
            float weightInLbs;
            weightInLbs = weightInKg * 2.2f;
            Console.WriteLine($"Weight: {weightInLbs}");
        }
    }
}