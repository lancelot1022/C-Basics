using System;

namespace ExerciseThree
{
    class DayCounter
    {
        public void CountDayInMonth(int month) {
            int noOfDays;

            switch(month)
            {
                case 1:
                    noOfDays = 31;
                    break;
                case 2:
                    noOfDays = 28;
                    break;
                case 3:
                    noOfDays = 31;
                    break;
                case 4:
                    noOfDays = 30;
                    break;
                case 5:
                    noOfDays = 31;
                    break;
                case 6:
                    noOfDays = 30;
                    break;
                case 7:
                    noOfDays = 31;
                    break;
                case 8:
                    noOfDays = 31;
                    break;
                case 9:
                    noOfDays = 30;
                    break;
                case 10:
                    noOfDays = 31;
                    break;
                case 11:
                    noOfDays = 30;
                    break;
                case 12:
                    noOfDays = 31;
                    break;
                default:
                    noOfDays = 0;
                    break;
            }
            if(noOfDays > 0) 
            {
                Console.WriteLine($"{noOfDays} days");
            } else
            {
                Console.WriteLine("Invalid Input!");
            }
            
        }
    }
}
