using Payroll_Service.Classes;
using Payroll_Service.Interfaces;

namespace Payroll_Service.Factories;

public class TaxFactory: IPayrollFactory
{
    #region Variables

    private readonly GermanyTaxes _germanyTaxes;
    private readonly ItalyTaxes _italyTaxes;
    private readonly SpainTaxes _spainTaxes;

    #endregion Variables

    #region Constructors

    public TaxFactory()
    {
        _germanyTaxes = new GermanyTaxes();
        _italyTaxes = new ItalyTaxes();
        _spainTaxes = new SpainTaxes();
    }

    #endregion Constructors
    
    #region Methods

    public IPayroll? GetPayroll(string isoCode)
    {
        string lower = isoCode.ToLower();
        switch (lower)
        {
            case "de":
                return _germanyTaxes;
            case "it":
                return _italyTaxes;
            case "es":
                return _spainTaxes;
        }

        return null;
    }

    #endregion Methods
}