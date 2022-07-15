namespace FinalProject.TaxCalculators
{
    class HealthInsuranceCalculator : TaxCalculator
    {
        public override float TaxCalculate(float grossPay)
        {
            float HealthInsurance = 0;
            float rate = 0.035f;

            HealthInsurance = grossPay * rate;

            return HealthInsurance;
        }
    }
}