namespace RFord.Projects.FluentContentSecurityPolicy.States.Internal
{
    public interface ILocationSpecificAllowMethods
    {
        /// <summary>
        /// Allow none of the associated resources.  This is the most restrictive source and will override any other specified sources.
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#none
        /// </remarks>
        ISourceSpecificationContext AllowNone();

        /// <summary>
        /// Allow the URL of the current page.
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#self
        /// </remarks>
        ISourceSpecificationContext AllowSelf();

        /// <summary>
        /// Allow loading the resource type from any host.
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#host-source
        /// </remarks>
        ISourceSpecificationContext AllowAll();

        /// <summary>
        /// Allow loading a resource from any URL that matches the specified scheme.
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#scheme-source
        /// </remarks>
        ISourceSpecificationContext AllowScheme(string scheme);

        /// <summary>
        /// Allow loading resources from a matching URL, domain, or host.
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#host-source
        /// </remarks>
        ISourceSpecificationContext AllowHost(string hostName);
    }
}
