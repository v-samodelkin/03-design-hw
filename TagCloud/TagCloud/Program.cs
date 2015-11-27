using System;
using System.Collections.Generic;
using System.Drawing;
using Ninject;
namespace TagCloud
{
    class Program
    {
        private static string ImagePath = "\\..\\..\\Image\\TagcCloudImage.png";
        static void Main(string[] args)
        {
            ImagePath = Environment.CurrentDirectory + ImagePath;

            var options = Parser.Parse(args, GetPointGenerators());
            var kernel = CreateKernel(options);
            var cloud = kernel.Get<ICloudBuilder>();

            cloud.GenerateImage();
            cloud.Build();

            DebugData(kernel.Get<IData>());
        }


        private static IKernel CreateKernel(Options options)
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel, options);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel, Options options)
        {
            kernel.Bind<Options>().ToConstant(options);
            kernel.Bind<IDataReader>().To<TxtFileReader>();
            kernel.Bind<IPointGenerator>().ToConstant(options.Generator);
            kernel.Bind<IFontGenerator>().ToConstant(GetFontGenerator(options));
            kernel.Bind<ISaveModule>().ToConstant(new PngSaveModule(ImagePath));
            kernel.Bind<IData>().ToConstant(kernel.Get<IDataReader>().ClearData());
            kernel.Bind<IGraphicModule>().To<DefaultGraphicModule>();
            kernel.Bind<ICloudBuilder>().To<BitmapCloudBuilder>();
        }

        private static void DebugData(IData data)
        {
            foreach (var a in data.Data)
            {
                Console.WriteLine("{0} : {1}", a.Value, a.Count);
            }
        }

        static Dictionary<String, IPointGenerator> GetPointGenerators()
        {
            var d = new Dictionary<String, IPointGenerator>();
            d["ssg"] = new FastSpiralGenerator();
            d["sg"] = new SpiralGenerator();
            d["rssg"] = new FastSpiralGenerator();
            return d;
        }

        static FontGenerator GetFontGenerator(Options options)
        {
            return new FontGenerator(new FontFamily(options.FontFamilyName), options.Log, options.MultipleSize);
        }
    }
}
