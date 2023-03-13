using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues.HashOutputs
{
    internal abstract class ImmediateHashValueBase : HashValueBase
    {
        protected readonly string _data;

        protected ImmediateHashValueBase(SriHash hashAlgorithm, string data) : base(hashAlgorithm)
        {
            _data = data;
        }
    }
}
