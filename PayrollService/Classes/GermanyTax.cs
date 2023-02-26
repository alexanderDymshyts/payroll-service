namespace Payroll_Service.Classes;

public class GermanyTax: TaxBase, Interfaces.IPayroll
{
    #region Methods

    /// <inheritdoc cref="Interfaces.IPayroll.GetTaxDedunctions"/>
    public decimal GetTaxDedunctions(decimal grossSalary)
    {
        decimal progressiveTax = GetProgressiveTax(grossSalary,400, 25, 32);
        decimal pensionTax = GetPensionContribution(grossSalary - progressiveTax,2);
        return progressiveTax + pensionTax;
    }

    #endregion Methods
}