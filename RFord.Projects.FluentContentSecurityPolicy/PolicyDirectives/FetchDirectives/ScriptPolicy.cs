namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'script-src' directive.  Specifies valid sources for JavaScript and WebAssembly resources.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/script-src
    /// </remarks>
    [CspDirective(Directive = "script-src")]
    public class ScriptPolicy : FetchDirectivePolicyBase { }
}
