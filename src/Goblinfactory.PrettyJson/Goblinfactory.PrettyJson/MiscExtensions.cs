namespace Goblinfactory.PrettyJson.Internal
{
    internal static class MiscExtensions
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

        public static string Dump(this string src)
        {
            var config = PrettyConfig.CreateDefault();
            new PrettyPrinter(config).PrintJson(src);
            return src;
        }

        public static object Dump(this object src)
        {
            var config = PrettyConfig.CreateDefault();
            new PrettyPrinter(config).PrintJson(src);
            return src;
        }

        public static string Dump(this string src, IPrettyConfig config)
        {
            new PrettyPrinter(config).PrintJson(src);
            return src;
        }

        public static object Dump(this object src, IPrettyConfig config)
        {
            new PrettyPrinter(config).PrintJson(src);
            return src;
        }
    }
}
