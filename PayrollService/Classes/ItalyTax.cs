namespace Payroll_Service.Classes;

public class ItalyTax: TaxBase, Interfaces.IPayroll
{
    #region Methods

    /// <inheritdoc cref="Interfaces.IPayroll.GetTaxDedunctions"/>
    public decimal GetTaxDedunctions(decimal grossSalary)
    {
        decimal incomeTax = grossSalary * 0.25m;
        decimal inpsTax = (grossSalary - incomeTax) * 0.0919m;
        return incomeTax + inpsTax;
    }
    
    #endregion Methods
}