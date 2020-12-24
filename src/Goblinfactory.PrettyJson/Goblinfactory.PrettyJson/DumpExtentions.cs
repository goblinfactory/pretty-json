namespace Goblinfactory.PrettyJson
{
    public static class DumpExtentions
    {
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
