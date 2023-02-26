namespace Payroll_Service.Models.Dto.Incoming;

public class PayrollRequest
{
    #region Properties

    /// <summary>
    /// Describes hours that worker has worked.
    /// </summary>
    public double HoursWorked { get; set; }
    
    /// <summary>
    /// Describes salary per hour.
    /// </summary>
    public decimal HourlyRate { get; set; }

    #endregion Proeprties
}