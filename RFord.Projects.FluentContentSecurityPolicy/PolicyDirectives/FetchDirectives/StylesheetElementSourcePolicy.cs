namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'style-src-elem' directive.  Specifies valid sources for stylesheets &lt;style&gt; elements and &lt;link&gt; elements with rel="stylesheet".
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/script-src-elem
    /// </remarks>
    [CspDirective(Directive = "style-src-elem")]
    public class StylesheetElementSourcePolicy : FetchDirectivePolicyBase { }
}
