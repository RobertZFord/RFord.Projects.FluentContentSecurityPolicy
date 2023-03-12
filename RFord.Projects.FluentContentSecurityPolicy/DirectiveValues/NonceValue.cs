namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class NonceValue : DirectiveValueBase
    {
        private readonly Func<string> _nonceRetrievalCallback;

        internal NonceValue(Func<string> nonceRetrievalCallback)
        {
            _nonceRetrievalCallback = nonceRetrievalCallback;
        }

        internal override string Evaluate()
        {
            string retrievedNonce = _nonceRetrievalCallback.Invoke();

            // base64-value  = 1*( ALPHA / DIGIT / "+" / "/" / "-" / "_" )*2( "=" )
            foreach (char c in retrievedNonce)
            {
                if (isNotValidBase64Character(c))
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(retrievedNonce));
                }
            }

            string finalResult = $"'nonce-{retrievedNonce}'";

            return finalResult;
        }
    }
}
