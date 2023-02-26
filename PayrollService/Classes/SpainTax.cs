namespace Payroll_Service.Classes;

public class SpainTax: TaxBase, Interfaces.IPayroll
{
    #region Methods

    /// <inheritdoc cref="Interfaces.IPayroll.GetTaxDeductions"/>
    public decimal GetTaxDeductions(decimal grossSalary)
    {
        if (grossSalary < 0)
            return 0;
        
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
        return GetProgressiveTax(salary, 500m, 7, 8);
    }

    #endregion Methods
}