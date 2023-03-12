namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'media-src' directive.  Specifies valid sources for loading media using the &lt;audio&gt;, &lt;video&gt;, and &lt;track&gt; elements.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/media-src
    /// </remarks>
    [CspDirective(Directive = "media-src")]
    public class MediaPolicy : FetchDirectivePolicyBase { }
}
