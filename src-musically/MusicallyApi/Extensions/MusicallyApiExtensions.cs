using System;
using System.Text;
using Flurl.Http;
using MusicallyApi.Data;
using MusicallyApi.Utils;
using Newtonsoft.Json;

namespace MusicallyApi.Extensions
{
    internal static class MusicallyApiExtensions
    {
        /// <summary>
        ///     Adds necessary junk headers required for musically to
        ///     accept your request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IFlurlRequest WithJunkHeaders(this IFlurlRequest request)
        {
            return request
                .WithHeader("X-Requested-With", "XMLHttpRequest")
                .WithHeader("country", "US")
                .WithHeader("os", "android 8.0.0")
                .WithHeader("timezone", TimeUtils.TimeZone)
                .WithHeader("mobile", "OnePlus ONEPLUS A300")
                .WithHeader("flavor-type", "googleplay")
                .WithHeader("language", "en_US")
                .WithHeader("network", "WiFi")
                .WithHeader("build", "1521454383382");
        }

        /// <summary>
        ///     Adds more necessary junk to the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="action"></param>
        /// <param name="bizType"></param>
        /// <param name="domain"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static IFlurlRequest WithSignParam(this IFlurlRequest request, string action, string bizType, string domain, string version = "default")
        {
            var requestInfo = JsonConvert.SerializeObject(new RequestInfoParam
            {
                ac = action,
                bz = bizType,
                dm = domain,
                ver = "default"
            });

            var requestInfoEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(requestInfo));

            return request.SetQueryParam("___d", requestInfoEncoded);
        }

        /// <summary>
        ///     Signs the request, must be done as last.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="api"></param>
        /// <returns></returns>
        public static IFlurlRequest WithSignHeaders(this IFlurlRequest request, MusicallyApi api)
        {
            var requestId = Guid.NewGuid().ToString();
            var requestInfo = JsonConvert.SerializeObject(new RequestInfo
            {
                Os = "android 8.0.0",
                Version = "6.9.0",
                SliderShowCookie = string.Empty,
                XRequestId = requestId,
                Url = request.Url.ToString(),
                OsType = "android",
                DeviceId = api.Cache.Device.DeviceId,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            });

            var requestInfoEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(requestInfo));
            var requestSignature = api.ApiSignature.GetSignature(requestInfoEncoded).GetAwaiter().GetResult();

            return request
                .WithHeader("X-Request-ID", requestId)
                .WithHeader("X-Request-Info5", requestInfoEncoded)
                .WithHeader("X-Request-Sign5", requestSignature.Sign);
        }
    }
}
