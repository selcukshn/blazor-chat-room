using Common.Enums;

namespace Common.Response
{
    public class RequestResponse : Response
    {
        public ResponseStatus Status { get; set; }
        public bool IsSuccess => Status == ResponseStatus.Success ? true : false;
        public string? Detail { get; set; }
        public RequestResponse() { }

        public RequestResponse(ResponseStatus status)
        {
            Status = status;
        }
        public RequestResponse(ResponseStatus status, string message) : base(message)
        {
            Status = status;
            Message = message;
        }

    }
}