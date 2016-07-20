using System.Drawing;
using System.Drawing.Imaging;

namespace DRecognition.ImageFilters
{
    public class ThresholdFilter : IImageFilter
    {
        public ThresholdFilter(int value)
        {
            ThresholdValue = value;
        }

        public int ThresholdValue { get; set; }

        public Image Apply(Image image)
        {
            //var aa = image.DrawBitmap();
            //var bitmap = AForge.Imaging.Image.Clone(aa, PixelFormat.);
            //var filter = new AForge.Imaging.Filters.Threshold(ThresholdValue);
            //bitmap = filter.Apply(bitmap);
            //return bitmap;

            return image;
        }
    }
}
