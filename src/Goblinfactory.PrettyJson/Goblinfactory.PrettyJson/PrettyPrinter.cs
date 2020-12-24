﻿using System;
using static System.Console;
using System.Text.Json;
using static System.ConsoleColor;
using System.Text;
using Goblinfactory.PrettyJson.Internal;

namespace Goblinfactory.PrettyJson
{

    public class PrettyPrinter
    {

        //private readonly IPrettyStyle Config.LightStyle;
        //private readonly IPrettyStyle Config.DarkStyle;
        //private readonly IPrettyJsonSerializer Config.Serializer;
        //private int Config.IndentWidth;
        //private int Config.NumberOfDecimals;
        private int _indent = 0;
        public PrettyPrinter(IPrettyConfig config)
        {
            Config = config;
            //Config.LightStyle = config.LightStyle;
            //Config.DarkStyle = config.DarkStyle;
            //Config.Serializer = config.Serializer;
            //Config.IndentWidth = config.IndentWidth;
            //Config.NumberOfDecimals = config.NumberOfDecimals;
        }

        public IPrettyConfig Config { get; set; }

        public void PrintJson(object obj)
        {
            var json = Config.Serializer.Serialize(obj);
            Print(json);
        }
        void printWithMargin(string text)
        {
            var margin = new string(' ', _indent);
            Write($"{margin}{text}");
        }

        bool isValueProperty(JsonTokenType? token)
        {
            switch (token)
            {
                case JsonTokenType.String:
                    return true;
                case JsonTokenType.Number:
                    return true;
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.False:
                    return true;
                case JsonTokenType.Null:
                    return true;
                default:
                    return false;
            }
        }

        void addCommaIfneeded(JsonTokenType? last, JsonTokenType next, IPrettyStyle style)
        {
            ForegroundColor = style.Quotes;
            if (isValueProperty(last) && isValueProperty(next)) { WriteLine(","); return; }
            if (last == JsonTokenType.StartArray) return;
            if (last == JsonTokenType.PropertyName) return;
            if (last == JsonTokenType.StartObject && next == JsonTokenType.PropertyName) return;
            if (last == JsonTokenType.EndObject && next == JsonTokenType.PropertyName) { WriteLine(","); return; };
            if (last == null) return;
            if (next == JsonTokenType.PropertyName && isValueProperty(last)) { WriteLine(","); return; }
            if (last == JsonTokenType.PropertyName && isValueProperty(next)) { WriteLine(","); return; }
            WriteLine();
        }

        private void indent()
        {
            _indent += Config.IndentWidth;
        }

        private void outdent()
        {
            _indent -= Config.IndentWidth;
        }

        public void Print(object src)
        {
            string json = Config.Serializer.Serialize(src);
            Print(json);
        }
        
        public void Print(string json)
        {
            var currentForeColor = Console.ForegroundColor;
            try
            {
                _Print(json);
            }
            finally
            {
                ForegroundColor = currentForeColor;
            }
        }

        private ConsoleColor GetStringColor(IPrettyStyle style, string propname)
        {
            if (!style.ColorsForProps.ContainsKey(propname)) return style.Strings;
            return style.ColorsForProps[propname];
        }
        private void _Print(string json)
        {

            var style = PrettyStyle.IsDarkBackground ? Config.DarkStyle : Config.LightStyle;
            var bytes = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(bytes);
            bool isArray = false;

            JsonTokenType? last = null;
            string propName = null;

            while (reader.Read())
            {
                var token = reader.TokenType;

                addCommaIfneeded(last, token, style);
                switch (token)
                {
                    case JsonTokenType.StartObject:
                        ForegroundColor = style.CurlyBraces;
                        WriteLine("{");
                        indent();
                        break;
                    case JsonTokenType.EndObject:
                        ForegroundColor = style.CurlyBraces;
                        outdent();
                        printWithMargin("}");
                        break;
                    case JsonTokenType.StartArray:
                        isArray = true;
                        ForegroundColor = style.SquareBraces;
                        WriteLine("[");
                        indent();
                        break;
                    case JsonTokenType.EndArray:
                        ForegroundColor = style.SquareBraces;
                        outdent();
                        printWithMargin("]");
                        isArray = false;
                        break;
                    case JsonTokenType.PropertyName:
                        ForegroundColor = style.Quotes;
                        printWithMargin("\"");
                        ForegroundColor = style.PropertyNames;
                        var name = reader.GetString();
                        propName = name;
                        Write($"{name}");
                        ForegroundColor = style.Quotes;
                        Write("\": ");
                        break;
                    case JsonTokenType.Null:
                        ForegroundColor = style.Nulls;
                        if (isArray) printWithMargin("null"); else Write("null");
                        break;
                    case JsonTokenType.Number:
                        ForegroundColor = style.Numbers;
                        double number = Math.Round(reader.GetDouble(), Config.NumberOfDecimals);
                        if (isArray) printWithMargin(number.ToString()); else Write(number);
                        break;
                    case JsonTokenType.False:
                    case JsonTokenType.True:
                        ForegroundColor = style.Bools;
                        bool tf = reader.GetBoolean();
                        if (isArray) printWithMargin(tf.ToString().ToLower()); else Write(tf.ToString().ToLower());
                        break;
                    case JsonTokenType.String:
                        ForegroundColor = style.Quotes;
                        if (isArray) printWithMargin("\""); else Write("\"");
                        ForegroundColor = GetStringColor(style, propName);
                        Write(reader.GetString().ToJsonEncode());
                        ForegroundColor = style.Quotes;
                        Write("\"");
                        break;
                    default:
                        break;
                }
                last = token;
            }
        }


    }
}