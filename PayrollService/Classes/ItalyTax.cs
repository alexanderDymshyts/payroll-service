namespace Payroll_Service.Classes;

public class ItalyTax: TaxBase, Interfaces.IPayroll
{
    #region Methods

    /// <inheritdoc cref="Interfaces.IPayroll.GetTaxDeductions"/>
    public decimal GetTaxDeductions(decimal grossSalary)
    {
        if (grossSalary < 0)
            return 0;
        
        decimal incomeTax = grossSalary * 0.25m;
        decimal inpsTax = (grossSalary - incomeTax) * 0.0919m;
        
        return incomeTax + inpsTax;
    }
    
    #endregion Methods
}