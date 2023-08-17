namespace Fetch
{
    public class WebResult<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Error { get; set; }

        public WebResult(T? data, bool success, string? error = null)
        {
            Data = data;
            Success = success;
            Error = error;
        }
    }
}