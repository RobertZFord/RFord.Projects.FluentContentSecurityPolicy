using RFord.Projects.FluentContentSecurityPolicy.States.Internal;

namespace RFord.Projects.FluentContentSecurityPolicy.States
{
    public interface ISourceSpecificationContext
        : ITransitionToDirectiveContext
        , IInitialSourceSpecification
    {
        /// <summary>
        /// Build the resultant Content-Security-Policy string based on the current configuration.
        /// </summary>
        string Build();
    }
}
