using System.Collections.Generic;

namespace MpesaService.ServiceModels
{
    public class B2CModel
    {
        public string InitiatorName { get; set; }
        public string SecurityCredential { get; set; }
        public string CommandID { get; set; }
        public string Amount { get; set; }
        public string PartyA { get; set; }
        public string PartyB { get; set; }
        public string Remarks { get; set; }
        public string QueueTimeOutURL { get; set; }
        public string ResultURL { get; set; }
        public string Occassion { get; set; }
    }
    public class B2CModelResponse
    {
        public string ConversationID { get; set; }
        public string OriginatorConversationID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
    }
    public class ResultParameter
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }

    public class ResultParameters
    {
        public List<ResultParameter> ResultParameter { get; set; }
    }

    public class ReferenceItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class ReferenceData
    {
        public ReferenceItem ReferenceItem { get; set; }
    }

    public class Result
    {
        public int ResultType { get; set; }
        public int ResultCode { get; set; }
        public string ResultDesc { get; set; }
        public string OriginatorConversationID { get; set; }
        public string ConversationID { get; set; }
        public string TransactionID { get; set; }
        public ResultParameters ResultParameters { get; set; }
        public ReferenceData ReferenceData { get; set; }
    }

    public class B2CURLResponse
    {
        public Result Result { get; set; }
    }
}
