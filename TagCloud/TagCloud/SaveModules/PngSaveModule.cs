using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    class PngSaveModule : ISaveModule
    {
        public string ImagePath { get; private set; }
        public PngSaveModule(string imagePath)
        {
            ImagePath = imagePath;
        }

        public void Save(GraphicCloudBuilder graphicCloud)
        {
            graphicCloud.GraphicModule.Bitmap.Save(ImagePath, ImageFormat.Png);
        }
    }
}
