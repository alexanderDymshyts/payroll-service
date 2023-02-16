namespace Payroll_Service.Interfaces;

public interface IPayrollFactory
{
    #region Methods

    IPayroll? GetPayroll(string isoCode);

    #endregion Methods
}