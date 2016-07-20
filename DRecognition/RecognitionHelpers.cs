using System.Drawing;

namespace DRecognition
{
    public static class RecognitionHelpers
    {
        public static Bitmap DrawBitmap(this Image image)
        {
            var bitmap = new Bitmap(image.Width, image.Height);

            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(bitmap, 0, 0);
            }

            return bitmap;
        }
    }
}
