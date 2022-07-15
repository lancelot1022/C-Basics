using System;

namespace ExerciseSeven
{
    class Account
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public int Salary {get; set;}

        public Account()
        {

        }
        
        public Account(int id, string name, int salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }


    }
}