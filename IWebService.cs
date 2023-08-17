namespace Fetch
{
    public interface IWebService<T>
    {
        Task<WebResult<T>> FetchData(string endpoint);
    }
}