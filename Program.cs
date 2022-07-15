using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            int noOfAccounts;

            Console.Write("Enter number of accounts to create: ");
            noOfAccounts = Convert.ToInt32(Console.ReadLine());
            Account[] arrAccount = CreateAccount(noOfAccounts);
            CalculateTotalSalary(arrAccount);
            
            var listAccount = new List<Account>();
            for(int i = 0; i < arrAccount.Length; i++)
            {
                listAccount.Add(new Account{Id = arrAccount[i].Id, Name = arrAccount[i].Name, Salary = arrAccount[i].Salary});
            }

            PrintAccountNameList(listAccount);
            
        }

        static Account[] CreateAccount(int noOfAccounts)
        {
            Account[] acc = new Account[noOfAccounts];
            for (int i = 0; i < noOfAccounts; i++)
            {
                int id;
                string name;
                int salary;

                Console.WriteLine($"\nEnter Details for Account {i+1}");
                Console.Write("Enter account number:\t");
                id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter account name:\t");
                name = Console.ReadLine();
                Console.Write("Enter account salary:\t");
                salary = Convert.ToInt32(Console.ReadLine());

                acc[i] = new Account(id, name, salary);

            }
            return acc;
        }

        static void CalculateTotalSalary(Account[] acc)
        {
            int salarySum = 0;
            
            for (int i = 0; i < acc.Length; i++)
            {
                salarySum += acc[i].Salary;
            }
            Console.WriteLine($"\nSummation of Salaries:\t{salarySum}");
        }

        static void PrintAccountNameList(List<Account> listAccount)
        {
            foreach (var Account in listAccount)
            {
                //Console.Write(string.Join(", ", listAccount.Select( x => x.Name)));
                Console.Write($"{Account.Name}, ");

            }
        }
    }
}
