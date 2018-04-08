using MusicallyApi.Data.Models;

namespace MusicallyApi.Data.Responses
{
    public class UserSearch
    {
        public bool Success { get; set; }
        public bool Fallback { get; set; }
        public ApiResult Result { get; set; }
        public long Timestamp { get; set; }
        public bool Fail { get; set; }

        public class ApiResult
        {
            public string Domain { get; set; }
            public string BizType { get; set; }
            public string Action { get; set; }
            public ApiNavigation Current { get; set; }
            public ApiNavigation Next { get; set; }
            public bool HasNext { get; set; }
            public ListItem[] List { get; set; }
        }

        public class ListItem
        {
            public long UserId { get; set; }
            public string UserIdStr { get; set; }
            public string UserIdBid { get; set; }
            public bool EmailVerified { get; set; }
            public string NickName { get; set; }
            public string DisplayName { get; set; }
            public string Icon { get; set; }
            public bool IsFeatured { get; set; }
            public bool IsPrivateAccount { get; set; }
            public bool AddFriendWithoutConfirm { get; set; }
            public string UserDesc { get; set; }
            public bool Disabled { get; set; }
            public string Handle { get; set; }
            public long InsertTime { get; set; }
            public object[] RelationsFromMe { get; set; }
            public object[] RelationsToMe { get; set; }
            public string RealName { get; set; }
        }
    }
}
