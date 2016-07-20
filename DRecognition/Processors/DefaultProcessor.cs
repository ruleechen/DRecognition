using System.Drawing;

namespace DRecognition.Processors
{
    public class DefaultProcessor : IImgProcessor
    {
        public Image Process(Image image)
        {
            return image;
        }
    }
}
