using System.Drawing;

namespace DRecognition.ImageFilters
{
    public class NoiseFilter : IImageFilter
    {
        public NoiseFilter(int grayValue)
            : this(grayValue, 1)
        {

        }

        public NoiseFilter(int grayValue, int maxNearPoints)
        {
            GrayValue = grayValue;
            MaxNearPoints = maxNearPoints;
        }

        public int GrayValue { get; set; }

        public int MaxNearPoints { get; set; }

        public Bitmap Apply(Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var piexl = bitmap.GetPixel(i, j);
                    if (piexl.R < GrayValue)
                    {
                        var nearDots = 0;

                        if (i == 0 || i == bitmap.Width - 1 || j == 0 || j == bitmap.Height - 1)
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            if (bitmap.GetPixel(i - 1, j - 1).R < GrayValue) { nearDots++; }
                            if (bitmap.GetPixel(i, j - 1).R < GrayValue) { nearDots++; }
                            if (bitmap.GetPixel(i + 1, j - 1).R < GrayValue) { nearDots++; }
                            if (bitmap.GetPixel(i - 1, j).R < GrayValue) { nearDots++; }
                            if (bitmap.GetPixel(i + 1, j).R < GrayValue) { nearDots++; }
                            if (bitmap.GetPixel(i - 1, j + 1).R < GrayValue) { nearDots++; }
                            if (bitmap.GetPixel(i, j + 1).R < GrayValue) { nearDots++; }
                            if (bitmap.GetPixel(i + 1, j + 1).R < GrayValue) { nearDots++; }
                        }

                        if (nearDots < MaxNearPoints)
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }
            }

            return bitmap;
        }
    }
}
