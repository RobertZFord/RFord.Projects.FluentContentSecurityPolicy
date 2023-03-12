using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class ComputedHashValue : HashValueBase
    {
        internal ComputedHashValue(SriHash hashAlgorithm, string hashData) : base(hashAlgorithm, hashData) { }

        internal override string Evaluate()
        {
            foreach (char c in _data)
            {
                if (isNotValidBase64Character(c))
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(_data));
                }
            }

            string finalResult = $"'{_sriHashValue}-{_data}'";

            return finalResult;
        }
    }
}
