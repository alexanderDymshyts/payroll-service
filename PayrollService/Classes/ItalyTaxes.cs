namespace Payroll_Service.Classes;

public class ItalyTaxes: Interfaces.IPayroll
{
    #region Methods

    /// <inheritdoc cref="Interfaces.IPayroll.GetTaxDedunctions"/>
    public decimal GetTaxDedunctions(decimal grossSalary)
    {
        decimal result = decimal.Multiply(grossSalary, 0.25m);
        return decimal.Add(result, decimal.Multiply(decimal.Subtract(grossSalary, result), 0.0919m));
    }

    #endregion Methods
}