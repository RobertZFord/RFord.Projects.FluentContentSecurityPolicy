using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.States.Internal
{
    public interface ISandboxConfigurationMethods
    {
        /// <summary>
        /// Specify a permission to grant to the sandbox for this resource.
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/sandbox
        /// </remarks>
        ISandboxGrantConfigurationContext GrantPermission(SandboxPermissions permission);
    }
}
