using System;
using System.Collections.Generic;

namespace Goblinfactory.PrettyJson
{
    public interface IPrettyStyle
    {
        ConsoleColor Quotes { get; }
        ConsoleColor CurlyBraces { get; }
        ConsoleColor PropertyNames { get; }
        ConsoleColor Strings { get; }
        ConsoleColor Numbers { get; }
        ConsoleColor Bools { get; }
        ConsoleColor Nulls { get; }
        ConsoleColor SquareBraces { get; }
        Dictionary<string, ConsoleColor> ColorsForProps { get; }
    }
}