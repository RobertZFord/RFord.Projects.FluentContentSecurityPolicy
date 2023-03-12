namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'prefetch-src' directive.  Specifies valid sources to be prefetched or prerendered.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/prefetch-src
    /// </remarks>
    [CspDirective(Directive = "prefetch-src")]
    public class PrefetchPolicy : FetchDirectivePolicyBase { }
}
