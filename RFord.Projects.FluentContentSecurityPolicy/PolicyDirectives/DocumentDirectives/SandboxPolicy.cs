using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives;

namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.DocumentDirectives
{
    [CspDirective(Directive = "sandbox")]
    public class SandboxPolicy : DocumentDirectivePolicyBase { }
}
