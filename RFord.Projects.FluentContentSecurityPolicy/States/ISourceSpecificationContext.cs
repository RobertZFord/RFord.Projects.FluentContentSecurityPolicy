using RFord.Projects.FluentContentSecurityPolicy.States.Internal;

namespace RFord.Projects.FluentContentSecurityPolicy.States
{
    public interface ISourceSpecificationContext
        : ITransitionToDirectiveContext
        , IInitialSourceSpecification
    {
        IContentSecurityPolicy Build();
        string Evaluate();
    }
}
