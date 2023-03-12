namespace RFord.Projects.FluentContentSecurityPolicy.States
{
    public interface INavigationDirectiveContext
    {
        /// <summary>
        /// Configure the 'form-action' directive.  Per MDN: "Restricts the URLs which can be used as the target of a form submissions from a given context."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/form-action
        /// </remarks>
        ISourceSpecificationContext ConfigureFormAction();

        /// <summary>
        /// Configure the 'frame-ancestors' directive.  Per MDN: "Specifies valid parents that may embed a page using &lt;frame&gt;, &lt;iframe&gt;, &lt;object&gt;, &lt;embed&gt;, or &lt;applet&gt;."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/frame-ancestors
        /// </remarks>
        ILocationSpecificContext ConfigureFrameAncestors();

        /// <summary>
        /// Configure the 'navigate-to' directive.  Per MDN: "Restricts the URLs to which a document can initiate navigation by any means, including &lt;form&gt; (if form-action is not specified), &lt;a&gt;, window.location, window.open, etc."
        /// </summary>
        /// <remarks>
        /// (There does not appear to be an in-depth page on the MDN docs for this directive)
        /// </remarks>
        ILocationSpecificContext ConfigureNavigateTo();
    }
}
