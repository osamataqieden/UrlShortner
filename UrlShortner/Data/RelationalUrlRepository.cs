using UrlShortner.Models;

namespace UrlShortner.Data
{
    public class RelationalUrlRepository : IURlRepository
    {
        private readonly ApplicationDbContext _context;
        public RelationalUrlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddUrl(Url url)
        {
            if(url == null)
                throw new ArgumentNullException("url");
            _context.Add(url);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteUrl(Url url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            if (_context.urls.Count(x => x.ShortID == url.ShortID) > 0)
            {
                _context.urls.Remove(url);
                _context.SaveChanges();
                return true;
            }
            else throw new ArgumentException("Does not exist in table");
        }

        public bool DeleteUrl(string ShortURL)
        {
            if (string.IsNullOrEmpty(ShortURL))
                throw new ArgumentNullException("ShortID");
            if(_context.urls.Count(x => x.ShortID == ShortURL) > 0)
            {
                _context.urls.Remove(_context.urls.Single(x => x.ShortID == ShortURL));
                _context.SaveChanges();
                return true;
            }
            throw new ArgumentException("Does not exist in table");
        }

        public List<Url> GetAll(bool returnDisabled = false)
        {
            if (returnDisabled)
            {
                return _context.urls.ToList();
            }
            else return _context.urls.Where(x => x.IsActive).ToList();
        }

        public List<Url> GetAll(int startIndex, int endIndex, bool returnDisabled = false)
        {
            if (returnDisabled)
            {
                return _context.urls.Skip(startIndex).Take(endIndex - startIndex).ToList();
            }
            else return _context.urls.Where(x => x.IsActive).Skip(startIndex).Take(endIndex - startIndex).ToList();
        }

        public List<Url> GetByDate(DateTime date, bool beforeFlag = false, bool returnDisabled = false)
        {
            if (beforeFlag)
            {
                if (returnDisabled)
                {
                    return _context.urls.Where(x => x.CreatedOn < date).ToList();
                }
                return _context.urls.Where(x => x.IsActive).Where(x => x.CreatedOn < date).ToList();
            }
            else
            {
                if (returnDisabled)
                {
                    return _context.urls.Where(_x => _x.CreatedOn > date).ToList();
                }
                else return _context.urls.Where(x => x.IsActive).Where(_x => _x.CreatedOn > date).ToList();
            }
        }

        public Url GetByID(string id)
        {
            Url url = _context.urls.Where(x => x.ShortID == id).FirstOrDefault();
            if (url == null)
                throw new Exception("Element not found");
            return url;
        }

        public Url GetByLongURL(string LongURL)
        {
            Url url = _context.urls.Where(x => x.LongUrl == LongURL).FirstOrDefault();
            if (url == null)
                throw new Exception("Element not found");
            return url;
        }

        public bool UpdateUrl(Url url)
        {
            var currentUrl = GetByLongURL(url.LongUrl);
            if (currentUrl == null)
                throw new Exception("Element not found");
            url.ShortID = url.ShortID ?? currentUrl.ShortID;
            url.LongUrl = url.LongUrl ?? currentUrl.LongUrl;
            url.CreatedOn = currentUrl.CreatedOn;
            url.IsActive = currentUrl.IsActive;
            _context.urls.Remove(currentUrl);
            _context.urls.Add(url);
            _context.SaveChanges();
            return true;
        }
    }
}
