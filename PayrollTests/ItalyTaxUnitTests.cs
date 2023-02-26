using NUnit.Framework;
using Payroll_Service.Classes;

namespace Payroll_Tests;

[TestFixture]
public class ItalyTaxUnitTests
{
    #region Variables

    private ItalyTax? _italyTax;

    #endregion Variables

    #region SetUp

    [SetUp]
    public void Setup()
    {
        _italyTax = new ItalyTax();
    }

    #endregion SetUp

    #region Tests

    [Test]
    public void GetTaxDeductions_Salary_Is_Zero()
    {
        var expected = 0;

        var actual = _italyTax?.GetTaxDeductions(0);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Is_Negative()
    {
        var expected = 0;

        var actual = _italyTax?.GetTaxDeductions(-10);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Is_Positive()
    {
        var expected = 318.925m;

        var actual = _italyTax?.GetTaxDeductions(1000);
        
        Assert.AreEqual(expected, actual);
    }
    
    #endregion Tests
}