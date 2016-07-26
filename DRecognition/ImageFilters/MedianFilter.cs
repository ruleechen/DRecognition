using System;
using System.Collections.Generic;
using System.Drawing;

namespace DRecognition.ImageFilters
{
    public class MedianFilter : IImageFilter
    {
        public MedianFilter()
            : this(2)
        {
        }

        public MedianFilter(int size)
        {
            Size = size;
        }

        public int Size { get; set; }

        public Bitmap Apply(Bitmap bitmap)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            using (var newGraphics = Graphics.FromImage(newBitmap))
            {
                newGraphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
                newGraphics.Dispose();
            }

            var tempRandom = new Random();
            var apetureMin = -(Size / 2);
            var apetureMax = (Size / 2);

            for (var x = 0; x < newBitmap.Width; ++x)
            {
                for (var y = 0; y < newBitmap.Height; ++y)
                {
                    var rValues = new List<int>();
                    var gValues = new List<int>();
                    var bValues = new List<int>();

                    for (var x2 = apetureMin; x2 < apetureMax; ++x2)
                    {
                        var tempX = x + x2;
                        if (tempX >= 0 && tempX < newBitmap.Width)
                        {
                            for (var y2 = apetureMin; y2 < apetureMax; ++y2)
                            {
                                var tempY = y + y2;
                                if (tempY >= 0 && tempY < newBitmap.Height)
                                {
                                    var TempColor = bitmap.GetPixel(tempX, tempY);
                                    rValues.Add(TempColor.R);
                                    gValues.Add(TempColor.G);
                                    bValues.Add(TempColor.B);
                                }
                            }
                        }
                    }

                    rValues.Sort();
                    gValues.Sort();
                    bValues.Sort();

                    var MedianPixel = Color.FromArgb(
                        rValues[rValues.Count / 2],
                        gValues[gValues.Count / 2],
                        bValues[bValues.Count / 2]);

                    newBitmap.SetPixel(x, y, MedianPixel);
                }
            }

            return newBitmap;
        }

        public string GetCode()
        {
            return $"new {GetType().Name}({Size})";
        }
    }
}
