using System.Drawing;

namespace DRecognition.ImageFilters
{
    public class GrayscaleFilter : IImageFilter
    {
        public Bitmap Apply(Bitmap bitmap)
        {
            //return Grayscale.CommonAlgorithms.BT709.Apply(bitmap);

            for (var h = 0; h < bitmap.Height; h++)
            {
                for (var w = 0; w < bitmap.Width; w++)
                {
                    var tmpValue = GetGrayNumColor(bitmap.GetPixel(w, h));

                    bitmap.SetPixel(w, h, Color.FromArgb(tmpValue, tmpValue, tmpValue));
                }
            }

            return bitmap;
        }

        private static int GetGrayNumColor(Color posClr)
        {
            return (posClr.R * 19595 + posClr.G * 38469 + posClr.B * 7472) >> 16;
        }
    }
}
