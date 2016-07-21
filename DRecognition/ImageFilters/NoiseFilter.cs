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

        public Image Apply(Image image)
        {
            var bmpobj = new Bitmap(image);

            for (int i = 0; i < bmpobj.Width; i++)
            {
                for (int j = 0; j < bmpobj.Height; j++)
                {
                    var piexl = bmpobj.GetPixel(i, j);
                    if (piexl.R < GrayValue)
                    {
                        var nearDots = 0;

                        if (i == 0 || i == bmpobj.Width - 1 || j == 0 || j == bmpobj.Height - 1)
                        {
                            bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            if (bmpobj.GetPixel(i - 1, j - 1).R < GrayValue) { nearDots++; }
                            if (bmpobj.GetPixel(i, j - 1).R < GrayValue) { nearDots++; }
                            if (bmpobj.GetPixel(i + 1, j - 1).R < GrayValue) { nearDots++; }
                            if (bmpobj.GetPixel(i - 1, j).R < GrayValue) { nearDots++; }
                            if (bmpobj.GetPixel(i + 1, j).R < GrayValue) { nearDots++; }
                            if (bmpobj.GetPixel(i - 1, j + 1).R < GrayValue) { nearDots++; }
                            if (bmpobj.GetPixel(i, j + 1).R < GrayValue) { nearDots++; }
                            if (bmpobj.GetPixel(i + 1, j + 1).R < GrayValue) { nearDots++; }
                        }

                        if (nearDots < MaxNearPoints)
                        {
                            bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                    }
                    else
                    {
                        bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }
            }

            return bmpobj;
        }
    }
}
