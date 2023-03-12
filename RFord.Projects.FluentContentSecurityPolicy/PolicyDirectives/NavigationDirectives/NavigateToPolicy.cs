using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives;

namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.NavigationDirectives
{
    [CspDirective(Directive = "navigate-to")]
    public class NavigateToPolicy : NavigationDirectivePolicyBase { }
}
