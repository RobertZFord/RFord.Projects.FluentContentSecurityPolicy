using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues.HashOutputs
{
    internal class UncomputedHashValue : ImmediateHashValueBase
    {
        private readonly string _final;

        internal override string Evaluate() => _final;

        internal UncomputedHashValue(SriHash hashAlgorithm, string dataToHash) : base(hashAlgorithm, dataToHash)
        {
            _final = PreProcess(_data);
        }

        private string PreProcess(string data)
        {
            string hashData;
            using (HashAlgorithm algorithm = getAlgorithm(_hashAlgorithm))
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashBytes = algorithm.ComputeHash(dataBytes);
                hashData = Convert.ToBase64String(hashBytes);
            }

            string finalResult = $"'{_sriHashValue}-{hashData}'";

            return finalResult;
        }
    }
}
