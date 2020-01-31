namespace MpesaService.ServiceModels
{
    public class RegisterUrl
    {
        public string ShortCode { get; set; }
        public string ResponseType { get; set; }
        public string ConfirmationURL { get; set; }
        public string ValidationURL { get; set; }
    }
    public class RegisterUrlResponse
    {
        public string ConversationID { get; set; }
        public string OriginatorCoversationID { get; set; }
        public string ResponseDescription { get; set; }
    }
}
