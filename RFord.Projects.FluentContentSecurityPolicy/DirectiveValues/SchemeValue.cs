namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class SchemeValue : DirectiveValueBase
    {
        private readonly string _final;

        internal override string Evaluate() => _final;

        internal SchemeValue(string scheme)
        {
            _final = PreProcess(scheme);
        }

        private static readonly IReadOnlySet<char> _allowedSchemeCharacters = new HashSet<char>() { '+', '-', '.' };

        // *( ALPHA / DIGIT / "+" / "-" / "." )
        protected bool isNotValidSchemeCharacter(char c) => !char.IsLetterOrDigit(c) && !_allowedSchemeCharacters.Contains(c);

        private string PreProcess(string scheme)
        {
            // defined in section 3.1 of RFC 3986
            // https://www.rfc-editor.org/rfc/rfc3986#section-3.1
            // also, allow an optional ":" at the end.
            // it can be safely ignored.
            foreach (char c in scheme.Take(scheme[^1] == ':' ? scheme.Length - 1 : scheme.Length))
            {
                if (isNotValidSchemeCharacter(c))
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(scheme));
                }
            }

            return scheme;
        }
    }
}
