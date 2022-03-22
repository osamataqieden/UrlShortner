using UrlShortner.Models;

namespace UrlShortner.Services
{
    public class UrlService : IUrlService
    {
        public Url AddUrl(string url)
        {
            throw new NotImplementedException();
        }

        public Url AddUrl(string url, string DesiredShortID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUrl(string ShortID)
        {
            throw new NotImplementedException();
        }

        public string GetLongUrl(string ShortID)
        {
            throw new NotImplementedException();
        }

        public string GetShortUrl(string url)
        {
            throw new NotImplementedException();
        }

        public bool isExist(string ShortID)
        {
            throw new NotImplementedException();
        }

        public bool isExpired(string ShortID)
        {
            throw new NotImplementedException();
        }
    }
}
