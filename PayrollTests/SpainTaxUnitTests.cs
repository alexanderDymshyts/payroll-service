using NUnit.Framework;
using Payroll_Service.Classes;

namespace Payroll_Tests;

[TestFixture]
public class SpainTaxUnitTests
{
    #region Variables

    private SpainTax? _spainTax;
    private readonly decimal _taxBorder = 600m;
    private readonly byte _lowerTaxPercentage = 25;
    private readonly byte _higherTaxPercentage = 40;
    private readonly byte _pensionContributionPercentage = 4;

    #endregion Variables

    #region SetUp

    [SetUp]
    public void Setup()
    {
        _spainTax = new SpainTax();
    }

    #endregion SetUp

    #region Tests
    
    [Test]
    public void GetProgressiveTax_Salary_Less_Than_Boundary()
    {
        var expected = 25m;
        
        var actual = _spainTax?.GetProgressiveTax(100, _taxBorder, _lowerTaxPercentage , _higherTaxPercentage);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetProgressiveTax_Salary_Higher_Than_Boundary()
    {
        decimal expected = 310m;
        
        var actual = _spainTax?.GetProgressiveTax(1000, _taxBorder, _lowerTaxPercentage , _higherTaxPercentage);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetProgressiveTax_Salary_Is_Zero()
    {
        decimal expected = 0;
        
        var actual = _spainTax?.GetProgressiveTax(0, _taxBorder, _lowerTaxPercentage , _higherTaxPercentage);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetProgressiveTax_Salary_Is_Negative()
    {
        decimal expected = 0;
        
        var actual = _spainTax?.GetProgressiveTax(-100, _taxBorder, _lowerTaxPercentage , _higherTaxPercentage);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetPensionContribution_Salary_Is_Zero()
    {
        decimal expected = 0;
        
        var actual = _spainTax?.GetPensionContribution(0, _pensionContributionPercentage);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetPensionContribution_Salary_Is_Negative()
    {
        decimal expected = 0;
        
        var actual = _spainTax?.GetPensionContribution(-10, _pensionContributionPercentage);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetPensionContribution_Salary_Is_Positive()
    {
        decimal expected = 4m;
        
        var actual = _spainTax?.GetPensionContribution(100, _pensionContributionPercentage);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Less_Than_Boundary()
    {
        decimal expected = 33.04m;
        
        var actual = _spainTax?.GetTaxDeductions(100);
        
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Higher_Than_Boundary()
    {
        decimal expected = 385.792m;
        
        var actual = _spainTax?.GetTaxDeductions(1000);
       
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Is_Zero()
    {
        var actual = _spainTax?.GetTaxDeductions(0);
        decimal expected = 0;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void GetTaxDeductions_Salary_Is_Negative()
    {
        var actual = _spainTax?.GetTaxDeductions(-10);
        decimal expected = 0;
        Assert.AreEqual(expected, actual);
    }
    
    #endregion Tests
}