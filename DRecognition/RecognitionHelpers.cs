using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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

        public static byte[] ToByteArray(this Image imageIn)
        {
            if (imageIn == null)
            {
                return null;
            }

            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image ToImage(this byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                return null;
            }

            var  ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }
    }
}
