using System;
using NUnit.Framework;
using Payroll_Service.Classes;
using Payroll_Service.Factories;

namespace Payroll_Tests;

[TestFixture]
public class PayrollFactoryUnitTests
{
    #region Variables

    private PayrollFactory _payrollFactory;

    #endregion Variables

    #region SetUp

    [SetUp]
    public void Setup()
    {
        _payrollFactory = new PayrollFactory();
    }

    #endregion SetUp

    #region Tests

    [Test]
    [TestCase("de", typeof(GermanyTax))]
    [TestCase("DE", typeof(GermanyTax))]
    [TestCase("dE", typeof(GermanyTax))]
    [TestCase("it", typeof(ItalyTax))]
    [TestCase("IT", typeof(ItalyTax))]
    [TestCase("iT", typeof(ItalyTax))]
    [TestCase("ES", typeof(SpainTax))]
    [TestCase("es", typeof(SpainTax))]
    [TestCase("Es", typeof(SpainTax))]
    public void PayrollFactory_Should_Return_Payroll(string countyCode, Type expectedType)
    {
        var result = _payrollFactory.GetPayroll(countyCode);
        Assert.NotNull(result);
        var actualType = result.GetType();
        Assert.AreEqual(expectedType, actualType);
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    [TestCase("wrongISO")]
    public void PayrollFactory_Should_Return_Null(string countryCode)
    {
        Assert.Null(_payrollFactory.GetPayroll(countryCode));
    }

    #endregion Tests
}