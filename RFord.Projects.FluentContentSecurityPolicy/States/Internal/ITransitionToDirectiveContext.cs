namespace RFord.Projects.FluentContentSecurityPolicy.States.Internal
{
    public interface ITransitionToDirectiveContext
    {
        /// <summary>
        /// Configure a different directive.  Provides a selection into one of the other directive categories.
        /// </summary>
        IDirectiveSelectionContext AndFor();
    }
}
