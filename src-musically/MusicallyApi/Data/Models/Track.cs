namespace MusicallyApi.Data.Models
{
    public class Track
    {
        public long trackId { get; set; }
        public string previewUri { get; set; }
        public TrackAuthor author { get; set; }
        public TrackSong song { get; set; }
        public TrackAlbum album { get; set; }
        public int sequence { get; set; }
        public int banned { get; set; }
        public string foreignId { get; set; }
        public string source { get; set; }
        public long appleSongId { get; set; }
    }
}