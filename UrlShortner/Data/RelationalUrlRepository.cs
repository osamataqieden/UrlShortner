using UrlShortner.Models;

namespace UrlShortner.Data
{
    public class RelationalUrlRepository : IURlRepository
    {
        public bool AddUrl(Url url)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUrl(Url url)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUrl(string id)
        {
            throw new NotImplementedException();
        }

        public List<Url> GetAll(bool returnDisabled = false)
        {
            throw new NotImplementedException();
        }

        public List<Url> GetAll(int startIndex, int endIndex, bool returnDisabled = false)
        {
            throw new NotImplementedException();
        }

        public List<Url> GetByDate(DateTime date, bool beforeFlag = false, bool returnDisabled = false)
        {
            throw new NotImplementedException();
        }

        public Url GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUrl(Url url)
        {
            throw new NotImplementedException();
        }
    }
}
