namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'img-src' directive.  Specifies valid sources of images and favicons.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/img-src
    /// </remarks>
    [CspDirective(Directive = "img-src")]
    public class ImagePolicy : FetchDirectivePolicyBase { }
}
