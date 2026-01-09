using API.Controllers;

namespace API.Errors
{
    public class APIErrorResponse (int status, string message, string? details)
    {
        public int StatusCode { get; set; } = status;
        public string Message { get; set; } = message;
        public string? Details { get; set; } = details;
    }
}
