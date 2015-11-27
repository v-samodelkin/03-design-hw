using System;
using System.Collections.Generic;
using System.Linq;

namespace TagCloud
{
    public static class Parser
    {
        public static Options Parse(string[] args, Dictionary<String, IPointGenerator> pointGenerators)
        {

            var opt = new Options();
            opt.Generator = pointGenerators.First().Value;


            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-f":
                    case "--file":
                        opt.InputFile = args[++i];
                        break;
                    case "-g":
                    case "--gen":
                        opt.Generator = pointGenerators[args[++i]];
                        break;
                    case "-w":
                    case "--width":
                        opt.Width = int.Parse(args[++i]);
                        break;
                    case "-h":
                    case "--height":
                        opt.Height = int.Parse(args[++i]);
                        break;
                    case "-l":
                    case "--log":
                        opt.Log = false;
                        break;
                    case "-s":
                    case "--multipleSize":
                        opt.MultipleSize = int.Parse(args[++i]);
                        break;
                    case "-i":
                    case "--ignoreCase":
                        opt.AddToPreLoad(s => s.ToLower());
                        break;
                    case "-c":
                    case "--clear":
                        opt.AddToPreLoad(x => new String(x.Where(char.IsLetter).ToArray()));
                        break;
                    case "-n":
                    case "--fontFamilyName":
                        opt.FontFamilyName = "";
                        for (; i < args.Length; i++)
                            if (args[i][0] != '-')
                                opt.AddToFontFamilyName(args[i]);
                            else
                                i--;
                                break;
                        break;
                    case "-b":
                    case "--brush":
                        opt.BrushColorName = args[++i];
                        break;
                    case "-o":
                    case "--font":
                        opt.FontColorName = args[++i];
                        break;
                }
            }
            return opt;
        }
    }
}
