namespace MusicallyApi.Data.Responses
{
    public class UserProfile
    {
        public bool success { get; set; }
        public bool fallback { get; set; }
        public Result result { get; set; }
        public long timestamp { get; set; }
        public bool fail { get; set; }

        public class Result
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
            public int followNum { get; set; }
            public int fansNum { get; set; }
            public int musicalNum { get; set; }
            public int privateMusicalNum { get; set; }
            public int musicalLikedNum { get; set; }
            public int likesNum { get; set; }
            public int livelyHearts { get; set; }
            public string directAccount { get; set; }
            public string instagramID { get; set; }
            public bool suspicious { get; set; }
            public object[] userBadgeDTOList { get; set; }
            public string shareUri { get; set; }
            public int likesNumSelf { get; set; }
            public string videoIconURI { get; set; }
            public bool hideMessagePreview { get; set; }
            public bool disallowFindMeByHandle { get; set; }
            public bool disallowFindMeByNO { get; set; }
            public bool disallowFindMeByEmail { get; set; }
            public bool disallowFindMeByPhone { get; set; }
            public object[] thirdUsers { get; set; }
        }
    }
}
