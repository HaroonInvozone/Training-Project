
using System.Net;

namespace InvoPassport.Model.Models
{
    public class ApiResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode Status { get; set; }
        public T? Content { get; set; }
    }
}
