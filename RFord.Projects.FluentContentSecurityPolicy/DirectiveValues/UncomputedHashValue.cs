using System.Security.Cryptography;
using System.Text;
using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class UncomputedHashValue : HashValueBase
    {
        internal UncomputedHashValue(SriHash hashAlgorithm, string dataToHash) : base(hashAlgorithm, dataToHash) { }

        internal override string Evaluate()
        {
            static HashAlgorithm getAlgorithm(SriHash hashAlgorithm) => hashAlgorithm switch
            {
                SriHash.Sha256 => SHA256.Create(),
                SriHash.Sha384 => SHA384.Create(),
                SriHash.Sha512 => SHA512.Create(),
                _ => throw new ArgumentOutOfRangeException(paramName: nameof(hashAlgorithm))
            };

            string hashData;
            using (HashAlgorithm algorithm = getAlgorithm(_hashAlgorithm))
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(_data);
                byte[] hashBytes = algorithm.ComputeHash(dataBytes);
                hashData = Convert.ToBase64String(hashBytes);
            }

            string finalResult = $"'{_sriHashValue}-{hashData}'";

            return finalResult;
        }
    }
}
