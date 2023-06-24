using Common.Enums;
using Common.Response;

namespace Blazor.Models
{
    public class RequestState
    {
        public ResponseStatus Status { get; set; }
        public string? Message { get; set; }
        public string? Detail { get; set; }
        public bool IsWaiting => Status == ResponseStatus.Waiting;
        public RequestState(ResponseStatus status)
        {
            Status = status;
        }
        public RequestState(ResponseStatus status, string message) : this(status)
        {
            Message = message;
        }

        public void SetResponse(RequestResponse response)
        {
            Status = response.Status;
            Message = response.Message;
            Detail = response.Detail;
        }
    }
}