using System.Drawing;

namespace DRecognition
{
    public interface IImgProcessor
    {
        Image Process(Image image);
    }
}
