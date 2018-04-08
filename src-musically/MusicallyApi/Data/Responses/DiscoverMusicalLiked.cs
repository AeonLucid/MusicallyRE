using MusicallyApi.Data.Models;

namespace MusicallyApi.Data.Responses
{
    public class DiscoverMusicalLiked
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
            public long duration { get; set; }
            public string thumbnailUri { get; set; }
            public int thumbnailOriginalWidth { get; set; }
            public int thumbnailOriginalHeight { get; set; }
            public string videoUri { get; set; }
            public string shareUri { get; set; }
            public string lowQualityVideoUri { get; set; }
            public string middleQualityVideoUri { get; set; }
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
            public bool streamPlayFlag { get; set; }
            public int orientation { get; set; }
            public bool officialFlag { get; set; }
            public int avgViewTime { get; set; }
            public string thumbnailOriginalUri { get; set; }
            public Category category { get; set; }
            public int videoSize { get; set; }
        }

        public class Category
        {
            public long tagId { get; set; }
            public string tag { get; set; }
            public string displayName { get; set; }
            public object desc { get; set; }
            public object videoCaption { get; set; }
            public object imageUri { get; set; }
            public bool inContest { get; set; }
            public object ext { get; set; }
            public object extMap { get; set; }
            public object musicalNum { get; set; }
            public object followedNum { get; set; }
            public object followed { get; set; }
            public int promoteType { get; set; }
            public int tagType { get; set; }
            public object promoteTime { get; set; }
            public object sequence { get; set; }
            public bool inDuet { get; set; }
            public bool nonLipSync { get; set; }
            public object officialMusicalId { get; set; }
            public int shownType { get; set; }
            public int derivedType { get; set; }
            public object[] promotedRegions { get; set; }
            public object i18n { get; set; }
            public object contributor { get; set; }
            public object contributedBy { get; set; }
            public Categoryext categoryExt { get; set; }
            public object shareUri { get; set; }
            public object tagSegmentResult { get; set; }
            public object officialMusicalIdStr { get; set; }
        }

        public class Categoryext
        {
            public string tagName { get; set; }
            public string categoryName { get; set; }
            public string displayName { get; set; }
            public bool categoryEnabled { get; set; }
            public int categoryIdx { get; set; }
            public long categoryId { get; set; }
            public string color { get; set; }
            public object imageUrl { get; set; }
            public string detailUrl { get; set; }
            public object country { get; set; }
            public string[] scopes { get; set; }
            public object displayScopes { get; set; }
            public int derivedType { get; set; }
            public Resourceurls resourceUrls { get; set; }
            public string contributorHandle { get; set; }
            public string badgeName { get; set; }
            public object badgeDisplayName { get; set; }
            public object contributorId { get; set; }
        }

        public class Resourceurls
        {
            public string musically_placeholder { get; set; }
            public string musically_webp { get; set; }
            public string musically_icon { get; set; }
        }
    }
}
