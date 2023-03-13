using System.Globalization;

namespace RFord.Projects.FluentContentSecurityPolicy.DirectiveValues
{
    internal class HostValue : DirectiveValueBase
    {
        private readonly string _final;

        internal override string Evaluate() => _final;

        internal HostValue(string hostName)
        {
            _final = PreProcess(hostName);
        }

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

        private string PreProcess(string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName))
            {
                throw new ArgumentOutOfRangeException(paramName: hostName);
            }
            const string schemeDelimiter = "://";
            int schemeDelimiterIndex = hostName.IndexOf(schemeDelimiter);
            int hostPartStart = schemeDelimiterIndex == -1 ? 0 : schemeDelimiterIndex + schemeDelimiter.Length;

            int portDelimiterIndex = hostName.IndexOf(':', hostPartStart);
            int pathDelimiterIndex = hostName.IndexOf('/', hostPartStart);

            //bool hasScheme = schemeDelimiterIndex > 0;
            //bool hasPort = portDelimiterIndex > 0;
            //bool hasPath = pathDelimiterIndex > 0;

            // if there's a path, we need to ensure it has valid characters
            if (pathDelimiterIndex > 0)
            {
                foreach (char c in hostName.Skip(pathDelimiterIndex))
                {
                    if (isNotValidAbsolutePathCharacter(c))
                    {
                        throw new ArgumentOutOfRangeException(paramName: nameof(hostName));
                    }
                }
            }

            // process hostname for punycoding!
            int hostPartEnd = Math.Min(
                portDelimiterIndex > 0 ? portDelimiterIndex : hostName.Length,
                pathDelimiterIndex > 0 ? pathDelimiterIndex : hostName.Length
            );

            // extract hostname part
            string originalHostPart = hostName.Substring(hostPartStart, hostPartEnd - hostPartStart);

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
            string finalResult = hostName.Replace(originalHostPart, codedHostPart);

            return finalResult;
        }
    }
}
