using System;

namespace FinalProject
{
    class ViewAllEmployeePayslip : IGeneratePayslip
    {
        public void GeneratePayslip()
        {
            Functions f = new Functions();
            f.LoadPayrollRecord();
            var empRecords = f.LoadPayrollRecord();
            int totalEmpRecords = empRecords.Count;
            
            for(int i = 0; i < totalEmpRecords; i++)
            {
                f.DisplayPayslip(empRecords[i]);
                Console.WriteLine("\n\n");
            }
            
        }
    }
}