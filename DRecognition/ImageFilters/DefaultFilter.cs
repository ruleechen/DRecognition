using System.Drawing;

namespace DRecognition.ImageFilters
{
    public class DefaultFilter : IImageFilter
    {
        public Image Apply(Image image)
        {
            return image;
        }
    }
}
