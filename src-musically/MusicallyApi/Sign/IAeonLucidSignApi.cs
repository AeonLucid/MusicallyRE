using System;
using System.Threading.Tasks;

namespace MusicallyApi.Sign
{
    public interface IAeonLucidSignApi : IDisposable
    {
        Task<AeonLucidSign> GetSignature(string requestInfoBase64);
    }
}