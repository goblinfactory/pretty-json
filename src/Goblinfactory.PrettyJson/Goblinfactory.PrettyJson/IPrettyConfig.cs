using System;

namespace Goblinfactory.PrettyJson
{
    public interface IPrettyConfig
    {
        /// <summary>
        /// set to null to disable clipping of strings.
        /// </summary>
        int? ClipStringMaxLen { get; set; }
        int EasyReadPropWidth { get; set; }
        bool EasyRead { get; set; }
        IPrettyStyle LightStyle { get; set; }
        IPrettyStyle DarkStyle { get; set; }
        int IndentWidth { get; set; }
        IPrettyJsonSerializer Serializer { get; set; }
        int NumberOfDecimals { get; set; }
    }
}