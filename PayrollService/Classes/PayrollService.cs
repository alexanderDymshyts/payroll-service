using Payroll_Service.Factories;
using Payroll_Service.Models.Dto.Incoming;
using Payroll_Service.Models.Dto.Outcoming;

namespace Payroll_Service.Classes;

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

    public PayrollResponse? GetPayroll(PayrollRequest data)
    {
        var payroll = _payrollFactory.GetPayroll(data.CountryCode);
        if (payroll == null)
            return null;
        
        var result = new PayrollResponse
        {
            CountryCode = data.CountryCode,
            GrossSalary = payroll.GetGrossSalary(data.HoursWorked, data.HourlyRate)
        };

        result.TaxesDeductions = payroll.GetTaxDedunctions(result.GrossSalary);
        result.NetSalary = payroll.GetNetSalary(result.GrossSalary, result.TaxesDeductions);

        return result;
    }

    #endregion Methods
}