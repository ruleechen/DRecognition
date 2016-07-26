using System.Drawing;

namespace DRecognition
{
    public interface IImageFilter
    {
        Bitmap Apply(Bitmap bitmap);

        string GetCode();
    }
}
