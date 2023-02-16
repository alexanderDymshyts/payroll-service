using Payroll_Service.Extensions;

namespace Payroll_Service.Classes;

public class GermanyTaxes: Interfaces.IPayroll
{
    #region Methods

    /// <inheritdoc cref="Interfaces.IPayroll.GetTaxDedunctions"/>
    public decimal GetTaxDedunctions(decimal grossSalary)
    {
        decimal result = grossSalary.GetProgressiveTax(400, 25, 32);
        return decimal.Add(result, decimal.Subtract(grossSalary, result).GetPensionContribution(2));
    }

    #endregion Methods
}