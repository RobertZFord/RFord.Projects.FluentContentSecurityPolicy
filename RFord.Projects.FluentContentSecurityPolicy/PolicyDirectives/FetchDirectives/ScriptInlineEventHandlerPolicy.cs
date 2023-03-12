namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'script-src-attr' directive.  Specifies valid sources for JavaScript inline event handlers.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/style-src-attr
    /// </remarks>
    [CspDirective(Directive = "script-src-attr")]
    public class ScriptInlineEventHandlerPolicy : FetchDirectivePolicyBase { }
}
