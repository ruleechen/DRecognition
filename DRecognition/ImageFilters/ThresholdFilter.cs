using AForge.Imaging.Filters;
using System.Drawing;

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
            var bitmap = Grayscale.CommonAlgorithms.RMY.Apply(new Bitmap(image));
            var filter = new Threshold(ThresholdValue);
            return filter.Apply(bitmap);
        }
    }
}
