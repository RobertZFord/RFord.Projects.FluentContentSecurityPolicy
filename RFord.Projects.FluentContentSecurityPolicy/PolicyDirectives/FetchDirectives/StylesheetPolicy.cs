namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'style-src' directive.  Specifies valid sources for stylesheets.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/style-src
    /// </remarks>
    [CspDirective(Directive = "style-src")]
    public class StylesheetPolicy : FetchDirectivePolicyBase { }
}
