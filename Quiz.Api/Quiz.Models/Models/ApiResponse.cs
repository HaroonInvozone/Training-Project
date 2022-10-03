using System.Net;

namespace QuizApp.Model.Models
{
    public class ApiResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode Status { get; set; }
        public T? Content { get; set; }
    }
}
