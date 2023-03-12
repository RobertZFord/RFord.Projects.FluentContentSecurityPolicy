namespace RFord.Projects.FluentContentSecurityPolicy.Enums
{

    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox
    /// </remarks>
    public enum SandboxPermissions
    {
        /// <summary>
        /// Matches the 'allow-downloads' value.  Per MDN: "Allows downloading files through an &lt;a&gt; or &lt;area&gt; element with the download attribute, as well as through the navigation that leads to a download of a file. This works regardless of whether the user clicked on the link, or JS code initiated it without user interaction."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-downloads
        /// </remarks>
        Downloads,

        /// <summary>
        /// Matches the 'allow-downloads-without-user-activation' value.  Per MDN: "Allows for downloads to occur without a gesture from the user."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-downloads-without-user-activation
        /// </remarks>
        DownloadsWithoutUserActivation,

        /// <summary>
        /// Matches the 'allow-forms' value.  Per MDN: "Allows the page to submit forms. If this keyword is not used, form will be displayed as normal, but submitting it will not trigger input validation, sending data to a web server or closing a dialog."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-forms
        /// </remarks>
        Forms,

        /// <summary>
        /// Matches the 'allow-modals' value.  Per MDN: "Allows the page to open modal windows by Window.alert(), Window.confirm(), Window.print() and Window.prompt(), while opening a &lt;dialog&gt; is allowed regardless of this keyword. It also allows the page to receive BeforeUnloadEvent event."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-modals
        /// </remarks>
        Modals,

        /// <summary>
        /// Matches the 'allow-orientation-lock' value.  Per MDN: "Lets the resource lock the screen orientation."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-orientation-lock
        /// </remarks>
        OrientationLock,

        /// <summary>
        /// Matches the 'allow-pointer-lock' value.  Per MDN: "Allows the page to use the Pointer Lock API."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-pointer-lock
        /// </remarks>
        PointerLock,

        /// <summary>
        /// Matches the 'allow-popups' value.  Per MDN: "Allows popups (like from Window.open(), target="_blank", Window.showModalDialog()). If this keyword is not used, that functionality will silently fail."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-popups
        /// </remarks>
        Popups,

        /// <summary>
        /// Matches the 'allow-popups-to-escape-sandbox' value.  Per MDN: "Allows a sandboxed document to open new windows without forcing the sandboxing flags upon them. This will allow, for example, a third-party advertisement to be safely sandboxed without forcing the same restrictions upon the page the ad links to."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-popups-to-escape-sandbox
        /// </remarks>
        PopupsToEscapeSandbox,

        /// <summary>
        /// Matches the 'allow-presentation' value.  Per MDN: "Allows embedders to have control over whether an iframe can start a presentation session."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-presentation
        /// </remarks>
        Presentation,

        /// <summary>
        /// Matches the 'allow-same-origin' value.  Per MDN: "If this token is not used, the resource is treated as being from a special origin that always fails the same-origin policy (potentially preventing access to data storage/cookies and some JavaScript APIs)."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-same-origin
        /// </remarks>
        SameOrigin,

        /// <summary>
        /// Matches the 'allow-scripts' value.  Per MDN: "Allows the page to run scripts (but not create pop-up windows). If this keyword is not used, this operation is not allowed."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-scripts
        /// </remarks>
        Scripts,

        /// <summary>
        /// Matches the 'allow-storage-access-by-user-activation' value.  Per MDN: "Lets the resource request access to the parent's storage capabilities with the Storage Access API."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-storage-access-by-user-activation
        /// </remarks>
        StorageAccessByUserActivation,

        /// <summary>
        /// Matches the 'allow-top-navigation' value.  Per MDN: "Lets the resource navigate the top-level browsing context (the one named _top)."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-top-navigation
        /// </remarks>
        TopNavigation,

        /// <summary>
        /// Matches the 'allow-top-navigation-by-user-activation' value.  Per MDN: "Lets the resource navigate the top-level browsing context, but only if initiated by a user gesture."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-top-navigation-by-user-activation
        /// </remarks>
        TopNavigationByUserActivation,

        /// <summary>
        /// Matches the 'allow-top-navigation-to-custom-protocols' value.  Per MDN: "Allows navigations to non-http protocols built into browser or registered by a website. This feature is also activated by allow-popups or allow-top-navigation keyword."
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox#allow-top-navigation-to-custom-protocols
        /// </remarks>
        TopNavigationToCustomProtocols
    }
}
