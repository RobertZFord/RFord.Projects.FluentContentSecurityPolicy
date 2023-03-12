namespace RFord.Projects.FluentContentSecurityPolicy.States
{
    public interface IDirectiveSelectionContext
    {
        /// <summary>
        /// Configure fetch directives.  Per MDN: "Fetch directives control the locations from which certain resource types may be loaded."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy#fetch_directives
        /// </remarks>
        IFetchDirectiveContext FetchDirectives();

        /// <summary>
        /// Configure document directives.  Per MDN: "Document directives govern the properties of a document or worker environment to which a policy applies."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy#document_directives
        /// </remarks>
        IDocumentDirectiveContext DocumentDirectives();

        /// <summary>
        /// Configure navigation directives.  Per MDN: "Navigation directives govern to which locations a user can navigate or submit a form, for example."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy#navigation_directives
        /// </remarks>
        INavigationDirectiveContext NavigationDirectives();
    }
}
