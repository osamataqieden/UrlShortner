namespace UrlShortner.Data
{
    public interface IURlRepository
    {
        Models.Url GetByID(string id);
        Models.Url GetByLongURL(string LongURL);
        bool AddUrl(Models.Url url);
        bool DeleteUrl(Models.Url url);
        bool DeleteUrl(string ShortURL);
        List<Models.Url> GetByDate(DateTime date, bool beforeFlag = false, bool returnDisabled = false);
        List<Models.Url> GetAll(bool returnDisabled = false);
        List<Models.Url> GetAll(int startIndex, int endIndex, bool returnDisabled = false);
    }
}
