using Payroll_Service.Models.Dto.Incoming;
using Payroll_Service.Models.Dto.Outcoming;

namespace Payroll_Service.Services;

public class PayrollService: Interfaces.IPayrollService
{
    #region Variables

    private readonly Interfaces.IPayrollFactory _payrollFactory;

    #endregion Variables

    #region Constructors

    public PayrollService(Interfaces.IPayrollFactory payrollFactory)
    {
        _payrollFactory = payrollFactory;
    }

    #endregion Constructors
    
    #region Methods

    /// <summary>
    /// Get payroll for selected country.
    /// </summary>
    /// <param name="countryCode">Selected country ISO code.</param>
    /// <param name="data">Input model - hours worked and hourly rate.</param>
    /// <returns>Calculated payroll.</returns>
    public PayrollResponse? GetPayroll(string countryCode, PayrollRequest data)
    {
        var payroll = _payrollFactory.GetPayroll(countryCode);
        if (payroll == null)
            return null;
        
        var result = new PayrollResponse
        {
            CountryCode = countryCode.ToUpperInvariant(),
            GrossSalary = payroll.GetGrossSalary(data.HoursWorked, data.HourlyRate)
        };

        result.TaxesDeductions = payroll.GetTaxDeductions(result.GrossSalary);
        result.NetSalary = payroll.GetNetSalary(result.GrossSalary, result.TaxesDeductions);

        return result;
    }

    #endregion Methods
}