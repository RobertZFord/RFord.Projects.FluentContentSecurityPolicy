using System.Globalization;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class HostValue : DirectiveValueBase
    {
        internal HostValue(string hostName)
        {
            _hostName = hostName;
        }

        private readonly string _hostName;

        private static readonly IReadOnlySet<char> _prohibitedPathCharacters = new HashSet<char>() { ';', ',' };

        protected bool isNotValidAbsolutePathCharacter(char c) => _prohibitedPathCharacters.Contains(c);

        private string punyCodedHostPartScrub(string part)
        {
            if (!string.Equals(a: part, b: "*"))
            {
                foreach (char c in part)
                {
                    if (!char.IsAscii(c) || (!char.IsLetterOrDigit(c) && c != '-'))
                    {
                        throw new ArgumentOutOfRangeException(paramName: nameof(part));
                    }
                }
            }
            return part;
        }


        internal override string Evaluate()
        {
            if (string.IsNullOrWhiteSpace(_hostName))
            {
                throw new ArgumentOutOfRangeException(paramName: _hostName);
            }
            const string schemeDelimiter = "://";
            int schemeDelimiterIndex = _hostName.IndexOf(schemeDelimiter);
            int hostPartStart = schemeDelimiterIndex == -1 ? 0 : schemeDelimiterIndex + schemeDelimiter.Length;

            int portDelimiterIndex = _hostName.IndexOf(':', hostPartStart);
            int pathDelimiterIndex = _hostName.IndexOf('/', hostPartStart);

            //bool hasScheme = schemeDelimiterIndex > 0;
            //bool hasPort = portDelimiterIndex > 0;
            //bool hasPath = pathDelimiterIndex > 0;

            // if there's a path, we need to ensure it has valid characters
            if (pathDelimiterIndex > 0)
            {
                foreach (char c in _hostName.Skip(pathDelimiterIndex))
                {
                    if (isNotValidAbsolutePathCharacter(c))
                    {
                        throw new ArgumentOutOfRangeException(paramName: nameof(_hostName));
                    }
                }
            }

            // process hostname for punycoding!
            int hostPartEnd = Math.Min(
                portDelimiterIndex > 0 ? portDelimiterIndex : _hostName.Length,
                pathDelimiterIndex > 0 ? pathDelimiterIndex : _hostName.Length
            );

            // extract hostname part
            string originalHostPart = _hostName.Substring(hostPartStart, hostPartEnd - hostPartStart);

            // split it into processable components
            string[] hostPartParts = originalHostPart.Split('.');

            // spawn a new mapper for punycoding
            IdnMapping mapper = new IdnMapping();

            // convert the individual hostname parts to punycode, and scrub them for validity
            string[] punycodedHostPartParts = hostPartParts
                                                .Select(part => mapper.GetAscii(part))
                                                .Select(punyCodedHostPartScrub)
                                                .ToArray();

            // put them back together again
            string codedHostPart = string.Join('.', punycodedHostPartParts);

            // replace the original host name with the punycoded host name
            string finalResult = _hostName.Replace(originalHostPart, codedHostPart);

            return finalResult;
        }
    }
}
