using RFord.Projects.FluentContentSecurityPolicy.DirectiveValues;
using RFord.Projects.FluentContentSecurityPolicy.DirectiveValues.HashOutputs;
using RFord.Projects.FluentContentSecurityPolicy.Enums;
using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives;
using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.DocumentDirectives;
using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives;
using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.NavigationDirectives;
using RFord.Projects.FluentContentSecurityPolicy.States;
using RFord.Projects.FluentContentSecurityPolicy.States.Internal;
using System.Collections;
using System.Collections.Specialized;

namespace RFord.Projects.FluentContentSecurityPolicy
{
    // consider separating the directive values into immediate and deferred
    // evalation.  something like a host name, keyword, scheme, etc. should be
    // able to be evaluated immediately: they're unlikely to change during
    // runtime.  however, nonces, and possibly hashes, probably need to have
    // their evaluation deferred to request-time.
    /// <summary>
    /// Typed builder for generating Content-Security-Policy header values.
    /// </summary>
    /// <remarks>
    /// REF: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy
    /// REF: https://www.w3.org/TR/CSP3/
    /// REF: https://www.rfc-editor.org/rfc/rfc3986
    /// REF: https://www.rfc-editor.org/rfc/rfc3492
    /// </remarks>
    public class ContentSecurityPolicyBuilder
        : IContentSecurityPolicy
        , ITransitionToDirectiveContext
        , ILocationSpecificAllowMethods
        , IInitialSourceSpecification
        , ISourceSpecificationContext
        , ILocationSpecificContext
        , IFetchPolicyContext
        , IFetchDirectiveContext
        , IDirectiveSelectionContext
        , INavigationDirectiveContext
        , ISandboxGrantConfigurationContext
        , ISandboxConfigurationContext
        , IDocumentDirectiveContext
    {
        private Type _currentDirective;
        // this was originally just an IDictionary, but OrderedDictionary
        // maintains the key insertion order, and I would like the resultant CSP
        // string to roughly match the order of method calls.
        private readonly OrderedDictionary _directives;

        internal ContentSecurityPolicyBuilder()
        {
            _currentDirective = typeof(DefaultPolicy);
            _directives = new OrderedDictionary();
        }

        private void AddSource(DirectiveValueBase source)
        {
            if (_directives.Contains(_currentDirective) && _directives[_currentDirective] is List<DirectiveValueBase> entry)
            {
                // void
                //_directives[_currentDirective].Add(source);
                entry.Add(source);
            }
            else
            {
                // List<string>
                _directives[_currentDirective] = new List<DirectiveValueBase> { source };
            }
        }

        /// <summary>
        /// Begin building the CSP at the default fallback fetch policy.
        /// </summary>
        public static IInitialSourceSpecification BuildDefaultFetchPolicy()
        {
            // because the ctor starts with DefaultPolicy as the active context,
            // we needn't internally call
            // `.AndFor().FetchDirectives().OfPolicy<DefaultPolicy>()`
            return new ContentSecurityPolicyBuilder();
        }

        public string Evaluate()
        {
            static string processDictionaryEntry(DictionaryEntry entry)
            {
                Type currentPolicy = (Type)entry.Key!;
                List<DirectiveValueBase> directives = (List<DirectiveValueBase>)entry.Value!;

                object[] directiveAttributes = currentPolicy.GetCustomAttributes(typeof(CspDirectiveAttribute), true);
                CspDirectiveAttribute directiveAttribute = directiveAttributes.OfType<CspDirectiveAttribute>().Single();

                string[] first = new string[] { directiveAttribute.Directive };
                string[] second = directives
                                    // convert each token to its expected CSP
                                    // string value
                                    .Select(x => x.Evaluate())
                                    // collect distinct values to simplify the
                                    // string.
                                    // NOTE:
                                    // .Distinct is not guaranteed to be a
                                    // stable sort,
                                    // but if it mixes up the order, I don't
                                    // *think* that will be a huge deal.
                                    .Distinct(StringComparer.Ordinal)
                                    .ToArray()
                                    ;
                string segment = string.Join(' ', first.Concat(second));

                return segment;
            }

            IEnumerable<string> directives = _directives.Cast<DictionaryEntry>().Select(processDictionaryEntry);
            string finalEvaluation = string.Join("; ", directives);

            return finalEvaluation;
        }

        public IDirectiveSelectionContext AndFor() => this;

        public ISourceSpecificationContext AllowNone()
        {
            NoneValue token = new NoneValue();
            AddSource(token);
            return this;
        }

        public ISourceSpecificationContext AllowSelf()
        {
            AllowKeyword(SourceKeyword.Self);
            return this;
        }

        public ISourceSpecificationContext AllowAll()
        {
            AllowHost("*");
            return this;
        }

        public ISourceSpecificationContext AllowScheme(string scheme)
        {
            SchemeValue token = new SchemeValue(scheme);
            AddSource(token);
            return this;
        }

        public ISourceSpecificationContext AllowHost(string hostName)
        {
            HostValue token = new HostValue(hostName);
            AddSource(token);
            return this;
        }

        public ISourceSpecificationContext AllowKeyword(SourceKeyword keyword)
        {
            FetchKeywordValue token = new FetchKeywordValue(keyword);
            AddSource(token);
            return this;
        }

        public ISourceSpecificationContext AllowNonce(Func<string> retrievalCallback)
        {
            NonceValue token = new NonceValue(retrievalCallback);
            AddSource(token);
            return this;
        }

        public ISourceSpecificationContext AllowHash(SriHash hashAlgorithm, string hashData)
        {
            ComputedHashValue token = new ComputedHashValue(hashAlgorithm, hashData);
            AddSource(token);
            return this;
        }

        public ISourceSpecificationContext AllowHashOf(SriHash hashAlgorithm, string dataToHash)
        {
            UncomputedHashValue token = new UncomputedHashValue(hashAlgorithm, dataToHash);
            AddSource(token);
            return this;
        }

        public ISourceSpecificationContext AllowHashOf(SriHash hashAlgorithm, Func<string> dataRetrievalCallback)
        {
            LazyHashValue token = new LazyHashValue(hashAlgorithm, dataRetrievalCallback);
            AddSource(token);
            return this;
        }

        public IFetchPolicyContext OfPolicy<TPolicy>() where TPolicy : FetchDirectivePolicyBase
        {
            _currentDirective = typeof(TPolicy);
            return this;
        }

        public IFetchDirectiveContext FetchDirectives() => this;

        public IDocumentDirectiveContext DocumentDirectives() => this;

        public INavigationDirectiveContext NavigationDirectives() => this;

        public ISourceSpecificationContext ConfigureFormAction()
        {
            _currentDirective = typeof(FormActionPolicy);
            return this;
        }

        public ILocationSpecificContext ConfigureFrameAncestors()
        {
            _currentDirective = typeof(FrameAncestorsPolicy);
            return this;
        }

        public ILocationSpecificContext ConfigureNavigateTo()
        {
            _currentDirective = typeof(NavigateToPolicy);
            return this;
        }

        public ISandboxGrantConfigurationContext GrantPermission(SandboxPermissions permission)
        {
            SandboxAllowanceValue token = new SandboxAllowanceValue(permission);
            AddSource(token);
            return this;
        }

        public ISandboxConfigurationContext ConfigureSandbox()
        {
            _currentDirective = typeof(SandboxPolicy);
            return this;
        }

        public ILocationSpecificContext ConfigureBaseUri()
        {
            _currentDirective = typeof(BaseUriPolicy);
            return this;
        }

        public IContentSecurityPolicy Build() => this;
    }
}
