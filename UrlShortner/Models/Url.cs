namespace UrlShortner.Models
{
    public class Url
    {
        private int id;
        private string _longUrl;
        private string _shortID;
        private DateTime _createdOn;
        private bool _isActive;


        public int Id { get => id; set => id = value; }
        public string LongUrl { get => _longUrl; set => _longUrl = value; }
        public string ShortID { get => _shortID; set => _shortID = value; }
        public DateTime CreatedOn { get => _createdOn; set => _createdOn = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
    }
}
