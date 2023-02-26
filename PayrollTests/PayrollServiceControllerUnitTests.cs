using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Payroll_Service.Controllers;
using Payroll_Service.Interfaces;
using Payroll_Service.Models.Dto.Incoming;
using Payroll_Service.Models.Dto.Outcoming;

namespace Payroll_Tests;

[TestFixture]
public class PayrollServiceControllerUnitTests
{
    #region Variables

    
    private Mock<IPayrollService> _payrollServiceMock;
    private PayrollServiceController _controller;
    
    #endregion Variables

    #region SetUp

    [SetUp]
    public void Setup()
    {
        _payrollServiceMock = new Mock<IPayrollService>();
    }

    #endregion SetUp

    #region Tests

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public void PayrollServiceController_Wrong_CountryCode(string countryCode)
    {
        _controller = new PayrollServiceController(_payrollServiceMock.Object);

        var actual = _controller.CalculatePayroll(countryCode, null);
        
        Assert.IsInstanceOf<BadRequestObjectResult>(actual.Result);

        var actualAsResult = (BadRequestObjectResult)actual.Result;
        
        Assert.AreEqual("ISO code not provided.", actualAsResult.Value);
        Assert.AreEqual(400, actualAsResult.StatusCode);
    }
    
    [Test]
    public void PayrollServiceController_Error_In_GetPayroll()
    {
        _payrollServiceMock.Setup(x => x.GetPayroll("de", null)).Returns((PayrollResponse?)null);
        _controller = new PayrollServiceController(_payrollServiceMock.Object);

        var actual = _controller.CalculatePayroll("de", null);
      
        Assert.IsInstanceOf<BadRequestObjectResult>(actual.Result);

        var actualAsResult = (BadRequestObjectResult)actual.Result;
        
        Assert.AreEqual("Ups, something went wrong...", actualAsResult.Value);
        Assert.AreEqual(400, actualAsResult.StatusCode);
    }
    
    [Test]
    public void PayrollServiceController_Ok_Result()
    {
        var response = new PayrollResponse
        {
            CountryCode = "DE",
            GrossSalary = 1000m,
            TaxesDeductions = 306.16m,
            NetSalary = 693.84m
        };
        
        var request = new PayrollRequest { HoursWorked = 10, HourlyRate = 10};
        
        _payrollServiceMock.Setup(x => x.GetPayroll("de", request)).Returns(response);
        _controller = new PayrollServiceController(_payrollServiceMock.Object);

        var actual = _controller.CalculatePayroll("de", request);
      
        Assert.IsInstanceOf<OkObjectResult>(actual.Result);

        var actualAsResult = (OkObjectResult)actual.Result;
        
        Assert.AreEqual(response, actualAsResult.Value);
        Assert.AreEqual(200, actualAsResult.StatusCode);
    }

    #endregion Tests
}