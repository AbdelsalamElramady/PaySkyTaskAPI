using System.ComponentModel.DataAnnotations;

namespace PaySkyTaskAPI.Models.Payment
{
    public class PayRequest
    {
        [Required]
        public string? ProcessingCode { get; set; }
        [Required]
        public string? SystemTraceNr { get; set; }
        [Required]
        public string? FunctionCode { get; set; }
        [Required]
        public string? CardNo { get; set; }
        [Required]
        public string? CardHolder { get; set; }
        [Required]
        public string? AmountTrxn { get; set; }
        [Required]
        public string? CurrencyCode { get; set; }
    }
}
