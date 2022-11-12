namespace PaySkyTaskAPI.Models.Payment
{
    public class PayResponse
    {
        public PayResponse(string? message = "Failed", string? responseCode = null, string? approvalCode = null)
        {
            this.DateTime = System.DateTime.Now.ToString("yyyyMMddHHmm");
            this.Message = message;
            this.ApprovalCode = approvalCode;
            this.ResponseCode = responseCode;
        }

        public string? ResponseCode { get; set; }
        public string? Message { get; set; }
        public string? ApprovalCode { get; set; }
        public string DateTime { get; set; }
    }
}
