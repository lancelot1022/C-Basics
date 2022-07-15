namespace FinalProject.TaxCalculators
{
    class IncomeTaxCalculator : TaxCalculator
    {
        public override float TaxCalculate(float grossPay)
        {
            float annualIncomeTax = 0;
            float annualGrossPay = grossPay * 12;

            if(annualGrossPay <= 250000)
            {
                annualIncomeTax = 0;
            }
            else if(annualGrossPay > 250000 && annualGrossPay <= 400000)
            {
                annualIncomeTax = ((annualGrossPay - 250000) * 0.20f);
            }
            else if(annualGrossPay > 400000 && annualGrossPay <= 800000)
            {
                annualIncomeTax = ((annualGrossPay - 400000) * 0.25f) + 30000;
            }
            else if(annualGrossPay > 800000 && annualGrossPay <= 2000000)
            {
                annualIncomeTax = ((annualGrossPay - 800000) * 0.30f) + 130000;
            }
            else if(annualGrossPay > 2000000 && annualGrossPay <= 8000000)
            {
                annualIncomeTax = ((annualGrossPay - 2000000) * 0.32f) + 490000;
            }
            else
            {
                annualIncomeTax = ((annualGrossPay - 8000000) * 0.35f) + 2410000;
            }

            return annualIncomeTax;
        }

    }
}