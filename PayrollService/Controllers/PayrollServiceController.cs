using Microsoft.AspNetCore.Mvc;
using Payroll_Service.Classes;
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
    public ActionResult<PayrollResponse> CalculatePayroll([FromBody] PayrollRequest data)
    {
        if (string.IsNullOrEmpty(data.CountryCode))
            return new BadRequestObjectResult("ISO code not provided.");
        var result = _payrollService.GetPayroll(data);

        if (null == result)
            return new BadRequestObjectResult("Ups, something went wrong...");
        
        return new OkObjectResult(result);
    }

    #endregion Methods
    
}