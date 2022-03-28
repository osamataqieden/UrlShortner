namespace UrlShortner.Services
{
    public interface IUrlService
    {
        bool isExist(string ShortID, string LongURL);
        bool isExpired(string ShortID);
        string GetShortUrl(string url);
        bool DeleteUrl(string ShortID);
        string GetLongUrl(string ShortID);
        Models.Url AddUrl(string url);
        Models.Url AddUrl(string url, string DesiredShortID);
        bool UpdateURL(Models.Url URL);
        List<Models.Url> GetAllUrls();
        List<Models.Url> GetPagedUrls(int page, int pageSize);
    }
}
