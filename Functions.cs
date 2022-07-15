using System.Collections.Generic;
using FinalProject.DataModels;
using FinalProject.TaxCalculators;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace FinalProject
{
    class Functions
    {
        public List<EmployeeDetails> LoadPayrollRecord()
        {
            StreamReader r = new StreamReader("./Data/PayrollRecords.json");
            string json = r.ReadToEnd();
            List<EmployeeDetails> empRecords = JsonConvert.DeserializeObject<List<EmployeeDetails>>(json);
            r.Close();
    
            return empRecords;
        }
        public void CreateEmployeeRecord()
        {
            List<SalaryDetails> empSalaryDetails = new List<SalaryDetails>();
            List<TaxDetails> empTaxDetails = new List<TaxDetails>();
            var empRecords = LoadPayrollRecord();
            var lastEmp = empRecords.Last();
            var empRecordList = empRecords ?? new List<EmployeeDetails>();

            int empID;
            string empLname;
            string empFname;
            string empMname;
            string empGender;
            string empStatus;
            string empPosition;
            float empTaxablePay;
            float empNonTaxablePay;
            float empAnnualIncomeTax;
            float empIncomeTax;
            float empSSTax;
            float empHealthInsurance;
            float empOtherTax;

            string selectedTaxation;

            Console.WriteLine(" ==== Enter Employee Details ==== ");
            empID = lastEmp.EmployeeID+1;
            Console.WriteLine("Last name: ");
            empLname = Console.ReadLine();
            Console.WriteLine("First name: ");
            empFname = Console.ReadLine();
            Console.WriteLine("Middle name: ");
            empMname = Console.ReadLine();
            Console.WriteLine("Gender (M/F): ");
            empGender = Console.ReadLine();
            Console.WriteLine("Status (Single/Married/Divorced/Widowed): ");
            empStatus = Console.ReadLine();
            Console.WriteLine("Position: ");
            empPosition = Console.ReadLine();

            Console.WriteLine(" ==== Enter Employee Salary Details ==== ");
            Console.WriteLine("Monthly Taxable Pay: ");
            empTaxablePay = float.Parse(Console.ReadLine());
            Console.WriteLine("Monthly Non-Taxable Pay: ");
            empNonTaxablePay = float.Parse(Console.ReadLine());

            Console.WriteLine(" ==== Enter Employee Tax Details ==== ");
            Console.WriteLine("Monthly Total Other Taxes: ");
            empOtherTax = float.Parse(Console.ReadLine());

            Console.WriteLine(" ==== Manually enter tax rates? (Y/N) ==== ");
            selectedTaxation = Console.ReadLine();

            if(selectedTaxation.ToUpper() == "Y")
            {
                TaxCalculator calculate = new TaxCalculator();

                //Income Tax
                Console.WriteLine("Income Tax");
                empIncomeTax = calculate.TaxCalculate(empTaxablePay);

                //Social Security
                Console.WriteLine("Social Security");
                empSSTax = calculate.TaxCalculate(empTaxablePay);

                //Health Insurance
                Console.WriteLine("Health Insurance");
                empHealthInsurance = calculate.TaxCalculate(empTaxablePay);

            }
            else if(selectedTaxation.ToUpper() == "N")
            {
                TaxCalculator incTaxCalc = new IncomeTaxCalculator();
                TaxCalculator ssCalc = new SocialSecurityCalculator();
                TaxCalculator healInsCalc = new HealthInsuranceCalculator();

                //Calculate Taxes using predefined rates
                empAnnualIncomeTax = incTaxCalc.TaxCalculate(empTaxablePay);
                empIncomeTax = empAnnualIncomeTax / 12;
                empSSTax = ssCalc.TaxCalculate(empTaxablePay);
                empHealthInsurance = healInsCalc.TaxCalculate(empTaxablePay);

            }
            else
            {
                string excMsg = "Invalid selected action.";
                throw new InvalidInputException(excMsg);
            }

            empRecordList.Add( new EmployeeDetails()
            {
                EmployeeID = empID,
                LastName = empLname,
                FirstName = empFname,
                MiddleName = empMname,
                Gender = empGender,
                Status = empStatus,
                Position = empPosition,
                EmpSalary = new SalaryDetails
                {
                    MonthlyTaxablePay = empTaxablePay,
                    MonthlyNonTaxablePay = empNonTaxablePay
                },
                EmpTax = new TaxDetails
                {
                    IncomeTax = empIncomeTax,
                    SocialSecurity = empSSTax,
                    HealthInsurance = empHealthInsurance,
                    OtherTaxes = empOtherTax
                }
            });
            
        
        string json = JsonConvert.SerializeObject(empRecordList,Formatting.Indented);
        using(StreamWriter w = new StreamWriter("./Data/PayrollRecords.json"))
        {
            w.WriteLine(json);
        }
        Console.WriteLine("Employee successfully created.");
        }

        public void UpdateEmployeeRecord()
        {
            int toUpdate;
            int empNo;

            string newLname;
            string newFname;
            string newMname;
            string newGender;
            string newStatus;
            string newPosition;
            string newTaxablePay;
            string newNonTaxablePay;
            float fNewTaxablePay;
            float newAnnualIncomeTax;
            float newIncomeTax;
            float newSSTax;
            float newHealthInsurance;
            string newOtherTax;

            string selectedTaxation;

            Functions f = new Functions();
            var empRecords = f.LoadPayrollRecord();

            Console.WriteLine("Enter Employee ID to update:");
            empNo = int.Parse(Console.ReadLine());

            var empToUpdate = empRecords.Find(x => x.EmployeeID == empNo);

            Console.WriteLine("Select details to update");
            Console.WriteLine("1 - Employee Details");
            Console.WriteLine("2 - Salary Details");
            Console.WriteLine("3 - Tax Details");
            toUpdate = int.Parse(Console.ReadLine());

            if(empToUpdate == null)
            {
                var excMsg = $"Employee with Id: {empNo} does NOT exist!";
                throw new NonExistingEmployeeIdException(excMsg);
            }
            else
            {
                if(toUpdate == 1)
                {
                    Console.WriteLine(" ==== Update Employee Details ==== ");
                    Console.WriteLine("Last name: ");
                    newLname = Console.ReadLine();
                    Console.WriteLine("First name: ");
                    newFname = Console.ReadLine();
                    Console.WriteLine("Middle name: ");
                    newMname = Console.ReadLine();
                    Console.WriteLine("Gender (M/F): ");
                    newGender = Console.ReadLine();
                    Console.WriteLine("Status (Single/Married/Divorced/Widowed): ");
                    newStatus = Console.ReadLine();
                    Console.WriteLine("Position: ");
                    newPosition = Console.ReadLine();

                    //Update employee details in JSON
                    if(!string.IsNullOrEmpty(newLname))
                    {
                        empToUpdate.LastName = newLname;
                    }
                    if(!string.IsNullOrEmpty(newFname))
                    {
                        empToUpdate.FirstName = newFname;
                    }
                    if(!string.IsNullOrEmpty(newMname))
                    {
                        empToUpdate.MiddleName = newMname;
                    }
                    if(!string.IsNullOrEmpty(newGender))
                    {
                        empToUpdate.Gender = newGender;
                    }
                    if(!string.IsNullOrEmpty(newStatus))
                    {
                        empToUpdate.Status = newStatus;
                    }
                    if(!string.IsNullOrEmpty(newPosition))
                    {
                        empToUpdate.Position = newPosition;
                    }

                }
                else if(toUpdate == 2)
                {
                    Console.WriteLine(" ==== Update Employee Salary Details ==== ");
                    Console.WriteLine("Monthly Taxable Pay: ");
                    newTaxablePay = Console.ReadLine();
                    Console.WriteLine("Monthly Non-Taxable Pay: ");
                    newNonTaxablePay = Console.ReadLine();

                    //Update employee salary details in JSON
                    if(!string.IsNullOrEmpty(newTaxablePay))
                    {
                        fNewTaxablePay = float.Parse(newTaxablePay);
                        empToUpdate.EmpSalary.MonthlyTaxablePay = fNewTaxablePay;

                        Console.WriteLine(" ==== Due to updated taxable income, taxes will be updated accordingly. ==== ");
                        Console.WriteLine(" ==== Manually enter tax rates? (Y/N) ==== ");
                        selectedTaxation = Console.ReadLine();

                        if(selectedTaxation.ToUpper() == "Y")
                        {
                            TaxCalculator calculate = new TaxCalculator();

                            //Income Tax
                            Console.WriteLine("Update Income Tax");
                            newIncomeTax = calculate.TaxCalculate(fNewTaxablePay);

                            //Social Security
                            Console.WriteLine("Update Social Security");
                            newSSTax = calculate.TaxCalculate(fNewTaxablePay);

                            //Health Insurance
                            Console.WriteLine("Update Health Insurance");
                            newHealthInsurance = calculate.TaxCalculate(fNewTaxablePay);

                            //Update employee tax computations in JSON
                            empToUpdate.EmpTax.IncomeTax = newIncomeTax;
                            empToUpdate.EmpTax.SocialSecurity = newSSTax;
                            empToUpdate.EmpTax.HealthInsurance = newHealthInsurance;
                        }
                        else if(selectedTaxation.ToUpper() == "N")
                        {
                            TaxCalculator incTaxCalc = new IncomeTaxCalculator();
                            TaxCalculator ssCalc = new SocialSecurityCalculator();
                            TaxCalculator healInsCalc = new HealthInsuranceCalculator();

                            //Calculate Taxes using predefined rates
                            newAnnualIncomeTax = incTaxCalc.TaxCalculate(fNewTaxablePay);
                            newIncomeTax = newAnnualIncomeTax / 12;
                            newSSTax = ssCalc.TaxCalculate(fNewTaxablePay);
                            newHealthInsurance = healInsCalc.TaxCalculate(fNewTaxablePay);

                            //Update employee tax computations in JSON
                            empToUpdate.EmpTax.IncomeTax = newIncomeTax;
                            empToUpdate.EmpTax.SocialSecurity = newSSTax;
                            empToUpdate.EmpTax.HealthInsurance = newHealthInsurance;
                        }
                        else
                        {
                            string excMsg = "Invalid selected action.";
                            throw new InvalidInputException(excMsg);
                        }
                    }
                    if(!string.IsNullOrEmpty(newNonTaxablePay))
                    {
                        empToUpdate.EmpSalary.MonthlyNonTaxablePay = float.Parse(newNonTaxablePay);
                    }

                }
                else if(toUpdate == 3)
                {
                    Console.WriteLine(" ==== Update Employee Tax Details ==== ");

                    Console.WriteLine(" ==== Update tax rates? (Y/N) ==== ");
                        selectedTaxation = Console.ReadLine();

                        if(selectedTaxation.ToUpper() == "Y")
                        {
                            float empTaxablePay = empToUpdate.EmpSalary.MonthlyTaxablePay;
                            TaxCalculator calculate = new TaxCalculator();

                            //Income Tax
                            Console.WriteLine("Update Income Tax");
                            newIncomeTax = calculate.TaxCalculate(empTaxablePay);

                            //Social Security
                            Console.WriteLine("Update Social Security");
                            newSSTax = calculate.TaxCalculate(empTaxablePay);

                            //Health Insurance
                            Console.WriteLine("Update Health Insurance");
                            newHealthInsurance = calculate.TaxCalculate(empTaxablePay);

                            //Update employee tax computations in JSON
                            empToUpdate.EmpTax.IncomeTax = newIncomeTax;
                            empToUpdate.EmpTax.SocialSecurity = newSSTax;
                            empToUpdate.EmpTax.HealthInsurance = newHealthInsurance;
                        }
                        else if(selectedTaxation.ToUpper() == "N")
                        {
                            Console.WriteLine(" No adjustments in taxes. ");
                        }
                        else
                        {
                            string excMsg = "Invalid selected action.";
                            throw new InvalidInputException(excMsg);
                        }

                    Console.WriteLine("Monthly Total Other Taxes: ");
                    newOtherTax = Console.ReadLine();

                    //Update JSON
                    if(!string.IsNullOrEmpty(newOtherTax))
                    {
                        empToUpdate.EmpTax.OtherTaxes = float.Parse(newOtherTax);
                    }
                }
                else
                {
                    //Exception
                    const string excMsg = "Invalid selection.";
                    throw new InvalidInputException(excMsg);
                }
                string json = JsonConvert.SerializeObject(empRecords,Formatting.Indented);
                using(StreamWriter w = new StreamWriter("./Data/PayrollRecords.json"))
                {
                    w.WriteLine(json);
                }
                Console.WriteLine($"Employee {empNo} successfully updated.");
            }
        }

        public void DeleteEmployee()
        {
            int empNo;
            Functions f = new Functions();
            var empRecords = f.LoadPayrollRecord();
            Console.WriteLine("Enter Employee ID to delete:");
            empNo = int.Parse(Console.ReadLine());

            var empToDelete = empRecords.Find(x => x.EmployeeID == empNo);

            if(empToDelete != null)
            {
                empRecords.Remove(empToDelete);
            }
            else
            {
                var excMsg = $"Employee with Id: {empNo} does NOT exist!";
                throw new NonExistingEmployeeIdException(excMsg);
            }
            
            string json = JsonConvert.SerializeObject(empRecords,Formatting.Indented);
            using(StreamWriter w = new StreamWriter("./Data/PayrollRecords.json"))
            {
                w.WriteLine(json);
            }
            Console.WriteLine($"Employee {empNo} successfully deleted.");
        }

        public float NetIncomeCalculator(SalaryDetails empSalary, TaxDetails empTaxes)
        {
            float monthlyNetIncome = 0;
            float monthlyIncomeTax = empTaxes.IncomeTax / 12;
            float totalDeductions = monthlyIncomeTax + empTaxes.SocialSecurity + empTaxes.HealthInsurance + empTaxes.OtherTaxes;
            float totalEarnings = empSalary.MonthlyTaxablePay + empSalary.MonthlyNonTaxablePay;

            monthlyNetIncome = totalEarnings - totalDeductions;

            return monthlyNetIncome;
        }

        public void DisplayPayslip(EmployeeDetails empDetails)
        {
            float monthlyGrossPay = empDetails.EmpSalary.MonthlyTaxablePay + empDetails.EmpSalary.MonthlyNonTaxablePay;
            float monthlyIncomeTax = empDetails.EmpTax.IncomeTax /12;
            float totalDeductions = monthlyIncomeTax + empDetails.EmpTax.HealthInsurance + 
                                    empDetails.EmpTax.SocialSecurity + empDetails.EmpTax.OtherTaxes;
            float netIncome = NetIncomeCalculator(empDetails.EmpSalary,empDetails.EmpTax);

            Console.WriteLine("\n =====================( MONTHLY PAYSLIP )===================== ");
            Console.WriteLine($"\nPAY PERIOD:       {DateTime.Now.ToString("M/d/yyyy")}");
            Console.WriteLine($"EMPLOYEE NAME:      {empDetails.LastName}, {empDetails.FirstName} {empDetails.MiddleName}");
            Console.WriteLine($"EMPLOYEE POSITION:  {empDetails.Position}");
            Console.WriteLine("\n =====================(    EARNINGS     )===================== ");
            Console.WriteLine($"\nMONTHLY TAXABLE INCOME:     {empDetails.EmpSalary.MonthlyTaxablePay}");
            Console.WriteLine($"MONTHLY NON TAXABLE INCOME: {empDetails.EmpSalary.MonthlyNonTaxablePay}");
            Console.WriteLine($"GROSS PAY:                  {monthlyGrossPay}");
            Console.WriteLine("\n =====================(   DEDUCTIONS    )===================== ");
            Console.WriteLine($"\nINCOME TAX:         {monthlyIncomeTax}");
            Console.WriteLine($"SOCIAL SECURITY:    {empDetails.EmpTax.SocialSecurity}");
            Console.WriteLine($"HEALTH INSURANCE:   {empDetails.EmpTax.HealthInsurance}");
            Console.WriteLine($"OTHER TAXES:        {empDetails.EmpTax.OtherTaxes}");
            Console.WriteLine($"TOTAL DEDUCTIONS:   {totalDeductions}");
            Console.WriteLine("\n =====================(  TOTAL NET PAY  )===================== ");
            Console.WriteLine($"\n                      NET PAY: {netIncome}");
        }
    }
}