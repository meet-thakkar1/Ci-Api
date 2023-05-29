namespace CI_API.Common
{
    public class InternalResponses<T>
    {
        public T data { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}
