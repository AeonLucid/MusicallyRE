namespace MusicallyApi.Data.Models
{
    public class MusicalAuthor
    {
        public long userId { get; set; }
        public string userIdStr { get; set; }
        public string userIdBid { get; set; }
        public bool emailVerified { get; set; }
        public string nickName { get; set; }
        public object realName { get; set; }
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
}
