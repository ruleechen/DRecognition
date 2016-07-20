using System.Drawing;

namespace DRecognition
{
    public interface IImageFilter
    {
        Image Apply(Image image);
    }
}
