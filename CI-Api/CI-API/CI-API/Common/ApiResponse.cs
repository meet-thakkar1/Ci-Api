using Microsoft.AspNetCore.Mvc;

namespace CI_API.Common
{
    public class ApiResponse<T>
    {
        public T data { get; set; }
        public bool result { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
    }
}
