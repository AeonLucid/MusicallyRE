using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MusicallyApi.Sign
{
    /// <summary>
    ///     Implements the signature described by Charlie
    ///     https://android.jlelse.eu/reverse-engineering-musical-y-live-ly-android-apps-part-1-a910daad2ec2
    /// </summary>
    public class SignatureHandlerLocal : ISignatureHandler
    {
        private const string SecondaryKey = "010df009b182fd15396e93f465686ee7ca72933851";

        public Task<SignatureData> GetSignature(string requestInfo, string deviceId)
        {
            var key = $"{SecondaryKey}&{deviceId}";

            using (var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(key)))
            {
                var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(requestInfo));
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return Task.FromResult(new SignatureData
                {
                    Sign = $"01a6{hash}"
                });
            }
        }

        public void Dispose()
        {
            // ..
        }
    }
}
