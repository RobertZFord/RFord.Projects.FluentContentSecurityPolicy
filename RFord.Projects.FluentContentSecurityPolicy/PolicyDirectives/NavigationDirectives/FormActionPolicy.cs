using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives;

namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.NavigationDirectives
{
    [CspDirective(Directive = "form-action")]
    public class FormActionPolicy : NavigationDirectivePolicyBase { }
}
