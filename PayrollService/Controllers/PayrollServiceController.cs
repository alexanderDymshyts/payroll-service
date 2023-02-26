using Microsoft.AspNetCore.Mvc;
using Payroll_Service.Interfaces;
using Payroll_Service.Models.Dto.Incoming;
using Payroll_Service.Models.Dto.Outcoming;

namespace Payroll_Service.Controllers;

[ApiController]
[Route("[controller]")]
public class PayrollServiceController : ControllerBase
{
    #region Variables

    private readonly IPayrollService _payrollService;

    #endregion Variables

    #region Construtors

    public PayrollServiceController(IPayrollService payrollService)
    {
        _payrollService = payrollService;
    }

    #endregion Constructors
    
    #region Methods

    [HttpPost]
    [Route("{countryCode}")]
    public ActionResult<PayrollResponse> CalculatePayroll(string countryCode, [FromBody] PayrollRequest data)
    {
        if (string.IsNullOrEmpty(countryCode))
            return new BadRequestObjectResult("ISO code not provided.");
        
        var result = _payrollService.GetPayroll(countryCode, data);

        if (null == result)
            return new BadRequestObjectResult("Ups, something went wrong...");
        
        return new OkObjectResult(result);
    }

    #endregion Methods
    
}