namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    // if we were targetting .NET 7 and could use C# 11, this could be a static abstract property on an interface.
    /// <summary>
    /// Configure the 'default-src' directive.  Serves as a fallback for the other fetch directives.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/default-src
    /// </remarks>
    [CspDirective(Directive = "default-src")]
    public class DefaultPolicy : FetchDirectivePolicyBase { }
}
