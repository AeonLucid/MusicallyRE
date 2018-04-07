using MusicallyApi.Data.Models;

namespace MusicallyApi.Data.Responses
{
    public class MusicalsExploreList
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
            public Nav previous { get; set; }
            public Nav current { get; set; }
            public Nav next { get; set; }
            public bool hasNext { get; set; }
            public List[] list { get; set; }
            public Extra extra { get; set; }
        }

        public class Nav
        {
            public string url { get; set; }
            public object meta { get; set; }
            public object hosts { get; set; }
        }

        public class Extra
        {
            public object[] userLive { get; set; }
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
            public string lowQualityVideoUri { get; set; }
            public string middleQualityVideoUri { get; set; }
            public Url[] urls { get; set; }
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
            public Author1 author { get; set; }
            public int banned { get; set; }
            public bool ost { get; set; }
            public bool featured { get; set; }
            public string scm { get; set; }
            public bool partyFeaturedFlag { get; set; }
            public bool streamPlayFlag { get; set; }
            public Recommendmeta recommendMeta { get; set; }
            public int orientation { get; set; }
            public bool officialFlag { get; set; }
            public int avgViewTime { get; set; }
            public Exploremeta exploreMeta { get; set; }
        }
        
        public class Author1
        {
            public long userId { get; set; }
            public string userIdStr { get; set; }
            public string userIdBid { get; set; }
            public bool emailVerified { get; set; }
            public string nickName { get; set; }
            public string realName { get; set; }
            public string displayName { get; set; }
            public string icon { get; set; }
            public bool isFeatured { get; set; }
            public object tvAccount { get; set; }
            public object livelyFeatured { get; set; }
            public bool isPrivateAccount { get; set; }
            public string userDesc { get; set; }
            public bool disabled { get; set; }
            public string handle { get; set; }
            public object scm { get; set; }
            public object insertTime { get; set; }
            public object updateTime { get; set; }
            public object relationsFromMe { get; set; }
            public object relationsToMe { get; set; }
        }

        public class Recommendmeta
        {
            public object innerReason { get; set; }
            public object reason { get; set; }
        }

        public class Exploremeta
        {
            public string recommendType { get; set; }
        }

        public class Url
        {
            public int bitRate { get; set; }
            public string videoUrl { get; set; }
            public int qualityType { get; set; }
            public string gearName { get; set; }
            public int videoSize { get; set; }
        }
    }
}
