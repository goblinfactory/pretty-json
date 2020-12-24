using System;
using System.Collections.Generic;
using System.Linq;
using static System.ConsoleColor;

namespace Goblinfactory.PrettyJson
{
    public class PrettyStyle : IPrettyStyle
    {
        public PrettyStyle(ConsoleColor quotes, ConsoleColor curlyBraces, ConsoleColor propertyNames, ConsoleColor strings, ConsoleColor numbers, ConsoleColor bools, ConsoleColor nulls, ConsoleColor squareBraces)
        {
            Quotes = quotes;
            CurlyBraces = curlyBraces;
            PropertyNames = propertyNames;
            Strings = strings;
            Numbers = numbers;
            Bools = bools;
            Nulls = nulls;
            SquareBraces = squareBraces;
        }

        public ConsoleColor Quotes { get; set; }
        public ConsoleColor CurlyBraces { get; set; } 
        public ConsoleColor PropertyNames { get; set; }
        public ConsoleColor Strings { get; set; }
        public ConsoleColor Numbers { get; set; }
        public ConsoleColor Bools { get; set; }
        public ConsoleColor Nulls { get; set; }
        public ConsoleColor SquareBraces { get; set; }
        public Dictionary<string, ConsoleColor> ColorsForProps { get; set; } = new Dictionary<string, ConsoleColor>();
        
        public static bool IsDarkBackground
        {
            get
            {
                var darks = new[] { Black, DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta, DarkRed, DarkYellow };
                return darks.Any(d => d == Console.BackgroundColor);
            }
        }

        public static IPrettyStyle LightStyle
        {
            get
            {
                return new PrettyStyle(DarkGray, DarkGray, DarkCyan, DarkGreen, DarkYellow, Black, Red, Black);
            }
        }

        public static IPrettyStyle DarkStyle
        {
            get
            {
                return new PrettyStyle(Gray, Gray, Cyan, Green, DarkYellow, Yellow, White, White);
            }
        }
    }
}
