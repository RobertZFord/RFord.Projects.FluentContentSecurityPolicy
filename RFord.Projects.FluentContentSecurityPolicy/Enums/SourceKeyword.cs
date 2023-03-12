namespace RFord.Projects.FluentContentSecurityPolicy.Enums
{
    public enum SourceKeyword
    {
        /// <summary>
        /// Matches the current URL's origin.
        /// </summary>
        Self,

        /// <summary>
        /// When explicitly stated, allows inline &lt;script/&gt; elements.
        /// </summary>
        UnsafeInline,

        /// <summary>
        /// When explicity stated, allows
        ///   `eval()`,
        ///   `function()`,
        ///   `setTimeout()`,
        ///   and `setInterval()`
        /// calls within JavaScript, and 
        ///   `new WebAssembly.Module()`,
        ///   `WebAssembly.compile()`,
        ///   `WebAssembly.compileStreaming()`,
        ///   `WebAssembly.instantiate()`,
        ///   and `WebAssembly.instantiateStreaming()`
        /// calls within WebAssembly.
        /// </summary>
        /// <remarks>
        /// REF: https://www.w3.org/TR/CSP3/#directive-script-src
        /// </remarks>
        UnsafeEval,

        /// <summary>
        /// When explicitly stated, ignores `host-source`, `scheme-source`, 
        /// 'unsafe-inline' keyword, and 'self' keyword expressions when 
        /// loading a script, but does honor `hash-source`, and `nonce-source`
        /// expressions.  Additionally, non-parser inserted &lt;script/&gt; 
        /// elements are allowed.
        /// </summary>
        /// <remarks>
        /// REF: https://www.w3.org/TR/CSP3/#strict-dynamic-usage
        /// REF: https://html.spec.whatwg.org/#parser-inserted
        /// </remarks>
        StrictDynamic,

        /// <summary>
        /// When stated, allows hashed event handlers in unsafe inline scripts.
        /// e.g. this keyword, plus the SRI hash 
        /// 'sha256-jzgBGA4UWFFmpOBq0JpdsySukE1FrEN5bUpoK8Z29fY=' would allow 
        /// &lt;button onclick="doSubmit()" /&gt; to execute, where the SRI hash
        /// is the base64 encoded SHA256 hash of the string "doSubmit()".
        /// </summary>
        /// <remarks>
        /// REF: https://www.w3.org/TR/CSP3/#unsafe-hashes-usage
        /// </remarks>
        UnsafeHashes,

        UnsafeAllowRedirects,

        /// <summary>
        /// When explicitly stated, allows
        ///   `new WebAssembly.Module()`,
        ///   `WebAssembly.compile()`,
        ///   `WebAssembly.compileStreaming()`,
        ///   `WebAssembly.instantiate()`,
        ///   and `WebAssembly.instantiateStreaming()`
        /// calls within WebAssembly.
        /// </summary>
        /// <remarks>
        /// REF: https://www.w3.org/TR/CSP3/#directive-script-src, see item 5 note
        /// </remarks>
        WasmUnsafeEval
    }
}
