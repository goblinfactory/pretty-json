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

            printer.Config.EasyRead = false;

            // change background to white, pretty printer will use a white background style
            BackgroundColor = White;
            Clear();

            // disable clipping
            printer.Config.ClipStringMaxLen = null;
            printer.PrintJson(data);

            ReadLine();

            BackgroundColor = Black;
            Clear();

            // print all URLs in Yellow
            printer.Config.DarkStyle.ColorsForProps["url"] = Yellow;
            var quizz = new
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
            };
            printer.Print(quizz);
            ReadLine();

            Clear();

            // useful Dump extensions, note the correct conversion of enums to integers!
            var dark = printer.Config.DarkStyle;
                
            dark.Dump();
            ReadLine();
            WriteLine();

            new { Hat = "Large", Cat = "Zeus" }.Dump();
            ReadLine();
            WriteLine();
            // easy read mode, sample below shows dumping using a particular printers configuration

            printer.Config.EasyRead = true;
            new { Hat = "Large", Cat = "Zeus" }.Dump(printer.Config);
            ReadLine();
            WriteLine();

            // use a specific width to match the width of the items being dumped
            printer.Config.EasyReadPropWidth = 20;
            dark.Dump(printer.Config);

            // end of demo
            ReadLine();
            WriteLine();
            WriteLine("end of demo");
        }

        // attribution
        // inspiration for this nuget package as well as Sample test values below are from : https://github.com/dluc/DL.PrettyText.NET
        private static object GetData()
        {
            return new
            {
                demo_object = new
                {
                    LongTextFieldWithQuotesAndSlashes = "quotes string example  " + '\\' + " " + '"' + "hasquotes" + '"' + " / 'text'",
                    data = new
                    {
                        shortString = "S",
                        longString = 
@" I'm not wearing hockey pads. No guns, no killing. Does it come in black?

It's not who I am underneath but what I do that defines me.

Accomplice ? I'm gonna tell them the whole thing was your idea. The first time I stole so that I wouldn't starve,
yes.I lost many assumptions about the simple nature of right and wrong.And when I traveled I learned the fear before a crime and the thrill of success.But I never became one of them.

I seek the means to fight injustice.To turn fear against those who prey on the fearful.It's ends here. The first time I stole so that I wouldn't starve,
yes.I lost many assumptions about the simple nature of right and wrong.And when I traveled I learned the fear before a crime and the thrill of success.But I never became one of them.",
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
