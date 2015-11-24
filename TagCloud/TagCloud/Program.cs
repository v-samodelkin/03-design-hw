using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using CommandLine;
using Ninject;
namespace TagCloud
{
    class Program
    {
        private const string IMAGE_PATH = "TagCloudImage.png";
        static string ReadData(string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }

        static Dictionary<String, IPointGenerator> GetPointGenerators()
        {
            var d = new Dictionary<String, IPointGenerator>();
            d["ssg"] = new StableSpiralGenerator();
            d["sg"] = new SpiralGenerator();
            d["rssg"] = new StableSpiralGenerator(10, 20, 10);
            return d;
        }

        static FontGenerator GetFontGenerator(Options options)
        {
            return new FontGenerator(new FontFamily(options.FontFamilyName), options.Log, options.MultipleSize);
        }

        static void Main(string[] args)
        {
            
            var options = Parser.Parse(args, GetPointGenerators());
            var kernel = CreateKernel(options);
            var text = new Text(ReadData(options.InputFile));
            var cloud = new Cloud(text.Statistic(options.PreLoad).ToList(), options, kernel);
            foreach (var a in text.Statistic(options.PreLoad).Reverse())
            {
                Console.WriteLine(String.Format("{0} : {1}", a.Value, a.Count));
            }
            cloud.GenerateImage();
            SaveImageFromCloud(cloud);
        }

        static void SaveImageFromCloud(Cloud cloud)
        {
             cloud.Bitmap.Save(IMAGE_PATH, ImageFormat.Png);
        }

        private static IKernel CreateKernel(Options options)
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel, options);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel, Options options)
        {
            kernel.Bind<IPointGenerator>().ToConstant(options.Generator);
            kernel.Bind<FontGenerator>().ToConstant(GetFontGenerator(options));
        }
    }
}
