using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal abstract class HashValueBase : DirectiveValueBase
    {
        protected readonly SriHash _hashAlgorithm;
        protected readonly string _sriHashValue;
        protected readonly string _data;

        protected HashValueBase(SriHash hashAlgorithm, string data)
        {
            _hashAlgorithm = hashAlgorithm;
            _data = data;

            _sriHashValue = _hashAlgorithm switch
            {
                SriHash.Sha256 => "sha256",
                SriHash.Sha384 => "sha384",
                SriHash.Sha512 => "sha512",
                _ => throw new ArgumentOutOfRangeException(paramName: nameof(_hashAlgorithm))
            };
        }
    }
}
