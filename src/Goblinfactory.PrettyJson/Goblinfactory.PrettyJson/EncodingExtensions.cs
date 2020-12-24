namespace Goblinfactory.PrettyJson.Internal
{
    internal static class EncodingExtensions
    {
        // this does not do url encoding
        // further reading
        // https://coder.today/tech/2017-10-20_encoding-in-web-development.-why-how-url-json-base64-beyond/
        public static string ToJsonEncode(this string src)
        {
            return src
                .Replace(@"\", @"\\")
                .Replace("\"", "\\\"");
        }
    }
}
