using System.Drawing;

namespace DRecognition.ImageFilters
{
    public class DefaultFilter : IImageFilter
    {
        public Bitmap Apply(Bitmap bitmap)
        {
            return bitmap;
        }
    }
}
