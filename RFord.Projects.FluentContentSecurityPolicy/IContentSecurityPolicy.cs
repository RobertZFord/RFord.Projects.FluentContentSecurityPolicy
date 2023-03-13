namespace RFord.Projects.FluentContentSecurityPolicy
{
    /// <summary>
    /// Finalize the CSP and make it suitable for dependency injection.
    /// </summary>
    public interface IContentSecurityPolicy
    {
        /// <summary>
        /// Evaluate the resultant Content-Security-Policy string based on the current configuration.
        /// </summary>
        string Evaluate();
    }
}
