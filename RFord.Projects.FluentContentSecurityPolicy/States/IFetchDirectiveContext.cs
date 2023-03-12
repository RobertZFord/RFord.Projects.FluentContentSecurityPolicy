using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives;

namespace RFord.Projects.FluentContentSecurityPolicy.States
{
    public interface IFetchDirectiveContext
    {
        /// <summary>
        /// Configure a fetch policy, e.g. an image, media, or script policy.
        /// </summary>
        /// <typeparam name="TPolicy"></typeparam>
        /// <returns></returns>
        IFetchPolicyContext OfPolicy<TPolicy>() where TPolicy : FetchDirectivePolicyBase;
    }
}
