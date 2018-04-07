namespace MusicallyApi.Data.Models
{
    public class TrackSong
    {
        public string foreignId { get; set; }
        public string source { get; set; }
        public long songId { get; set; }
        public string title { get; set; }
    }
}