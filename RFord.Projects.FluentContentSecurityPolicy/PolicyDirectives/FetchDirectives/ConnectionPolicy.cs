namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'connect-src' directive.  Restricts the URLs which can be loaded using script interfaces.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/connect-src
    /// </remarks>
    [CspDirective(Directive = "connect-src")]
    public class ConnectionPolicy : FetchDirectivePolicyBase { }
}
