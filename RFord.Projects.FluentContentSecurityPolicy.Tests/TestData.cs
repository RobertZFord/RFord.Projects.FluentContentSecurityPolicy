using RFord.Projects.FluentContentSecurityPolicy.Enums;
using RFord.Projects.FluentContentSecurityPolicy.PolicyDirectives.FetchDirectives;
using System.Collections;

namespace RFord.Projects.FluentContentSecurityPolicy.Tests
{
    public class TestData : IEnumerable<object[]>
    {
        private object[] createTestEntry(IContentSecurityPolicy policy, IDictionary<string, HashSet<string>> expectedDirectives) => new object[] { policy, expectedDirectives };

        private IDictionary<string, HashSet<string>> createExpectedDirectives(params (string, string[])[] values)
            => values.ToDictionary(
                x => x.Item1,
                x => x.Item2.ToHashSet()
            );

        private string nonceRetrievalFunction()
        {
            byte[] sample = new byte[] { 0xBE, 0xEF, 0xBE, 0xEF };
            string result = Convert.ToBase64String(sample); // vu++7w==
            return result;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            // default-src 'self'
            yield return createTestEntry(
                policy: ContentSecurityPolicyBuilder
                            .BuildDefaultFetchPolicy()
                            .AllowSelf()
                            .Build(),
                expectedDirectives: createExpectedDirectives(
                    ("default-src", new[] { "'self'" })
                )
            );

            // default-src 'self' example.com *.example.com
            yield return createTestEntry(
                policy: ContentSecurityPolicyBuilder
                            .BuildDefaultFetchPolicy()
                            .AllowSelf()
                            .AllowHost("example.com")
                            .AllowHost("*.example.com")
                            .Build(),
                expectedDirectives: createExpectedDirectives(
                    ("default-src", new[] { "'self'", "example.com", "*.example.com" })
                )
            );

            /*
            default-src 'self'
            img-src *
            media-src example.org example.net
            script-src userscripts.example.com
            */
            yield return createTestEntry(
                policy: ContentSecurityPolicyBuilder
                            .BuildDefaultFetchPolicy()
                            .AllowSelf()

                            .AndFor()
                            .FetchDirectives()
                            .OfPolicy<ImagePolicy>()
                            .AllowAll()

                            .AndFor()
                            .FetchDirectives()
                            .OfPolicy<MediaPolicy>()
                            .AllowHost("example.org")
                            .AllowHost("example.net")

                            .AndFor()
                            .FetchDirectives()
                            .OfPolicy<ScriptPolicy>()
                            .AllowHost("userscripts.example.com")
                            .Build(),
                expectedDirectives: createExpectedDirectives(
                    ("default-src", new[] { "'self'" }),
                    ("img-src", new[] { "*" }),
                    ("media-src", new[] { "example.org", "example.net" }),
                    ("script-src", new[] { "userscripts.example.com" })
                )
            );

            /*
            default-src 'self' https://*.example.com:12/path/to/file.js https://*.xn--tdaaaaaa.com.de:12/path/to/file.js https://*.xn--hxajbheg2az3al.xn--jxalpdlp:12/path/to/file.js
            media-src 'nonce-vu++7w=='
            base-uri 'self' 'sha256-jzgBGA4UWFFmpOBq0JpdsySukE1FrEN5bUpoK8Z29fY='
            sandbox allow-downloads allow-same-origin allow-pointer-lock
            img-src example.com 'self'
            form-action 'self'
            frame-ancestors 'self'
            navigate-to 'self'
            */
            yield return createTestEntry(
                policy: ContentSecurityPolicyBuilder
                            .BuildDefaultFetchPolicy()
                            .AllowSelf()
                            // test URL from https://www.w3.org/TR/CSP3/#framework-directive-source-list
                            .AllowHost("https://*.example.com:12/path/to/file.js")
                            // test URL from note in https://www.w3.org/TR/CSP3/#framework-directive-source-list
                            .AllowHost("https://*.üüüüüü.com.de:12/path/to/file.js")
                            // test domain from https://learn.microsoft.com/en-us/dotnet/api/system.globalization.idnmapping?view=net-7.0
                            // apparently it means "example.test" in greek
                            .AllowHost("https://*.παράδειγμα.δοκιμή:12/path/to/file.js")

                            .AndFor()
                            .FetchDirectives()
                            .OfPolicy<MediaPolicy>()
                            .AllowNonce(nonceRetrievalFunction)

                            .AndFor()
                            .DocumentDirectives()
                            .ConfigureBaseUri()
                            .AllowSelf()
                            .AllowHashOf(SriHash.Sha256, "doSubmit()")

                            .AndFor()
                            .DocumentDirectives()
                            .ConfigureSandbox()
                            .GrantPermission(SandboxPermissions.Downloads)

                            .AndFor()
                            .FetchDirectives()
                            .OfPolicy<ImagePolicy>()
                            .AllowHost("example.com")

                            .AndFor()
                            .DocumentDirectives()
                            .ConfigureSandbox()
                            .GrantPermission(SandboxPermissions.Downloads)
                            .GrantPermission(SandboxPermissions.SameOrigin)
                            .GrantPermission(SandboxPermissions.PointerLock)

                            .AndFor()
                            .DocumentDirectives()
                            .ConfigureBaseUri()
                            .AllowSelf()

                            .AndFor()
                            .NavigationDirectives()
                            .ConfigureFormAction()
                            .AllowSelf()

                            .AndFor()
                            .NavigationDirectives()
                            .ConfigureFrameAncestors()
                            .AllowSelf()

                            .AndFor()
                            .NavigationDirectives()
                            .ConfigureNavigateTo()
                            .AllowSelf()

                            .AndFor()
                            .DocumentDirectives()
                            .ConfigureBaseUri()
                            .AllowSelf()

                            .AndFor()
                            .FetchDirectives()
                            .OfPolicy<ImagePolicy>()
                            .AllowSelf()
                            .Build(),
                expectedDirectives: createExpectedDirectives(
                    (
                        "default-src",
                        new[] { "'self'", "https://*.example.com:12/path/to/file.js", "https://*.xn--tdaaaaaa.com.de:12/path/to/file.js", "https://*.xn--hxajbheg2az3al.xn--jxalpdlp:12/path/to/file.js" }
                    ),
                    (
                        "media-src",
                        new[] { "'nonce-vu++7w=='" }
                    ),
                    (
                        "base-uri",
                        new[] { "'self'", "'sha256-jzgBGA4UWFFmpOBq0JpdsySukE1FrEN5bUpoK8Z29fY='" }
                    ),
                    (
                        "sandbox",
                        new[] { "allow-downloads", "allow-same-origin", "allow-pointer-lock" }
                    ),
                    (
                        "img-src",
                        new[] { "example.com", "'self'" }
                    ),
                    (
                        "form-action",
                        new[] { "'self'" }
                    ),
                    (
                        "frame-ancestors",
                        new[] { "'self'" }
                    ),
                    (
                        "navigate-to",
                        new[] { "'self'" }
                    )
                )
            );
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
