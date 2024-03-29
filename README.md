﻿# Fluent Content Security Policy Builder

## What is it?

This is a single accessible C# class designed to simplify generating CSP strings.  You can use it anywhere a string is expected, or if you prefer to delay string evaluation until the last minute, you can simply generate the object, and call `.Evaluate()` when it is appropriate.  If you follow the available Intellisense code-completion suggestions, you should get a spec conformant CSP string in return.

## Specific enhancements over traditional static string
* Supports punycoding international hostnames
* Supports build-time retrieval of nonce values
* Supports build-time SRI hashing of strings

## Examples

### Simple default policy

``` csharp
string x = ContentSecurityPolicyBuilder
            .BuildDefaultFetchPolicy()
            .AllowSelf()
            .Build()
            .Evaluate();

// x => default-src 'self'
```

### Multiple fetch directives 

``` csharp
string x = ContentSecurityPolicyBuilder
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
            .Build()
            .Evaluate();
            
// x => default-src 'self'; img-src *; media-src example.org example.net; script-src userscripts.example.com
```

### Extremely contrived example

You can also define a policy ahead of time, inject it with your preferred DI framework, and build it as needed.

``` csharp
IContentSecurityPolicy unevaluated = ContentSecurityPolicyBuilder
                                       .BuildDefaultFetchPolicy()
                                       .AllowSelf()
                                       .AllowHost("https://*.example.com:12/path/to/file.js")
                                       .AllowHost("https://*.üüüüüü.com.de:12/path/to/file.js")
                                       .AllowHost("https://*.παράδειγμα.δοκιμή:12/path/to/file.js")

                                       .AndFor()
                                       .DocumentDirectives()
                                       .ConfigureBaseUri()
                                       .AllowSelf()
                                       .AllowHashOf(SriHash.Sha256, "doSubmit()")

                                       .AndFor()
                                       .FetchDirectives()
                                       .OfPolicy<WorkerPolicy>()
                                       .AllowHashOf(SriHash.Sha512, () => "testValue")

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

                                       .Build();

// register the above as a transient or singleton in your DI registration

// inject the object here via the IContentSecurityPolicy interface

// evaluate it
string x = unevaluated.Evaluate();

// x => default-src 'self' https://*.example.com:12/path/to/file.js https://*.xn--tdaaaaaa.com.de:12/path/to/file.js https://*.xn--hxajbheg2az3al.xn--jxalpdlp:12/path/to/file.js; base-uri 'self' 'sha256-jzgBGA4UWFFmpOBq0JpdsySukE1FrEN5bUpoK8Z29fY='; worker-src 'sha512-UBNdmiHnX8D5kMYOEAyZEJnM437eWylYaei68WvLN00+bXos8Kq6vtDphFIYvD7THNBYAIKjICzOGIFpHgTtZQ=='; sandbox allow-downloads allow-same-origin allow-pointer-lock; img-src example.com 'self'; form-action 'self'; frame-ancestors 'self'; navigate-to 'self'
```

## Installing

If you want to use this in your project, install it from nuget:

`Install-Package RFord.Projects.FluentContentPolicyBuilder`

and reference it wherever appropriate in your project:

``` csharp
IContentSecurityPolicy policy = ContentSecurityPolicyBuilder
                                       .BuildDefaultFetchPolicy()
                                       ...
                                       ;
```

and start building!

## References

I primarily used the following sources when building this:

* [Content Security Policy Level 3 - W3C Working Draft, 20 February 2023](https://www.w3.org/TR/CSP3/)
* [Mozilla Developer Network Docs - Content-Security-Policy](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy)
* [RFC 3986 - Uniform Resource Identifier (URI): Generic Syntax](https://www.rfc-editor.org/rfc/rfc3986)
* [RFC 3492 - Punycode: A Bootstring encoding of Unicode for Internationalized Domain Names in Applications (IDNA)](https://www.rfc-editor.org/rfc/rfc3492)

## TODO

- [X] Create NuGet package

- [X] Differentiate static directives vs dynamic directives, building the former when calling `.AllowX()`, and the latter when calling `.Evaluate()`.  This is in contrast to the current behavior of deferring everything until final evaluation time.

- [ ] Benchmarks
