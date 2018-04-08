using System;
using System.Threading.Tasks;

namespace MusicallyApi.Sign
{
    public interface ISignatureHandler : IDisposable
    {
        Task<SignatureData> GetSignature(string requestInfo, string deviceId);
    }
}