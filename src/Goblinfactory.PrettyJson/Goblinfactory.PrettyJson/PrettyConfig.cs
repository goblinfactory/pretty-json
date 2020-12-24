using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Goblinfactory.PrettyJson
{
    public class DefaultMicrosoftSerializer : IPrettyJsonSerializer
    {
        public static JsonSerializerOptions Options;
        public DefaultMicrosoftSerializer()
        {
            Options = new JsonSerializerOptions { 
                WriteIndented = true,
            };
        }
        public string Serialize<T>(T src) where T : class
        {
            return JsonSerializer.Serialize(src, Options);
        }
        
        public object DeSerialize(string src)
        {
            var obj = JsonSerializer.Deserialize<object>(src);
            return obj;
        }
        public T DeSerialize<T>(string src) where T : class
        {
            var obj = (T)JsonSerializer.Deserialize<T>(src);
            return obj;
        }
    }
    public class PrettyConfig : IPrettyConfig
    {
        public int IndentWidth { get; set; } = 3;
        public int NumberOfDecimals { get; set; } = 6;

        // allow you to override the default serializer with a simple wrapper around Json.NET if you want.
        // if you override the default serializer please remember to ensure that the json
        // is pretty printed, ie indented, not single line.
        public IPrettyJsonSerializer Serializer { get; set; } = new DefaultMicrosoftSerializer();

        public static PrettyConfig CreateDefault()
        {
            return new PrettyConfig();
        }

        public IPrettyStyle LightStyle { get; set; } = PrettyStyle.LightStyle;
        public IPrettyStyle DarkStyle { get; set; } = PrettyStyle.DarkStyle;
        
    }
}
