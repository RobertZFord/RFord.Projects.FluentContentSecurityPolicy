using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues.HashOutputs
{
    internal class ComputedHashValue : ImmediateHashValueBase
    {
        private readonly string _final;

        internal override string Evaluate() => _final;

        internal ComputedHashValue(SriHash hashAlgorithm, string hashData) : base(hashAlgorithm, hashData)
        {
            _final = PreProcess(_data);
        }

        private string PreProcess(string data)
        {
            foreach (char c in data)
            {
                if (isNotValidBase64Character(c))
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(data));
                }
            }

            string finalResult = $"'{_sriHashValue}-{data}'";

            return finalResult;
        }
    }
}
