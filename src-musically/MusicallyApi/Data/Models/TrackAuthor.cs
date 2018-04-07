namespace MusicallyApi.Data.Models
{
    public class TrackAuthor
    {
        public string foreignId { get; set; }
        public string source { get; set; }
        public long artistId { get; set; }
        public string name { get; set; }
        public int banned { get; set; }
    }
}