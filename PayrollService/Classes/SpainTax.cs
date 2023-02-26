namespace Payroll_Service.Classes;

public class SpainTax: TaxBase, Interfaces.IPayroll
{
    #region Methods

    /// <inheritdoc cref="Interfaces.IPayroll.GetTaxDedunctions"/>
    public decimal GetTaxDedunctions(decimal grossSalary)
    {
        decimal progressiveTax = GetProgressiveTax(grossSalary,600,  25, 40);
        decimal universalSocialChargeTax = GetUniversalSocialCharge(grossSalary - progressiveTax);
        decimal compulsoryPensionTax = GetPensionContribution(grossSalary - progressiveTax - universalSocialChargeTax, 4);
            
        return progressiveTax + universalSocialChargeTax + compulsoryPensionTax;
    }

    /// <summary>
    /// Get social charge tax.
    /// </summary>
    /// <param name="salary">Salary.</param>
    /// <returns>Social charge tax.</returns>
    private decimal GetUniversalSocialCharge(decimal salary)
    {
        return salary < 500m ? 
            salary * 0.07m : 
            500m * 0.07m + (salary - 500m) * 0.08m;
    }

    #endregion Methods
}