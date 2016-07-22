using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace DRecognition
{
    public static class RecognitionHelpers
    {
        public static string NoSpace(this string source)
        {
            if (source == null) { return source; }
            return Regex.Replace(source, "\\s", string.Empty);
        }

        public static Bitmap GetArgbCopy(this Image image)
        {
            var bitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(image,
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    GraphicsUnit.Pixel);

                graphics.Flush();
            }

            return bitmap;
        }

        public static Bitmap ReDraw(this Image image)
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

            var ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }
    }
}
