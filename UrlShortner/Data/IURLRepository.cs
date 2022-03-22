namespace UrlShortner.Data
{
    public interface IURlRepository
    {
        Models.Url GetByID(string id);
        bool AddUrl(Models.Url url);
        bool UpdateUrl(Models.Url url);
        bool DeleteUrl(Models.Url url);
        bool DeleteUrl(string id);
        List<Models.Url> GetByDate(DateTime date, bool beforeFlag = false, bool returnDisabled = false);
        List<Models.Url> GetAll(bool returnDisabled = false);
        List<Models.Url> GetAll(int startIndex, int endIndex, bool returnDisabled = false);
    }
}
