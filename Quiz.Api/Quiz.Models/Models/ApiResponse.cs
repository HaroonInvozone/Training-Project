using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Models
{
    public class ApiResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode Status { get; set; }
        public T? Content { get; set; }
    }
}
