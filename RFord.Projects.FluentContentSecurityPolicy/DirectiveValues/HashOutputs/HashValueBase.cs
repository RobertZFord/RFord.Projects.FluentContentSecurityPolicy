using RFord.Projects.FluentContentSecurityPolicy.Enums;
using System.Security.Cryptography;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal abstract class HashValueBase : DirectiveValueBase
    {
        protected readonly SriHash _hashAlgorithm;
        protected readonly string _sriHashValue;

        protected HashValueBase(SriHash hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm;

            _sriHashValue = _hashAlgorithm switch
            {
                SriHash.Sha256 => "sha256",
                SriHash.Sha384 => "sha384",
                SriHash.Sha512 => "sha512",
                _ => throw new ArgumentOutOfRangeException(paramName: nameof(_hashAlgorithm))
            };
        }

        protected HashAlgorithm getAlgorithm(SriHash hashAlgorithm) => hashAlgorithm switch
        {
            SriHash.Sha256 => SHA256.Create(),
            SriHash.Sha384 => SHA384.Create(),
            SriHash.Sha512 => SHA512.Create(),
            _ => throw new ArgumentOutOfRangeException(paramName: nameof(hashAlgorithm))
        };
    }
}
