using System.ComponentModel.DataAnnotations;

namespace PaySkyTaskAPI.Models.Payment
{
    public class PayRequest
    {
        [Required]
        public int? ProcessingCode { get; set; }
        [Required]
        public int? SystemTraceNr { get; set; }
        [Required]
        public int? FunctionCode { get; set; }
        [Required]
        public long? CardNo { get; set; }
        [Required]
        public string? CardHolder { get; set; }
        [Required]
        public int? AmountTrxn { get; set; }
        [Required]
        public int? CurrencyCode { get; set; }
    }
}
