using RFord.Projects.FluentContentSecurityPolicy.States.Internal;

namespace RFord.Projects.FluentContentSecurityPolicy.States
{
    public interface ILocationSpecificContext
        : ITransitionToDirectiveContext
        , ILocationSpecificAllowMethods
    {

    }
}
