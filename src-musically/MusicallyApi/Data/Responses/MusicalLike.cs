namespace MusicallyApi.Data.Responses
{
    public class MusicalLike
    {
        public bool success { get; set; }
        public bool fallback { get; set; }
        public int result { get; set; }
        public long timestamp { get; set; }
        public bool fail { get; set; }
    }
}
