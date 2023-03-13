using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues.HashOutputs
{
    internal abstract class DeferredHashValueBase : HashValueBase
    {
        protected readonly Func<string> _dataRetrievalFunction;

        public DeferredHashValueBase(SriHash hashAlgorithm, Func<string> dataRetrievalFunction) : base(hashAlgorithm)
        {
            _dataRetrievalFunction = dataRetrievalFunction;
        }
    }
}
