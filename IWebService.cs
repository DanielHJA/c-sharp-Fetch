namespace Fetch
{
    public interface IWebService
    {
        Task<Result> FetchData(string endpoint);
    }
}