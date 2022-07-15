using System;

namespace FinalProject
{
    class ViewEmployeePayslip : IGeneratePayslip
    {
        public void GeneratePayslip()
        {
            int empNo;
            string viewAnother;
            Functions f = new Functions();
            var empRecords = f.LoadPayrollRecord();
            Console.WriteLine("Enter Employee ID to view payslip:");
            empNo = int.Parse(Console.ReadLine());

            var empToDisplay = empRecords.Find(x => x.EmployeeID == empNo);

            if(empToDisplay != null)
            {
                f.DisplayPayslip(empToDisplay);
            }
            else
            {
                var excMsg = $"Employee with Id: {empNo} does NOT exist!";
                throw new NonExistingEmployeeIdException(excMsg);
            }

            Console.WriteLine("View another employee payslip (Y/N)?");
            viewAnother = Console.ReadLine();
            if(viewAnother.ToUpper() == "Y")
            {
                GeneratePayslip();
            }
            else if(viewAnother.ToUpper() == "N")
            {
                Console.WriteLine("Thank you for using Employee Payslip App!");
            }
            else
            {
                string excMsg = "Invalid selected action.";
                throw new InvalidInputException(excMsg);
            }


        }
    }
}