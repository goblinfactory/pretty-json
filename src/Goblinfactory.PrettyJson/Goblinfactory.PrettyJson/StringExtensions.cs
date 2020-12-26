namespace Goblinfactory.PrettyJson.Internal
{
    internal static class StringExtensions
    {
        // this does not do url encoding
        // further reading
        // https://coder.today/tech/2017-10-20_encoding-in-web-development.-why-how-url-json-base64-beyond/
        // and https://www.ietf.org/rfc/rfc4627.txt
        public static string ToJsonEncode(this string src, IPrettyConfig config)
        {
            return src
                .Replace(@"\", @"\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Clip(config.ClipStringMaxLen);
        }

        public static string Clip(this string src, int? maxLen)
        {
            if (maxLen == null) return src;
            if (src == null) return null;
            if (src.Length <= maxLen) return src;
            if(maxLen<10) return src.Substring(0, maxLen.Value);
            return $"{src.Substring(0, maxLen.Value - 3)}...";
        }
    }
}
