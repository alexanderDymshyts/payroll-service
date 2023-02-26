using NUnit.Framework;
using Payroll_Service.Classes;

namespace Payroll_Tests;

[TestFixture]
public class GermanyTaxUnitTests
{
    #region Variables

    private GermanyTax? _germanyTax;
    private readonly decimal _taxBorder = 400m;
    private readonly byte _lowerTaxPercentage = 25;
    private readonly byte _higherTaxPercentage = 32;
    private readonly byte _pensionContributionPercentage = 2;

    #endregion Variables

    #region SetUp

    [SetUp]
    public void Setup()
    {
        _germanyTax = new GermanyTax();
    }

    #endregion SetUp

    #region Tests

    [Test]
    public void GetProgressiveTax_Salary_Less_Than_Boundary()
    {
        var expected = 25m;
        var actual = _germanyTax?.GetProgressiveTax(100, _taxBorder, _lowerTaxPercentage , _higherTaxPercentage);
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetProgressiveTax_Salary_Higher_Than_Boundary()
    {
        decimal expected = 292m;
        var actual = _germanyTax?.GetProgressiveTax(1000, _taxBorder, _lowerTaxPercentage , _higherTaxPercentage);
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetProgressiveTax_Salary_Is_Zero()
    {
        decimal expected = 0;
        var actual = _germanyTax?.GetProgressiveTax(0, _taxBorder, _lowerTaxPercentage , _higherTaxPercentage);
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetProgressiveTax_Salary_Is_Negative()
    {
        decimal expected = 0;
        var actual = _germanyTax?.GetProgressiveTax(-100, _taxBorder, _lowerTaxPercentage , _higherTaxPercentage);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetPensionContribution_Salary_Is_Zero()
    {
        decimal expected = 0;
        var actual = _germanyTax?.GetPensionContribution(0, _pensionContributionPercentage);
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetPensionContribution_Salary_Is_Negative()
    {
        decimal expected = 0;
        var actual = _germanyTax?.GetPensionContribution(-10, _pensionContributionPercentage);
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetPensionContribution_Salary_Is_Positive()
    {
        decimal expected = 2m;
        var actual = _germanyTax?.GetPensionContribution(100, _pensionContributionPercentage);
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Less_Than_Boundary()
    {
        var actual = _germanyTax?.GetTaxDeductions(100);
        decimal expected = 26.5m;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Higher_Than_Boundary()
    {
        var actual = _germanyTax?.GetTaxDeductions(1000);
        decimal expected = 306.16m;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Is_Zero()
    {
        var actual = _germanyTax?.GetTaxDeductions(0);
        decimal expected = 0;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Is_Negative()
    {
        var actual = _germanyTax?.GetTaxDeductions(-10);
        decimal expected = 0;
        Assert.AreEqual(expected, actual);
    }
   
    #endregion Tests
}