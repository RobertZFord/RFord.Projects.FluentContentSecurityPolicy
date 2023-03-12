namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'style-src-attr' directive.  Specifies valid sources for inline styles applied to individual DOM elements.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/style-src-attr
    /// </remarks>
    [CspDirective(Directive = "style-src-attr")]
    public class InlineStyleSourcePolicy : FetchDirectivePolicyBase { }
}
