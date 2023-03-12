using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class FetchKeywordValue : DirectiveValueBase
    {
        private readonly SourceKeyword _keyword;

        internal FetchKeywordValue(SourceKeyword keyword)
        {
            _keyword = keyword;
        }

        internal override string Evaluate()
        {
            // https://www.w3.org/TR/CSP3/#framework-directive-source-list
            string keywordString = _keyword switch
            {
                SourceKeyword.Self => "'self'",
                SourceKeyword.UnsafeInline => "'unsafe-inline'",
                SourceKeyword.UnsafeEval => "'unsafe-eval'",
                SourceKeyword.StrictDynamic => "'strict-dynamic'",
                SourceKeyword.UnsafeHashes => "'unsafe-hashes'",
                SourceKeyword.UnsafeAllowRedirects => "'unsafe-allow-redirects'",
                SourceKeyword.WasmUnsafeEval => "'wasm-unsafe-eval'",
                _ => throw new ArgumentOutOfRangeException(paramName: nameof(_keyword))
            };
            return keywordString;
        }
    }
}
