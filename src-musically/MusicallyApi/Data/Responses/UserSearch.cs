namespace MusicallyApi.Data.Responses
{
    public class UserSearch
    {
        public bool success { get; set; }
        public bool fallback { get; set; }
        public Result result { get; set; }
        public long timestamp { get; set; }
        public bool fail { get; set; }

        public class Result
        {
            public string domain { get; set; }
            public string bizType { get; set; }
            public string action { get; set; }
            public Nav current { get; set; }
            public Nav next { get; set; }
            public bool hasNext { get; set; }
            public List[] list { get; set; }
        }

        public class Nav
        {
            public string url { get; set; }
        }

        public class List
        {
            public long userId { get; set; }
            public string userIdStr { get; set; }
            public string userIdBid { get; set; }
            public bool emailVerified { get; set; }
            public string nickName { get; set; }
            public string displayName { get; set; }
            public string icon { get; set; }
            public bool isFeatured { get; set; }
            public bool isPrivateAccount { get; set; }
            public bool addFriendWithoutConfirm { get; set; }
            public string userDesc { get; set; }
            public bool disabled { get; set; }
            public string handle { get; set; }
            public long insertTime { get; set; }
            public object[] relationsFromMe { get; set; }
            public object[] relationsToMe { get; set; }
            public string realName { get; set; }
        }
    }
}
