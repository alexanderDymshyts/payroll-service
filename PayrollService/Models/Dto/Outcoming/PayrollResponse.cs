using System.Text.Json.Serialization;

namespace Payroll_Service.Models.Dto.Outcoming;

public class PayrollResponse
{
    #region Properties

    [JsonPropertyName("countryCode")] 
    public string CountryCode { get; set; } = string.Empty;
    
    [JsonPropertyName("grossSalary")] 
    public decimal GrossSalary { get; set; }
    
    [JsonPropertyName("taxesDeductions")] 
    public decimal TaxesDeductions { get; set; }
    
    [JsonPropertyName("netSalary")] 
    public decimal NetSalary { get; set; }

    #endregion Properties
}