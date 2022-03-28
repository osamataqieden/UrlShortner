using UrlShortner.Models;
using System.Security.Cryptography;
using System.Text;

namespace UrlShortner.Services
{
    public class UrlService : IUrlService
    {
        private readonly Data.IURlRepository _repository;
        private readonly ILogger<IUrlService> _logger;

        public UrlService(Data.IURlRepository repository, ILogger<IUrlService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Url AddUrl(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            if(!isExist("", url))
            {
                string hash = GetHashedURL(url);
                Url SavedURL = new Url
                {
                    LongUrl = url,
                    ShortID = hash,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                };
                _repository.AddUrl(SavedURL);
                return SavedURL;
            }
            throw new Exception($"{url} already exist");
        }
        public bool DeleteUrl(string ShortID)
        {
            if (!string.IsNullOrEmpty(ShortID) && isExist(ShortID))
            {
                return _repository.DeleteUrl(ShortID);
            }
            else throw new ArgumentException("Does not exist");
        }

        public string GetLongUrl(string ShortID)
        {
            if (string.IsNullOrEmpty(ShortID))
                throw new ArgumentNullException("ShortID");
            if (!isExist(ShortID))
                throw new ArgumentException("Does not exist");
            Url url = _repository.GetByID(ShortID);
            return url.LongUrl;
        }

        public string GetShortUrl(string LongURL)
        {
            if (string.IsNullOrEmpty(LongURL))
                throw new ArgumentNullException("ShortID");
            if (!isExist("", LongURL))
                throw new ArgumentException("Does not exist");
            Url url = _repository.GetByLongURL(LongURL);
            return url.ShortID;
        }

        public bool isExist(string ShortID, string LongURL = "")
        {
            if (!string.IsNullOrEmpty(ShortID))
            {
                //check via ShortID
                try
                {
                    Url url = _repository.GetByID(ShortID);
                    if (url != null)
                        return true;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Element not found")
                        return false;
                    throw new Exception(ex.Message);
                }
            }
            if (!string.IsNullOrEmpty(LongURL))
            {
                //check via LongID
                try
                {
                    Url url = _repository.GetByLongURL(LongURL);
                    if (url != null)
                        return true;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Element not found")
                        return false;
                    throw new Exception(ex.Message);
                }
            }
            throw new ArgumentNullException("ShortID and LongURL");
        }

        public List<Url> GetAllUrls()
        {
            return _repository.GetAll();
        }

        public List<Models.Url> GetPagedUrls(int page, int pageSize)
        {
            int startIndex = page * pageSize;
            int endIndex = startIndex + pageSize;
            return _repository.GetAll(startIndex, endIndex);
        }

        public bool isExpired(string ShortID)
        {
            throw new NotImplementedException();
        }

        public Url AddUrl(string url, string DesiredShortID)
        {
            throw new NotImplementedException();
        }

        private string GetHashedURL(string url)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                var result = hash.ComputeHash(Encoding.UTF8.GetBytes(url));
                for(int i = 0; i < 7; i++)
                {
                    stringBuilder.Append(result[i].ToString("x2"));
                }
            }
            return stringBuilder.ToString();
        }
    }
}
