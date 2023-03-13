using RFord.Projects.FluentContentSecurityPolicy.Enums;
using RFord.Projects.FluentContentSecurityPolicy.States.Internal;

namespace RFord.Projects.FluentContentSecurityPolicy.States
{
    public interface IInitialSourceSpecification
        : ILocationSpecificAllowMethods
    {
        /// <summary>
        /// Allow specific keywords.  e.g. 'self', 'unsafe-eval', etc.
        /// </summary>
        /// <param name="keyword"></param>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#self
        /// REF: https://www.w3.org/TR/CSP3/#grammardef-keyword-source
        /// </remarks>
        ISourceSpecificationContext AllowKeyword(SourceKeyword keyword);

        /// <summary>
        /// Allow a resource based on a nonce attribute.  e.g. if the CSP value 'nonce-abcd1234' is permitted, then &lt;script nonce="abcd1234"&gt;...&lt;/script&gt; is allowed to run.
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/script-src#unsafe_inline_script
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#nonce-base64-value
        /// </remarks>
        ISourceSpecificationContext AllowNonce(Func<string> retrievalCallback);

        /// <summary>
        /// Allow a resource based on an already-computed Subresource Integrity (SRI) hash value.
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#hash-algorithm-base64-value
        /// </remarks>
        ISourceSpecificationContext AllowHash(SriHash hashAlgorithm, string hashData);

        /// <summary>
        /// Calculate a hash based on the provided parameter.  This can be used with 'unsafe-hashes' to allow secured event handlers.
        /// 
        /// See <seealso cref="SourceKeyword.UnsafeHashes"/> for more info.
        /// </summary>
        /// <remarks>
        /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/Sources#hash-algorithm-base64-value
        /// REF: https://www.w3.org/TR/CSP3/#unsafe-hashes-usage
        /// </remarks>
        ISourceSpecificationContext AllowHashOf(SriHash hashAlgorithm, string dataToHash);

        /// <summary>
        /// Calculate a hash based on the result of the specified callback.  This is deferred until string build-time.
        /// </summary>
        /// <param name="hashAlgorithm"></param>
        /// <param name="dataRetrievalCallback"></param>
        /// <returns></returns>
        ISourceSpecificationContext AllowHashOf(SriHash hashAlgorithm, Func<string> dataRetrievalCallback);
    }
}
