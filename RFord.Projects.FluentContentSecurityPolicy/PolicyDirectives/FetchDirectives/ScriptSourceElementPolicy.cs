namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'script-src-elem' directive.  Specifies valid sources for JavaScript &lt;script&gt; elements.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/script-src-elem
    /// </remarks>
    [CspDirective(Directive = "script-src-elem")]
    public class ScriptSourceElementPolicy : FetchDirectivePolicyBase { }
}
