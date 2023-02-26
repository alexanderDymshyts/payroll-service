using Payroll_Service.Models.Dto.Incoming;
using Payroll_Service.Models.Dto.Outcoming;

namespace Payroll_Service.Interfaces;

public interface IPayrollService
{
    #region Methods

    PayrollResponse? GetPayroll(string countryCode, PayrollRequest data);

    #endregion Methods
}