using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicallyApi.Sign
{
    /// <summary>
    ///     Makes use of the frida API located here
    ///     https://github.com/AeonLucid/MusicallyRE/tree/master/src-frida
    /// </summary>
    public class SignatureHandlerFrida : ISignatureHandler
    {
        private readonly string _apiUrl;

        private readonly HttpClient _client;

        public SignatureHandlerFrida()
        {
            _apiUrl = "http://127.0.0.1:5000/sign";
            _client = new HttpClient();
        }

        public SignatureHandlerFrida(string apiUrl)
        {
            _apiUrl = apiUrl;
            _client = new HttpClient();
        }

        public async Task<SignatureData> GetSignature(string requestInfo, string deviceId)
        {
            try
            {
                var content = new Dictionary<string, string>
                {
                    {"requestInfo", requestInfo}
                };

                using (var response = await _client.PostAsync(_apiUrl, new FormUrlEncodedContent(content)))
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<SignatureData>(responseContent);
                }
            }
            catch (HttpRequestException e)
            {
                throw new SignatureHandlerException("Failed to retrieve a signature.", e);
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
