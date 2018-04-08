using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using MusicallyApi.Cache;
using MusicallyApi.Cache.Handlers;
using MusicallyApi.Data.Responses;
using MusicallyApi.Exceptions;
using MusicallyApi.Extensions;
using MusicallyApi.Sign;
using Newtonsoft.Json;

namespace MusicallyApi
{
    public class MusicallyApi : IDisposable
    {
        private readonly string _username;
        
        private readonly ICacheHandler _cacheHandler;

        private readonly FlurlClient _client;

        public MusicallyApi(string username, ICacheHandler cacheHandler = null, ISignatureHandler signApi = null)
        {
            ApiSignature = signApi ?? new SignatureHandlerLocal();

            _username = username;
            _cacheHandler = cacheHandler;

            _client = new FlurlClient();
            _client.Configure(settings =>
            {
                settings.CookiesEnabled = true;
            });

            _client.Headers["User-Agent"] = "Musical.ly/2018031901 (Android; OnePlus ONEPLUS A3003 8.0.0;rv:26)";

            LoadCache();
        }

        public ISignatureHandler ApiSignature { get; }

        public MusicallyCache Cache { get; private set; }

        #region Cache

        private void LoadCache()
        {
            Cache = _cacheHandler != null ? _cacheHandler.Load(_username) : new MusicallyCache();
        }

        private void SaveCache()
        {
            _cacheHandler?.Save(_username, Cache);
        }

