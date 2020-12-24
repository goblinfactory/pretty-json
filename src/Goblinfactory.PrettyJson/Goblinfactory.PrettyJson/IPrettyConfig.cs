using System;

namespace Goblinfactory.PrettyJson
{
    public interface IPrettyConfig
    {
        int EasyReadPropWidth { get; set; }
        bool EasyRead { get; set; }
        IPrettyStyle LightStyle { get; set; }
        IPrettyStyle DarkStyle { get; set; }
        int IndentWidth { get; set; }
        IPrettyJsonSerializer Serializer { get; set; }
        int NumberOfDecimals { get; set; }
    }
}