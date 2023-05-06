namespace FileDataRetrieval.Models
{
    public class Response
    {
        public Response() { }
        public Response(ResponseStatus responseStatus, string message)
        {
            Status = responseStatus;
            Messages = new List<string> { message };
        }
        public Response(ResponseStatus responseStatus, List<string> messages)
        {
            Status = responseStatus;
            Messages = messages;
        }
        public List<string> Messages { get; set; } = new List<string>();
        public ResponseStatus Status { get; set; } = ResponseStatus.Succeeded;
        public string GetMessages() => string.Join("\n", Messages);
    }

    public class Response<T> : Response
    {
        public T Result { get; set; }
        public Response(T result)
        {
            Result = result;
        }
        public Response(T result, ResponseStatus responseStatus, string message)
            : base(responseStatus, message)
        {
            Result = result;
        }
        public Response(T result, ResponseStatus responseStatus, List<string> messages)
            : base(responseStatus, messages)
        {
            Result = result;
        }
    }

    public enum ResponseStatus
    {
        Unauthorized,
        Succeeded,
        BadRequest,
        NotFound,
        Faild
    }
}
