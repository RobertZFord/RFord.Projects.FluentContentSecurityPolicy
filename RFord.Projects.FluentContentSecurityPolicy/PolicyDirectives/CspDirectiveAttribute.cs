namespace RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class CspDirectiveAttribute : Attribute
    {
        public string Directive { get; set; } = "";
    }
}
