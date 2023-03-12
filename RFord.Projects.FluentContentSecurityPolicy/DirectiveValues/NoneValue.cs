namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class NoneValue : DirectiveValueBase
    {
        internal override string Evaluate() => "'none'";
    }
}
