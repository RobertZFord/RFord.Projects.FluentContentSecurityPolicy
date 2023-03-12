namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'manifest-src' directive.  Specifies valid sources of application manifest files.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/manifest-src
    /// </remarks>
    [CspDirective(Directive = "manifest-src")]
    public class ManifestPolicy : FetchDirectivePolicyBase { }
}
