namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives
{
    /// <summary>
    /// Configure the 'worker-src' directive.  Specifies valid sources for Worker, SharedWorker, or ServiceWorker scripts.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/worker-src
    /// </remarks>
    [CspDirective(Directive = "worker-src")]
    public class WorkerPolicy : FetchDirectivePolicyBase { }
}
