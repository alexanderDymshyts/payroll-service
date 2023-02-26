using Moq;
using NUnit.Framework;
using Payroll_Service.Classes;
using Payroll_Service.Interfaces;
using Payroll_Service.Models.Dto.Incoming;
using Payroll_Service.Models.Dto.Outcoming;
using Payroll_Service.Services;

namespace Payroll_Tests;

[TestFixture]
public class PayrollServiceUnitTests
{
    #region Variables

    private PayrollService? _payrollService;
    private readonly PayrollRequest _payrollRequest = new PayrollRequest
    {
        HoursWorked = 10,
        HourlyRate = 100
    };
    private Mock<IPayrollFactory> _payrollFactoryMock;

    #endregion Variables

    #region SetUp

    [SetUp]
    public void Setup()
    {
        _payrollFactoryMock = new Mock<IPayrollFactory>();
    }

    #endregion SetUp

    #region Tests

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("bla")]
    public void GetPayroll_Returns_Null_On_Wrong_Iso(string wrongIso)
    {
        _payrollFactoryMock.Setup(x => x.GetPayroll(wrongIso)).Returns((IPayroll?)null);

        _payrollService = new PayrollService(_payrollFactoryMock.Object);

        var actual = _payrollService.GetPayroll(wrongIso, _payrollRequest);
        
        Assert.Null(actual);
    }
    
    [Test]
    [TestCase("de")]
    [TestCase("dE")]
    [TestCase("De")]
    [TestCase("DE")]
    public void GetPayroll_Returns_PayrollResponse_With_CorrectData(string countryCode)
    {
        _payrollFactoryMock.Setup(x => x.GetPayroll(countryCode)).Returns(new GermanyTax());

        _payrollService = new PayrollService(_payrollFactoryMock.Object);

        var expected = new PayrollResponse
        {
            CountryCode = "DE",
            GrossSalary = 1000m,
            TaxesDeductions = 306.16m,
            NetSalary = 693.84m
        };

        var actual = _payrollService.GetPayroll(countryCode, _payrollRequest);
        
        
        Assert.NotNull(actual);
        
        Assert.AreEqual(expected.CountryCode, actual.CountryCode);
        Assert.AreEqual(expected.GrossSalary, actual.GrossSalary);
        Assert.AreEqual(expected.TaxesDeductions, actual.TaxesDeductions);
        Assert.AreEqual(expected.NetSalary, actual.NetSalary);
    }
    
    [Test]
    public void GetPayroll_Returns_PayrollResponse_With_Zero_Values_In_Request()
    {
        _payrollFactoryMock.Setup(x => x.GetPayroll("de")).Returns(new GermanyTax());

        _payrollService = new PayrollService(_payrollFactoryMock.Object);

        var zeroRequest = new PayrollRequest
        {
            HoursWorked = 0, HourlyRate = 0
        };

        var expected = new PayrollResponse
        {
            CountryCode = "DE",
            GrossSalary = 0,
            TaxesDeductions = 0,
            NetSalary = 0
        };

        var actual = _payrollService.GetPayroll("de", zeroRequest);
        
        Assert.NotNull(actual);
        
        Assert.AreEqual(expected.CountryCode, actual.CountryCode);
        Assert.AreEqual(expected.GrossSalary, actual.GrossSalary);
        Assert.AreEqual(expected.TaxesDeductions, actual.TaxesDeductions);
        Assert.AreEqual(expected.NetSalary, actual.NetSalary);
    }

    [Test]
    public void GetPayroll_Returns_PayrollResponse_With_Negative_Values_In_Request()
    {
        _payrollFactoryMock.Setup(x => x.GetPayroll("de")).Returns(new GermanyTax());

        _payrollService = new PayrollService(_payrollFactoryMock.Object);

        var negativeRequest = new PayrollRequest
        {
            HoursWorked = -10, HourlyRate = -10
        };

        var expected = new PayrollResponse
        {
            CountryCode = "DE",
            GrossSalary = 0,
            TaxesDeductions = 0,
            NetSalary = 0
        };

        var actual = _payrollService.GetPayroll("de", negativeRequest);
        
        Assert.NotNull(actual);
        
        Assert.AreEqual(expected.CountryCode, actual.CountryCode);
        Assert.AreEqual(expected.GrossSalary, actual.GrossSalary);
        Assert.AreEqual(expected.TaxesDeductions, actual.TaxesDeductions);
        Assert.AreEqual(expected.NetSalary, actual.NetSalary);
    }
    
    #endregion Tests
}