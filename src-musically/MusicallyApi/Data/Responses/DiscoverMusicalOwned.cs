using MusicallyApi.Data.Models;

namespace MusicallyApi.Data.Responses
{
    public class DiscoverMusicalOwned
    {
        public bool success { get; set; }
        public object errorType { get; set; }
        public object errorCode { get; set; }
        public object errorMsg { get; set; }
        public object errorTitle { get; set; }
        public bool fallback { get; set; }
        public Result result { get; set; }
        public long timestamp { get; set; }
        public bool fail { get; set; }

        public class Result
        {
            public string domain { get; set; }
            public string bizType { get; set; }
            public string action { get; set; }
            public ApiNavigation current { get; set; }
            public ApiNavigation next { get; set; }
            public bool hasNext { get; set; }
            public List[] list { get; set; }
        }

        public class List
        {
            public long musicalId { get; set; }
            public string bid { get; set; }
            public string musicalIdStr { get; set; }
            public string caption { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public int duration { get; set; }
            public string thumbnailUri { get; set; }
            public int thumbnailOriginalWidth { get; set; }
            public int thumbnailOriginalHeight { get; set; }
            public string videoUri { get; set; }
            public int videoSize { get; set; }
            public string shareUri { get; set; }
            public MusicalUrl[] Urls { get; set; }
            public string previewUri { get; set; }
            public int musicalType { get; set; }
            public int status { get; set; }
            public long featuredTime { get; set; }
            public long clientCreateTime { get; set; }
            public bool liked { get; set; }
            public int likedNum { get; set; }
            public int loopNum { get; set; }
            public int completeViewNum { get; set; }
            public int commentNum { get; set; }
            public int shareNum { get; set; }
            public Track track { get; set; }
            public MusicalAuthor Author { get; set; }
            public int banned { get; set; }
            public bool ost { get; set; }
            public bool featured { get; set; }
            public bool partyFeaturedFlag { get; set; }
            public long sortId { get; set; }
            public bool streamPlayFlag { get; set; }
            public int orientation { get; set; }
            public bool officialFlag { get; set; }
            public int avgViewTime { get; set; }
        }
    }
}
