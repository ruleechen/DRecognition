using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRecognition.ImageFilters
{
    public class ColorBlockFilter : IImageFilter
    {
        public ColorBlockFilter(int findArgbColor, int replaceArgbColor, int maxNearPoints)
        {
            FindColor = findArgbColor;
            ReplaceColor = replaceArgbColor;
            MaxNearPoints = maxNearPoints;
        }

        public int FindColor { get; set; }
        public int ReplaceColor { get; set; }
        public int MaxNearPoints { get; set; }

        public Bitmap Apply(Bitmap bitmap)
        {
            var findColor = Color.FromArgb(FindColor);
            var replaceColor = Color.FromArgb(ReplaceColor);
            

        }

        public string GetCode()
        {
            return $"new {GetType().Name}({FindColor}, {ReplaceColor}, {MaxNearPoints})";
        }
    }
}
