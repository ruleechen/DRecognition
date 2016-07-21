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

        public Bitmap Apply(Bitmap bitmap)
        {
            bitmap = Grayscale.CommonAlgorithms.RMY.Apply(bitmap);
            var filter = new Threshold(ThresholdValue);
            return filter.Apply(bitmap).ReDraw();
        }
    }
}
