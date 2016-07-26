using System.Drawing;

namespace DRecognition.ImageFilters
{
    public class RotateFilter : IImageFilter
    {
        public RotateFilter(float angle)
        {
            Angle = angle;
        }

        public float Angle { get; set; }

        public Bitmap Apply(Bitmap bitmap)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            var graphics = Graphics.FromImage(newBitmap);
            graphics.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);
            graphics.RotateTransform(Angle);
            graphics.TranslateTransform(-(float)bitmap.Width / 2, -(float)bitmap.Height / 2);
            graphics.DrawImage(bitmap, new Point(0, 0));
            return newBitmap;
        }

        public string GetCode()
        {
            return $"new {GetType().Name}({Angle})";
        }
    }
}
