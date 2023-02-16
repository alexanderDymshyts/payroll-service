using Payroll_Service.Extensions;

namespace Payroll_Service.Classes;

public class SpainTaxes: Interfaces.IPayroll
{
    #region Methods

    /// <inheritdoc cref="Interfaces.IPayroll.GetTaxDedunctions"/>
    public decimal GetTaxDedunctions(decimal grossSalary)
    {
        decimal result = grossSalary.GetProgressiveTax(600,  25, 40);
        result = decimal.Add(result, GetSocialCharge(decimal.Subtract(grossSalary, result))); 

        return decimal.Add(result, decimal.Subtract(grossSalary, result).GetPensionContribution(4));
    }

    /// <summary>
    /// Get social charge tax.
    /// </summary>
    /// <param name="salary">Salary.</param>
    /// <returns>Social charge tax.</returns>
    private decimal GetSocialCharge(decimal salary)
    {
        return salary < 500m ? 
            decimal.Multiply(salary, 0.07m) : 
            decimal.Add(decimal.Multiply(500m, 0.07m), decimal.Multiply(decimal.Subtract(salary, 500m), 0.08m));
    }

    #endregion Methods
}