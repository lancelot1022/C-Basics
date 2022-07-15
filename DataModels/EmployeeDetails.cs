using System.Collections.Generic;

namespace FinalProject.DataModels
{
    class EmployeeDetails
    {
        public int EmployeeID {get; set;}

        public string LastName {get; set;}

        public string FirstName {get; set;}
        
        public string MiddleName {get; set;}

        public string Gender {get; set;}

        public string Status {get; set;}

        public string Position {get; set;}

        public SalaryDetails EmpSalary {get; set;}

        public TaxDetails EmpTax {get; set;}



    }
}
