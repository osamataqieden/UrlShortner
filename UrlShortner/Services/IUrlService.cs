namespace UrlShortner.Services
{
    public interface IUrlService
    {
        bool isExist(string ShortID, string LongURL);
        string GetShortUrl(string url);
        bool DeleteUrl(string ShortID);
        string GetLongUrl(string ShortID);
        Models.Url AddUrl(string url);
        List<Models.Url> GetAllUrls();
        List<Models.Url> GetPagedUrls(int page, int pageSize);
    }
}
