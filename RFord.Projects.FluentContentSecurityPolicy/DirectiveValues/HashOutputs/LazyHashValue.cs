using System.Security.Cryptography;
using System.Text;
using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues.HashOutputs
{
    internal class LazyHashValue : DeferredHashValueBase
    {
        public LazyHashValue(SriHash hashAlgorithm, Func<string> dataRetrievalFunction) : base(hashAlgorithm, dataRetrievalFunction)
        {

        }

        internal override string Evaluate()
        {
            string retrievedData = _dataRetrievalFunction.Invoke();

            string hashData;

            using (HashAlgorithm algorithm = getAlgorithm(_hashAlgorithm))
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(retrievedData);
                byte[] hashBytes = algorithm.ComputeHash(dataBytes);
                hashData = Convert.ToBase64String(hashBytes);
            }

            string finalResult = $"'{_sriHashValue}-{hashData}'";

            return finalResult;
        }
    }
}
