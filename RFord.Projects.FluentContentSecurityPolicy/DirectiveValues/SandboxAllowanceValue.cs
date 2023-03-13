using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class SandboxAllowanceValue : DirectiveValueBase
    {
        private readonly string _final;

        internal override string Evaluate() => _final;

        internal SandboxAllowanceValue(SandboxPermissions allowance)
        {
            _final = PreProcess(allowance);
        }

        private string PreProcess(SandboxPermissions allowance)
        {
            string keywordString = allowance switch
            {
                SandboxPermissions.Downloads => "allow-downloads",
                SandboxPermissions.DownloadsWithoutUserActivation => "allow-downloads-without-user-activation",
                SandboxPermissions.Forms => "allow-forms",
                SandboxPermissions.Modals => "allow-modals",
                SandboxPermissions.OrientationLock => "allow-orientation-lock",
                SandboxPermissions.PointerLock => "allow-pointer-lock",
                SandboxPermissions.Popups => "allow-popups",
                SandboxPermissions.PopupsToEscapeSandbox => "allow-popups-to-escape-sandbox",
                SandboxPermissions.Presentation => "allow-presentation",
                SandboxPermissions.SameOrigin => "allow-same-origin",
                SandboxPermissions.Scripts => "allow-scripts",
                SandboxPermissions.StorageAccessByUserActivation => "allow-storage-access-by-user-activation",
                SandboxPermissions.TopNavigation => "allow-top-navigation",
                SandboxPermissions.TopNavigationByUserActivation => "allow-top-navigation-by-user-activation",
                SandboxPermissions.TopNavigationToCustomProtocols => "allow-top-navigation-to-custom-protocols",
                _ => throw new ArgumentOutOfRangeException(paramName: nameof(allowance))
            };
            return keywordString;
        }
    }
}
