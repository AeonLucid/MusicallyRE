using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicallyApi.Sign
{
    public class AeonLucidSignApi : IAeonLucidSignApi
    {
        private readonly string _apiUrl;

        private readonly HttpClient _client;

        public AeonLucidSignApi()
        {
            _apiUrl = "http://127.0.0.1:5000/sign";
            _client = new HttpClient();
        }

        public AeonLucidSignApi(string apiUrl)
        {
            _apiUrl = apiUrl;
            _client = new HttpClient();
        }

        public async Task<AeonLucidSign> GetSignature(string requestInfoBase64)
        {
            try
            {
                var content = new Dictionary<string, string>
                {
                    {"requestInfo", requestInfoBase64}
                };

                using (var response = await _client.PostAsync(_apiUrl, new FormUrlEncodedContent(content)))
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<AeonLucidSign>(responseContent);
                }
            }
            catch (HttpRequestException e)
            {
                throw new AeonLucidSignException("Failed to retrieve a signature.", e);
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
