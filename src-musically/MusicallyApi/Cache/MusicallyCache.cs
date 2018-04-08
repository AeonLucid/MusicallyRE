using MusicallyApi.Data;

namespace MusicallyApi.Cache
{
    public class MusicallyCache
    {
        public Device Device { get; set; } = Device.Generate();

        public string AccessToken { get; set; }
    }
}
