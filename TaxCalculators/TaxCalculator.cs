using System;

namespace FinalProject.TaxCalculators
{
    class TaxCalculator
    {
        //Calculates monthly taxes manually
        public virtual float TaxCalculate(float grossPay)
        {
            float taxCalculated = 0.0f;
            float rate = 0.0f;

            Console.WriteLine("Enter rate in decimal:");
            rate = float.Parse(Console.ReadLine());

            taxCalculated = grossPay * rate;

            return taxCalculated;
        }
    }
}