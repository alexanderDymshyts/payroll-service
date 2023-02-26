using Payroll_Service.Classes;
using Payroll_Service.Interfaces;

namespace Payroll_Service.Factories;

public class PayrollFactory: IPayrollFactory
{
    #region Variables

    private readonly GermanyTax _germanyTax;
    private readonly ItalyTax _italyTax;
    private readonly SpainTax _spainTax;

    #endregion Variables

    #region Constructors

    public PayrollFactory()
    {
        _germanyTax = new GermanyTax();
        _italyTax = new ItalyTax();
        _spainTax = new SpainTax();
    }

    #endregion Constructors
    
    #region Methods

    /// <summary>
    /// Get payroll.
    /// </summary>
    /// <param name="isoCode">Country ISO code.</param>
    /// <returns>Corresponding payroll item.</returns>
    public IPayroll? GetPayroll(string isoCode)
    {
        if (string.IsNullOrEmpty(isoCode))
            return null;
        
        switch (isoCode.ToLower())
        {
            case "de":
                return _germanyTax;
            case "it":
                return _italyTax;
            case "es":
                return _spainTax;
            default:
                return null;
        }
    }

    #endregion Methods
}