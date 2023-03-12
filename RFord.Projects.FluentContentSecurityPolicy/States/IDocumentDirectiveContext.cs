namespace RFord.Projects.FluentContentSecurityPolicy.States
{
    public interface IDocumentDirectiveContext
    {
        /// <summary>
        /// Configure a sandbox for the current page via the 'sandbox' directive.  Per MDN: "Enables a sandbox for the requested resource similar to the &lt;iframe&gt; sandbox attribute."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox
        /// </remarks>
        ISandboxConfigurationContext ConfigureSandbox();

        /// <summary>
        /// Configure the 'base-uri' directive.  Per MDN: "Restricts the URLs which can be used in a document's &lt;base&gt; element."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/base-uri
        /// </remarks>
        ILocationSpecificContext ConfigureBaseUri();
    }
}