        #endregion

        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Cache.AccessToken);
        }

        public async Task<UserLogin> LoginAsync(string password)
        {
            var username = _username;

            if (!username.Contains("@"))
            {
                username = $"@{username}";
            }

            try
            {
                var response = await "https://mus-api-prod-akm.zhiliaoapp.com/rest/passport/v2/login"
                    .WithClient(_client)
                    .WithJunkHeaders()
                    .WithSignParam("POST", "user_login", "USER")
                    .WithSignHeaders(this)
                    .PostUrlEncodedAsync(new Dictionary<string, string>
                    {
                        { "username", username },
                        { "password", password },
                        { "supportLoginverify", "false" },
                        { "remember_me", "on" }
                    });

                using (response)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Cache.AccessToken = response.Headers.GetValues("WWW-Authenticate").FirstOrDefault();
                    }

                    if (string.IsNullOrEmpty(Cache.AccessToken))
                    {
                        throw new MusicallyLoginFailedException();
                    }

                    SaveCache();
                    
                    return JsonConvert.DeserializeObject<UserLogin>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new MusicallyLoginFailedException("HTTPClient threw an UnauthorizedAccessException.", e);
            }
        }

        public async Task<UserProfile> UserGetAsync(string userId)
        {
            return await $"https://api.musical.ly/rest/user/{userId}"
                .WithClient(_client)
                .WithJunkHeaders()
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .GetJsonAsync<UserProfile>();
        }

        public async Task<UserSearch> UserSearchAsync(string keyword = "", int pageNo = 1, string userIds = "", string userVoRelations = "f,w")
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com//rest/discover/user/find_user_v5"
                .WithClient(_client)
                .SetQueryParam("pageNo", pageNo)
                .SetQueryParam("keyword", keyword)
                .SetQueryParam("userIds", userIds)
                .SetQueryParam("user_vo_relations", userVoRelations)
                .WithJunkHeaders()
                .WithSignParam("LIST", "find_user", "USER", "v5")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .GetJsonAsync<UserSearch>();
        }

        public async Task<DiscoverUserMe> DiscoverUserMeAsync()
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com/rest/discover/user/me"
                .WithClient(_client)
                .WithJunkHeaders()
                .WithSignParam("SINGLE", "read_me", "USER")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .GetJsonAsync<DiscoverUserMe>();
        }

        public async Task<DiscoverUserFriends> DiscoverUserFriendsAsync(string userVoRelations = "all")
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com/rest/discover/user/friends"
                .WithClient(_client)
                .SetQueryParam("user_vo_relations", userVoRelations)
                .WithJunkHeaders()
                .WithSignParam("LIST", "get_friends_and_bff", "USER")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .GetJsonAsync<DiscoverUserFriends>();
        }

        public async Task<DiscoverMusicalOwned> DiscoverMusicalOwnedAsync(string userId, int anchor = 0, int limit = 20)
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com//rest/discover/musical/owned_v2/list"
                .WithClient(_client)
                .SetQueryParam("anchor", anchor)
                .SetQueryParam("limit", limit)
                .SetQueryParam("target_user_id", userId)
                .WithJunkHeaders()
                .WithSignParam("LIST", "musicals_owned", "MUSICAL", "v2")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .GetJsonAsync<DiscoverMusicalOwned>();
        }

        public async Task<DiscoverMusicalLiked> DiscoverMusicalLikedAsync(string userId, int anchor = 0, int limit = 20)
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com//rest/discover/musical/you_liked_v3/list"
                .WithClient(_client)
                .SetQueryParam("anchor", anchor)
                .SetQueryParam("limit", limit)
                .SetQueryParam("target_user_id", userId)
                .WithJunkHeaders()
                .WithSignParam("LIST", "musicals_muser_liked_v2", "MUSICAL")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .GetJsonAsync<DiscoverMusicalLiked>();
        }

        public async Task<MusicalsExploreList> MusicalsExploreListAsync(int limit = 8, string hotKey = "model", int displayMode = 1)
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com/rest/musicals/explore/list"
                .WithClient(_client)
                .SetQueryParam("limit", limit)
                .SetQueryParam("hotKey", hotKey)
                .SetQueryParam("displayMode", displayMode)
                .WithJunkHeaders()
                .WithSignParam("LIST", "explore_discovery", "MUSICAL")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .GetJsonAsync<MusicalsExploreList>();
        }

        public async Task<OperationFollow> OperationFollowAsync(string userId)
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com//rest/graph/operations/v2/friendship"
                .WithClient(_client)
                .WithJunkHeaders()
                .WithSignParam("POST", "follow", "GRAPH")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .PostUrlEncodedAsync(new Dictionary<string, string>
                {
                    {"incomingId", userId},
                    {"product", "MUSICAL_LY"}
                })
                .ReceiveJson<OperationFollow>();
        }

        public async Task<OperationFollow> OperationFollowDeleteAsync(string userId)
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com//rest/graph/operations/v2/friendship"
                .WithClient(_client)
                .SetQueryParam("incomingId", userId)
                .SetQueryParam("product", "MUSICAL_LY")
                .WithJunkHeaders()
                .WithSignParam("DELETE", "unfollow", "GRAPH")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .DeleteAsync()
                .ReceiveJson<OperationFollow>();
        }

        public async Task<MusicalLike> MusicalLikeAsync(string musicalId, string required = "yes", string type = "feeds_for_you_list")
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com//rest/musical/like/v2"
                .WithClient(_client)
                .SetQueryParam("musical_id", musicalId)
                .SetQueryParam("required", required)
                .SetQueryParam("type", type)
                .WithJunkHeaders()
                .WithSignParam("PUT", "musical_like", "MUSICAL")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .PutJsonAsync("")
                .ReceiveJson<MusicalLike>();
        }

        public async Task<MusicalLike> MusicalLikeDeleteAsync(string musicalId, string required = "yes")
        {
            return await "https://mus-api-prod-akm.zhiliaoapp.com//rest/musical/like/v2"
                .WithClient(_client)
                .SetQueryParam("musical_id", musicalId)
                .SetQueryParam("required", required)
                .WithJunkHeaders()
                .WithSignParam("DELETE", "musical_unlike", "MUSICAL")
                .WithSignHeaders(this)
                .WithHeader("Authorization", Cache.AccessToken)
                .DeleteAsync()
                .ReceiveJson<MusicalLike>();
        }

        public void Dispose()
        {
            SaveCache();

            ApiSignature?.Dispose();
            _client?.Dispose();
        }
    }
}
