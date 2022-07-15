using System;

namespace ExerciseFour
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            float heightInCm;
            float weightInKg;

            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter height in cm: ");
            heightInCm = float.Parse(Console.ReadLine());
            Console.Write("Enter weight in kg: ");
            weightInKg = float.Parse(Console.ReadLine());

            Console.WriteLine("\nConverted height and weight.");
            Console.WriteLine($"Name: {name}");
            GetHeightInMeters convertedHeight = new GetHeightInMeters(heightInCm);
            convertedHeight.ConvertToMeters();
            GetWeightInPounds convertedWeight = new GetWeightInPounds(weightInKg);
            convertedWeight.convertToPounds();
        }
    }
}
