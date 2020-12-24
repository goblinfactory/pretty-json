using System;
using static System.Console;
using static System.ConsoleColor;

namespace Goblinfactory.PrettyJson.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = GetData();

            var printer = new PrettyPrinter(PrettyConfig.CreateDefault());
            printer.PrintJson(data);
            ReadLine();

            Clear();
            printer.Config.EasyRead = true;
            printer.PrintJson(data);
            ReadLine();

            printer.Config.EasyRead = false;

            // change background to white, pretty printer will use a white background style
            BackgroundColor = White;
            Clear();
            printer.PrintJson(data);
            ReadLine();

            BackgroundColor = Black;
            Clear();

            // print all URLs in Yellow
            printer.Config.DarkStyle.ColorsForProps["url"] = Yellow;
            printer.Print(new
            {
                        q1 = new
                        {
                            question = "What is the best JazzClub in London?",
                            options = new[] { "Vortex", "Ronnie Scott", "Pizza Express Jazz Club", "Kansas Smitty’s", "Buster Mantis", "Dalston Jazz Bar" }
                        },
                        answer = new
                        {
                            name = "Ronnie Scott",
                            description = "As one of the world’s oldest jazz bars, Ronnie Scott’s in Soho has hosted Sarah Vaughan, Count Basie and Miles Davis...",
                            attribution = new
                            {
                                url = "https://www.standard.co.uk/culture/music/best-jazz-bars-and-clubs-in-london-a3843231.htmlhttps://www.standard.co.uk/culture/music/best-jazz-bars-and-clubs-in-london-a3843231.html",
                                name = "Evening Standard"
                            }
                        }
            });

            ReadLine();

            Clear();

            // useful Dump extensions, note the correct conversion of enums to integers!
            printer.Config.DarkStyle.Dump();
            ReadLine();

            new { Hat = "Large", Cat = "Zeus" }.Dump();
            ReadLine();
        }

        // attribution
        // inspiration for this nuget package as well as Sample test values below are from : https://github.com/dluc/DL.PrettyText.NET
        private static object GetData()
        {
            return new
            {
                someObject = new
                {
                    name = "example  " + '\\' + " " + '"' + "quoted" + '"' + " / 'text'",
                    data = new
                    {
                        shortString = "S",
                        nested = new
                        {
                            nested = new
                            {
                                Anniversary = new DateTime(2020, 12, 25, 11, 55, 20).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                                ID = "SGML",
                                Code = ".. unícødè ☁ ☀ chârs ..",
                                GlossTerm = "Standard Generalized Markup Language",
                                Acronym = "SGML",
                                Abbrev = "ISO 8879:1986",
                                definition = new
                                {
                                    desc = "A meta-markup null, language, used to create markup languages such as DocBook.",
                                    See_Also_This = new[] { "GML", "XML" }
                                },
                                SeeAlso = "markup"
                            }
                        },
                        value1 = 0,
                        value2 = 1.2346,
                        value3 = -2340,
                        Yes = true,
                        No = false,
                        Nothing = (object)null,
                        list_of_doubles = new[] { 0, 1d / 4, 2d / 3, -3 },
                        hashOfIntegers = new
                        {
                            a0 = 0,
                            a1 = 1,
                            a2 = 2
                        }
                    }
                }
            };
        }
    }
}
