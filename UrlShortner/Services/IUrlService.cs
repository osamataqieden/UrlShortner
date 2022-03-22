namespace UrlShortner.Services
{
    public interface IUrlService
    {
        bool isExist(string ShortID);
        bool isExpired(string ShortID);
        string GetShortUrl(string url);
        bool DeleteUrl(string ShortID);
        string GetLongUrl(string ShortID);
        Models.Url AddUrl(string url);
        Models.Url AddUrl(string url, string DesiredShortID);
    }
}
