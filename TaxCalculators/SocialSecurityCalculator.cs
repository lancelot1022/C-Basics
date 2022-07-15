namespace FinalProject.TaxCalculators
{
    class SocialSecurityCalculator : TaxCalculator
    {
        public override float TaxCalculate(float grossPay)
        {
            float SocialSecurity = 0;
            float rate = 0.04f;

            SocialSecurity = grossPay * rate;

            return SocialSecurity;
        }
    }
}