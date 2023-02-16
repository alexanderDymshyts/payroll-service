namespace Payroll_Service.Extensions;

public static class TaxExtensions
{
    #region Methods

    /// <summary>
    /// Get progressive tax.
    /// </summary>
    /// <param name="salary">Gross salary.</param>
    /// <param name="taxBorder">Tax border.</param>
    /// <param name="lowerTaxPercentage">Lower tax percentage.</param>
    /// <param name="higherTaxPercentage">Greater tax percentage.</param>
    /// <returns>Progressive tax.</returns>
    public static decimal GetProgressiveTax(this decimal salary, decimal taxBorder, byte lowerTaxPercentage, byte higherTaxPercentage)
    {
        decimal lowerValue = decimal.Divide(lowerTaxPercentage, 100);
        decimal higherValue = decimal.Divide(higherTaxPercentage, 100);
            
        return salary < taxBorder ? 
            decimal.Multiply(salary, lowerValue) : 
            decimal.Add(decimal.Multiply(taxBorder, lowerValue), decimal.Multiply(decimal.Subtract(salary, taxBorder), higherValue));
    }
    
    /// <summary>
    /// Get pension contribution.
    /// </summary>
    /// <param name="salary">Salary.</param>
    /// <param name="percentage">Defines percentage to pay for pension.</param>
    /// <returns>Pension contribution.</returns>
    public static decimal GetPensionContribution(this decimal salary, byte percentage)
    {
        decimal value = decimal.Divide(percentage, 100);
        return decimal.Multiply(salary, value);
    }
   
    #endregion Methods
}