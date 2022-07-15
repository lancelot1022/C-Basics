using System;

namespace ExerciseThree
{
    class Program
    {
        static void Main(string[] args)
        {
            int month;

            Console.Write("Enter month in numbers (1-Jan, 2-Feb): ");
            month = Convert.ToInt32(Console.ReadLine());

            DayCounter dc = new DayCounter();
            dc.CountDayInMonth(month);

        }
    }
}
