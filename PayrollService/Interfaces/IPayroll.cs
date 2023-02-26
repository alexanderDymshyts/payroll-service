namespace Payroll_Service.Interfaces;

public interface IPayroll
{
    #region Methods

    /// <summary>
    /// Get gross salary.
    /// </summary>
    /// <param name="hoursWorked">Hours worked.</param>
    /// <param name="hourlyRate">Hourly rate.</param>
    /// <returns>Gross salary.</returns>
    decimal GetGrossSalary(double hoursWorked, decimal hourlyRate)
    {
        if (hoursWorked <= 0 || hourlyRate <= 0)
            return 0;

        return (decimal)hoursWorked  * hourlyRate;
    }

    /// <summary>
    /// Get tax deductions.
    /// </summary>
    /// <param name="grossSalary">Gross salary.</param>
    /// <returns>Taxes.</returns>
    decimal GetTaxDeductions(decimal grossSalary);

    /// <summary>
    /// Get net salary.
    /// </summary>
    /// <param name="grossSalary">Gross salary.</param>
    /// <param name="taxDeductions">Taxes.</param>
    /// <returns>Salary.</returns>
    decimal GetNetSalary(decimal grossSalary, decimal taxDeductions) => grossSalary - taxDeductions;

    #endregion Methods
}