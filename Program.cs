using System;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int selectedAction;
            int selectedView;
            const string excMsg = "Invalid selected action.";

            Console.WriteLine("Welcome to Employee Payroll App");
            Console.WriteLine("Press 'Enter' to begin...");
            Console.ReadLine();
            Console.WriteLine("Select the number corresponding to the action to perform then press 'Enter'");
            Console.WriteLine("1 - Create/Add\n2 - Read/Display\n3 - Update/Modify\n4 - Delete/Archive");
            selectedAction = int.Parse(Console.ReadLine());
            Functions f = new Functions();
            

            switch (selectedAction)
            {
                case 1:
                    Console.WriteLine("Create/Add new employee record");
                    f.CreateEmployeeRecord();
                    break;
                case 2:
                    Console.WriteLine("Read/Display Employee Payslip");
                    Console.WriteLine("Select to view single/all Payslips");
                    Console.WriteLine("1 - View employee payslip via Employee ID");
                    Console.WriteLine("2 - View  all employee payslips");
                    selectedView = int.Parse(Console.ReadLine());
                    IGeneratePayslip gen;
                    if(selectedView == 1)
                    {
                        gen = new ViewEmployeePayslip();
                        gen.GeneratePayslip();

                    } else if(selectedView == 2)
                    {
                        gen = new ViewAllEmployeePayslip();
                        gen.GeneratePayslip();
                    } else
                    {
                        //Exception
                        throw new InvalidInputException(excMsg);
                    }
                    
                    break;
                case 3:
                    Console.WriteLine("Update/Modify new employee record/s");
                    f.UpdateEmployeeRecord();
                    break;
                case 4:
                    Console.WriteLine("Delete/Archive new employee record/s");
                    f.DeleteEmployee();
                    break;
                default:
                    //Exception
                    throw new InvalidInputException(excMsg);
            }
        }
    }
}
