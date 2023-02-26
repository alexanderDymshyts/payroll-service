namespace Payroll_Service.Classes;

public abstract class TaxBase
{
    #region Methods

    /// <summary>
    /// Get progressive tax.
    /// </summary>
    /// <param name="salary">Gross salary.</param>
    /// <param name="taxBoundary">Tax boundary for progressive taxes.</param>
    /// <param name="lowerTaxPercentage">Lower tax percentage.</param>
    /// <param name="higherTaxPercentage">Greater tax percentage.</param>
    /// <returns>Progressive tax.</returns>
    public virtual decimal GetProgressiveTax(decimal salary, decimal taxBoundary, byte lowerTaxPercentage, byte higherTaxPercentage)
    {
        if (salary < 0)
            return 0;
        
        // Possible loss of fraction, that's why decimal.Divide is used.
        decimal lowerValue = decimal.Divide(lowerTaxPercentage, 100);
        decimal higherValue = decimal.Divide(higherTaxPercentage, 100);
            
        return salary < taxBoundary ? 
            salary * lowerValue : 
            taxBoundary * lowerValue + (salary - taxBoundary) * higherValue;
    }
    
    /// <summary>
    /// Get pension contribution.
    /// </summary>
    /// <param name="salary">Salary.</param>
    /// <param name="percentage">Defines percentage to pay for pension.</param>
    /// <returns>Pension contribution.</returns>
    public virtual decimal GetPensionContribution(decimal salary, byte percentage)
    {
        if (salary < 0)
            return 0;
        
        // Possible loss of fraction, that's why decimal.Divide is used.
        return salary * decimal.Divide(percentage, 100);
    }
   
    #endregion Methods
}