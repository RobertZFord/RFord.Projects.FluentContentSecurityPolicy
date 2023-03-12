namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class SchemeValue : DirectiveValueBase
    {
        private readonly string _scheme;

        private static readonly IReadOnlySet<char> _allowedSchemeCharacters = new HashSet<char>() { '+', '-', '.' };

        // *( ALPHA / DIGIT / "+" / "-" / "." )
        protected bool isNotValidSchemeCharacter(char c) => !char.IsLetterOrDigit(c) && !_allowedSchemeCharacters.Contains(c);

        internal SchemeValue(string scheme)
        {
            _scheme = scheme;
        }

        internal override string Evaluate()
        {
            // defined in section 3.1 of RFC 3986
            // https://www.rfc-editor.org/rfc/rfc3986#section-3.1
            // also, allow an optional ":" at the end.
            // it can be safely ignored.
            foreach (char c in _scheme.Take(_scheme[^1] == ':' ? _scheme.Length - 1 : _scheme.Length))
            {
                if (isNotValidSchemeCharacter(c))
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(_scheme));
                }
            }

            return _scheme;
        }
    }
}
