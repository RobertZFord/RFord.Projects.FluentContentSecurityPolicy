namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'font-src' directive.  Specifies valid sources for fonts loaded using @font-face.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/font-src
    /// </remarks>
    [CspDirective(Directive = "font-src")]
    public class FontPolicy : FetchDirectivePolicyBase { }
}
