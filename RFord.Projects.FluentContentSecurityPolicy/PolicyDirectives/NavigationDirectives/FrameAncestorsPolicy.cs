using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives;

namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.NavigationDirectives
{
    [CspDirective(Directive = "frame-ancestors")]
    public class FrameAncestorsPolicy : NavigationDirectivePolicyBase { }
}
