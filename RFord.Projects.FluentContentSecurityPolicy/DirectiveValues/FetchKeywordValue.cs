using RFord.Projects.FluentContentSecurityPolicy.Enums;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class FetchKeywordValue : DirectiveValueBase
    {
        private readonly string _final;

        internal override string Evaluate() => _final;

        internal FetchKeywordValue(SourceKeyword keyword)
        {
            _final = PreProcess(keyword);
        }

        private string PreProcess(SourceKeyword keyword)
        {
            // https://www.w3.org/TR/CSP3/#framework-directive-source-list
            string _eval = keyword switch
            {
                SourceKeyword.Self => "'self'",
                SourceKeyword.UnsafeInline => "'unsafe-inline'",
                SourceKeyword.UnsafeEval => "'unsafe-eval'",
                SourceKeyword.StrictDynamic => "'strict-dynamic'",
                SourceKeyword.UnsafeHashes => "'unsafe-hashes'",
                SourceKeyword.UnsafeAllowRedirects => "'unsafe-allow-redirects'",
                SourceKeyword.WasmUnsafeEval => "'wasm-unsafe-eval'",
                _ => throw new ArgumentOutOfRangeException(paramName: nameof(keyword))
            };
            return _eval;
        }
    }
}
