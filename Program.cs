using System;

namespace ExerciseOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            int age;

            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();
            Console.Write("Enter age: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"My name is {firstName} {lastName}, and I am {age} years old.");
        }
    }
}
