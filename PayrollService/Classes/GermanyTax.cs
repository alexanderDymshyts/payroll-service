namespace Payroll_Service.Classes;

public class GermanyTax: TaxBase, Interfaces.IPayroll
{
    #region Methods

    /// <inheritdoc cref="Interfaces.IPayroll.GetTaxDeductions"/>
    public decimal GetTaxDeductions(decimal grossSalary)
    {
        if (grossSalary < 0)
            return 0;
        
        decimal progressiveTax = GetProgressiveTax(grossSalary,400, 25, 32);
        decimal pensionTax = GetPensionContribution(grossSalary - progressiveTax,2);
        return progressiveTax + pensionTax;
    }

    #endregion Methods
}