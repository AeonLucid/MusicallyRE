namespace MusicallyApi.Data.Models
{
    public class TrackAlbum
    {
        public string foreignId { get; set; }
        public string source { get; set; }
        public long albumId { get; set; }
        public string title { get; set; }
        public string thumbnailUri { get; set; }
    }
}
