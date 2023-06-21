using Common.Enums;

namespace Common.Response
{
    public class RequestResponseData<T> : RequestResponse
    {
        public T? Model { get; set; }
        public RequestResponseData() { }
        public RequestResponseData(ResponseStatus status, T? model) : base(status)
        {
            Model = model;
        }
        public RequestResponseData(ResponseStatus status, string message) : base(status, message) { }
    }
}