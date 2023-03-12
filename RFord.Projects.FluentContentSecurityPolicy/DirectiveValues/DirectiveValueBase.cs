namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal abstract class DirectiveValueBase
    {
        private static readonly IReadOnlySet<char> _allowedBase64Characters = new HashSet<char>() { '+', '/', '-', '_', '=' };

        // 1*( ALPHA / DIGIT / "+" / "/" / "-" / "_" )*2( "=" )
        protected bool isNotValidBase64Character(char c) => !char.IsLetterOrDigit(c) && !_allowedBase64Characters.Contains(c);

        internal abstract string Evaluate();
    }
}
