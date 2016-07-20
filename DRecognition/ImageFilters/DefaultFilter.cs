using System.Drawing;

namespace DRecognition.Processors
{
    public class DefaultFilter : IImageFilter
    {
        public Image Apply(Image image)
        {
            return image;
        }
    }
}
