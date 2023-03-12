using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives;

namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.DocumentDirectives
{
    [CspDirective(Directive = "base-uri")]
    public class BaseUriPolicy : DocumentDirectivePolicyBase { }
}
