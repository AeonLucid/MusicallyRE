namespace MusicallyApi.Data.Responses
{
    public class DiscoverUserMe
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
            public int followNum { get; set; }
            public int fansNum { get; set; }
            public int musicalNum { get; set; }
            public int privateMusicalNum { get; set; }
            public int musicalLikedNum { get; set; }
            public int likesNum { get; set; }
            public int livelyHearts { get; set; }
            public string directAccount { get; set; }
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
            public bool ageVerified { get; set; }
            public object[] thirdUsers { get; set; }
            public string gender { get; set; }
            public bool verified { get; set; }
            public bool reviewer { get; set; }
            public bool admin { get; set; }
            public bool hideLocation { get; set; }
            public bool isPrivateChat { get; set; }
            public int policyVersion { get; set; }
            public string countryCode { get; set; }
            public string languageCode { get; set; }
            public string timeZone { get; set; }
            public int source { get; set; }
            public int likeVisibleSetting { get; set; }
            public string email { get; set; }
            public object[] thirdUserDTOList { get; set; }
            public int secureEmailStatus { get; set; }
            public int[] userApp { get; set; }
            public int accountSecurityRisk { get; set; }
            public bool hasMusLivePermission { get; set; }
        }
    }
}
