namespace MusicallyApi.Cache
{
    public class MusicallyCache
    {
        public MusicallyApiDevice Device { get; set; } = MusicallyApiDevice.Generate();

        public string AccessToken { get; set; }
    }
}
