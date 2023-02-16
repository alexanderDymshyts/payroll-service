namespace Payroll_Service.Models.Dto.Incoming;

public class PayrollRequest
{
    #region Properties

    public double HoursWorked { get; set; }
    
    public string CountryCode { get; set; } 
    
    public decimal HourlyRate { get; set; }

    #endregion Proeprties
}